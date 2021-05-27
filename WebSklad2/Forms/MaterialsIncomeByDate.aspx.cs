using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace WebSklad2.Forms
{
    public partial class MaterialsIncomeByDate : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            string[] date = sql.parseString(TextBox1.Text);
            //MessageBox.Show(date[0]+ Environment.NewLine + date[1]);
            GridView1.DataSource = sql.GetDataBySP(new string[] { "spWEBmaterilaIncomeBYdates", "@FirstDate", date[0], "@LastDate", date[1]}, true);
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                if (date[1] != string.Empty)
                    Label1.Text = "Поступление материалов с " + TextBox1.Text.Substring(0, 10) + " по " + TextBox1.Text.Substring(13);
                else
                    Label1.Text = "Поступление материалов " + TextBox1.Text.Substring(0, 10);
            }

            else
            {
                if (date[1] != string.Empty)
                    Label1.Text = "Поступления материалов с " + TextBox1.Text.Substring(0, 10) + " по " + TextBox1.Text.Substring(13) + " не было";
                else
                    Label1.Text = "Поступление материалов " + TextBox1.Text.Substring(0, 10) + " не было";
            } 
        }
    }
}