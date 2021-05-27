using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebSklad2.Classes;


namespace WebSklad2.Forms
{
    public partial class WorkerReport : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                baseReport(false);
                Panel2.Visible = false;
                Label2.Visible = false;
                fillFIO();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            baseReport(false);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            shortReport(false);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           
            switch (Label1.Text)
            {
                case "Отчет для куратора":
                    kurReport(true);
                    break;
                case "Сводный отчет":
                    baseReport(true);
                    break;
                case "Краткий отчет по подрядчику":
                    shortReport(true);
                    break;
            }
        }

        protected void baseReport(bool download)
        {
            Label1.Text = "Сводный отчет";
            Panel1.Visible = false;
            TextBox1.Visible = false;
            Panel2.Visible = false;
            DataTable data = sql.GetDataBySP(new string[] { "spWEBbaseWorkerReport" }, true);
            GridView1.DataSource = data;
            GridView1.DataBind();
            if (download)
            {
                ExcelReport.BaseWorkerReport(data);
                sendFile(@"C:\\WEB\Reports\base.xlsx");
            }
        }

        protected void shortReport(bool download)
        {
            Label1.Text = "Краткий отчет по подрядчику";
            Panel2.Visible = true;
            DropDownList3.Visible = false;
            Label3.Visible = false;
            //fillFIO();
            string[] fio = DropDownList2.Text.Split(new char[] { ' ' });
            DataTable data = sql.GetDataBySP(new string[] { "spWEBShortWorkerReport", "@Surname", fio[0], "@Name", fio[1] }, false);
           
            GridView1.DataSource = data;
            GridView1.DataBind();
            if (download)
            {
                ExcelReport.ShortWorkerReport(data,DropDownList2.Text);
                sendFile(@"C:\\WEB\Reports\short.xlsx");
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label1.Text = "Отчет для куратора";
            //fillFIO();
            FillDates();
            Panel2.Visible = true;
            DropDownList3.Visible = true;
            Label3.Visible = true;
            kurReport(false);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Label1.Text)
            {
                case "Отчет для куратора":
                    FillDates();
                    kurReport(false);
                    break;
                case "Краткий отчет по подрядчику":
                    shortReport(false);
                    break;

            }
        }

        protected void FillDates()
        {
            DropDownList3.Items.Clear();
            string[] fio = DropDownList2.Text.Split(new char[] { ' ' });
            DataTable Dates = sql.GetDataBySP(new string[] { "spWEBGetDeviceDeliveryDate", "@Surname", fio[0], "@Name", fio[1] }, false);
            for (int i = 0; i < Dates.Rows.Count; i++)
            {
                DropDownList3.Items.Add(Dates.Rows[i][0].ToString().Substring(0,10));
            }

        }

        protected void fillFIO()
        {
            DataTable FIO = sql.getDataByQuery("SELECT Surname + ' ' + Name + ' ' + Midlename AS 'ФИО' FROM dbo.Worker WHERE Worker_group = 'Монтажник'", false);
            for (int i = 0; i < FIO.Rows.Count; i++)
            {
                DropDownList2.Items.Add(FIO.Rows[i][0].ToString());
            }
            FillDates();
        }
        protected void kurReport(bool download)
        {
            Label2.Visible = false;
            GridView1.Visible = true;
            string[] fio = DropDownList2.Text.Split(new char[] { ' ' });
            if (DropDownList3.Text == string.Empty)
            {
                Label2.Text = "Подрядчик не получал ПУ";
                Label2.Visible = true;
                GridView1.Visible = false;
                return;
            }
            string[] date = sql.parseString(DropDownList3.Text);
            DataTable data = sql.GetDataBySP(new string[] { "spWEBGetDeviceDeliveryByDateWorker", "@Date", date[0], "@Surname", fio[0], "@Name", fio[1] }, true);
            GridView1.DataSource = data;
            GridView1.DataBind();
            if (download)
            {
                ExcelReport.makeKurReport(data, DropDownList2.Text, DropDownList3.Text);
                sendFile(@"C:\\WEB\Reports\kurator.xlsx");

            }

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            kurReport(false);
        }

        protected void sendFile(string fileName)
        {
            
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition",
               string.Format("attachment; filename={0}", fileName));
            Response.TransmitFile(fileName);
            Response.End();
        }
                
    }

}