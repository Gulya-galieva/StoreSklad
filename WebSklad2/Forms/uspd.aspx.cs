using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebSklad2.Forms
{
    public partial class uspd : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillNet();
                fillObject();
                fillSerial();
               
            }
        }

        protected void fillNet()
        {
            DropDownList1.Items.Clear();
            DataTable data = sql.getDataByQuery("SELECT Name_short FROM dbo.Net", false);
            for (int i = 0; i < data.Rows.Count; i++)
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

        protected void fillSerial ()
        {
            DropDownList3.Items.Clear();
            DataTable data = sql.getDataByQuery("SELECT Serial_number FROM dbo.Device WHERE Serial_Number LIKE '009629%' ORDER BY Serial_number", false);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DropDownList3.Items.Add(data.Rows[i][0].ToString());
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillObject();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            sql.GetDataBySP(new string[] { "spWEBLinkDeviceUSPD", "@Net", DropDownList1.Text, "@Object", DropDownList2.Text, "@Serial", DropDownList3.Text}, false);
        }
    }
}