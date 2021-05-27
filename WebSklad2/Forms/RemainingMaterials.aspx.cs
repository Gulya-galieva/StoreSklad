using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Windows.Forms;

namespace WebSklad2.Forms
{
    public partial class RemainingMaterials : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        int mode = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillMaterialsRemainings();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FillMaterialsRemainings();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FillDeviceRemainings();
        }

        protected void FillMaterialsRemainings ()
        {
            Label1.Text = "Остаток материалов на " + DateTime.Now.ToShortDateString();
            GridView1.DataSource = sql.GetDataBySP(new string[] { "spWEBmaterialRemainings" },true);
           GridView1.DataBind();
        }

        protected void FillDeviceRemainings()
        {
            Label1.Text = "Остаток оборудования на " + DateTime.Now.ToShortDateString();
            GridView1.DataSource = sql.GetDataBySP(new string[] { "spWEBdeviceRemainings" }, true);
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label1.Text = "Остаток материалов на " + TextBox1.Text;
            GridView1.DataSource = sql.GetDataBySP(new string[] { "spWEBmaterialRemainingsBYdate", "@Date", sql.parseString(TextBox1.Text)[0] }, true);
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Label1.Text.StartsWith("Остаток материалов"))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    double Volume;
                    double Min;
                    double.TryParse(e.Row.Cells[2].Text.Replace('.', ','), out Volume);
                    double.TryParse(e.Row.Cells[4].Text.Replace('.', ','), out Min);
                    //MessageBox.Show(currentVolume);
                    // MessageBox.Show(currentVolume.Length.ToString());
                    if (Volume < Min)
                    {
                        e.Row.BackColor = Color.BlanchedAlmond;
                    }
                }
            }
        }
    }
}