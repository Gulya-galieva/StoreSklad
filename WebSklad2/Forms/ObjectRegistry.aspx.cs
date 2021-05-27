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
    public partial class ObjectRegistry : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillNet();
                fillObject();
            }
        }

        protected void fillNet()
        {
            DropDownList1.Items.Clear();
            DataTable data = sql.getDataByQuery("SELECT Name_short FROM dbo.Net", false);
            for(int i =0; i<data.Rows.Count; i++)
            {
                DropDownList1.Items.Add(data.Rows[i][0].ToString());
            }
        }

        protected void fillObject()
        {
            DropDownList2.Items.Clear();
            DataTable data = sql.getDataByQuery("SELECT Name_object FROM dbo.Net_object WHERE dbo.Net_object.Net_ID_FK = (SELECT ID_net FROM dbo.Net WHERE Name_short ='" + DropDownList1.Text + "')", false);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DropDownList2.Items.Add(data.Rows[i][0].ToString());
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillObject();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            switch (DropDownList3.Text)
            {
                case "Реестр ПУ по ТП ПНР":
                    objectRegistryPNR();
                    break;
                case "Список ПУ для УСПД":
                    USPDList();
                    break;
            }


        }


        private void objectRegistryPNR()
        {
            //DataTable data = sql.GetDataBySP(new string[] { "spWEBGetObjectRegistry", "@Object", DropDownList2.Text }, true);
            //ExcelReport.ObjectRegistry(data, DropDownList2.Text);
            //sendFile("Реестр " + DropDownList2.Text + ".xlsx", @"C:\WEB\Reports\Registry.xlsx");
            

            if (CheckBox1.Checked)
            {
                string[] objects = new string[DropDownList2.Items.Count];
                int i = 0;

                foreach (System.Web.UI.WebControls.ListItem item in DropDownList2.Items)
                {
                    objects[i] = item.Text;
                    i++;
                }

                i = 0;
                DataTable[] data = new DataTable[DropDownList2.Items.Count];
                foreach (string s in objects)
                {
                    if (s != null) 
                    {
                        data[i] = sql.GetDataBySP(new string[] { "spWEBGetObjectRegistry", "@Object", s }, true);
                        i++;
                    }
                }
                ExcelReport.ObjectRegistry(data, objects, DropDownList1.Text);
                sendFile("Реестр " + DropDownList1.Text + ".xlsx", @"C:\WEB\Reports\Registry.xlsx");
            }
            else
            {
                DataTable data = sql.GetDataBySP(new string[] { "spWEBGetObjectRegistry", "@Object", DropDownList2.Text }, true);
                ExcelReport.ObjectRegistry(data, DropDownList2.Text);
                sendFile("Реестр " + DropDownList2.Text + ".xlsx", @"C:\WEB\Reports\Registry.xlsx");
            }

        }

        private void USPDList()
        {
            
            DataTable data;
            data = sql.GetDataBySP(new string[] { "spWEBuspdList", "@Object", DropDownList2.Text }, false);
            ExcelReport.SimoleRepot(data, DropDownList2.Text);
            sendFile(DropDownList2.Text + ".xlsx", @"C:\Web\Reports" + DropDownList2.Text + ".xlsx");

        }

        private void sendFile(string fileName,string path)
        {
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition",
               string.Format("attachment; filename={0}", fileName));
            Response.TransmitFile(path);
            Response.End();
        }
    }
}