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
    public partial class DefectList : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable data = sql.GetDataBySP(new string[] { "spWEBGetDefectList" }, true);
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataTable data = sql.GetDataBySP(new string[] { "spWEBGetDefectList" }, true);
            ExcelReport.DefectList(data);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition",
               string.Format("attachment; filename={0}", @"C:\\WEB\Reports\Defects.xlsx"));
            Response.TransmitFile(@"C:\\WEB\Reports\Defects.xlsx");
            Response.End();
        }
    }
}