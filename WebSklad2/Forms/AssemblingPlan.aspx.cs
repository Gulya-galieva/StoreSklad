using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebSklad2.Forms
{
    public partial class AssemblingPlan : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToShortDateString();
            KDE1PLC();
            KDE1GSM();
            KDE3PLC();
            KDE3GSM();
            USPD_303();
            Vvod_303();
           
        }

        protected void KDE1PLC()
        {
            List<double> Materials = new List<double>();
            Materials.Add(GetPUcount(new List<string>{ "6", "11"}));
            Materials.AddRange(getSetList("КДЕ-1 PLC"));
            Label2.Text = Materials.Min().ToString();
            
        }

        protected void KDE1GSM()
        {
            List<double> Materials = new List<double>();
            Materials.Add(GetPUcount(new List<string> { "7" }));
            Materials.AddRange(getSetList("КДЕ-1 GSM"));
            Label3.Text = Materials.Min().ToString();
        }

        protected void KDE3PLC()
        {
            List<double> Materials = new List<double>();
            Materials.Add(GetPUcount(new List<string> { "12" }));
            Materials.AddRange(getSetList("КДЕ-3 PLC"));
            Label4.Text = Materials.Min().ToString();
        }

        protected void KDE3GSM()
        {
            List<double> Materials = new List<double>();
            Materials.Add(GetPUcount(new List<string> { "8" }));
            Materials.AddRange(getSetList("КДЕ-3 GSM"));
            Label5.Text = Materials.Min().ToString();
        }

        protected void USPD_303()
        {
            List<double> Materials = new List<double>();
            Materials.Add(GetPUcount(new List<string> { "5", "9", "10" }));
            Materials.AddRange(getSetList("Шкаф УСПД"));
            Label6.Text = Materials.Min().ToString();
        }

        protected void Vvod_303()
        {
            List<double> Materials = new List<double>();
            Materials.Add(GetPUcount(new List<string> { "5" }));
            Materials.AddRange(getSetList("Шкаф Ввод"));
            Label7.Text = Materials.Min().ToString();
        }

        protected double GetPUcount (List<string> TypeIDs)
        {
            double puCount = 0;
            foreach (string s in TypeIDs)
            {
                puCount += Convert.ToDouble((sql.GetDataBySP(new string[] { "spWEBGetDeviceCountBYtypeID", "@ID", s }, false)).Rows[0][0]);
            }
            return puCount;
        }

        protected List<double> getSetList (string SetName)
        {
            List<double> result = new List<double>();
            DataTable Set = sql.GetDataBySP(new string[] { "spGetSetContent", "@SetName", SetName }, false);
            for (int i = 0; i < Set.Rows.Count; i++)
            {
                double CurrentValue = Convert.ToDouble(sql.getValue("SELECT Volume FROM dbo.Material_type WHERE Name = '" + Set.Rows[i][0].ToString() + "'"));
                result.Add(Math.Truncate(CurrentValue / Convert.ToDouble(Set.Rows[i][2].ToString())));
            }
            return result;
        }
    }
}