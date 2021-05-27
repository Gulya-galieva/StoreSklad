using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSklad2.Classes;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data;
using System.Text;

namespace WebSklad2.Forms.Statistics
{
    public partial class StatCES : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        int totalcount = 14281;
        double recived = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = totalcount.ToString();
           
            PU();
            ProgrammedPU();
            AssembledPU();
            DileveredPU();
            MountedPU();
            DefectPU();
            Totalcount();
        }
        
        protected void PU()
        {
            recived = Convert.ToDouble(sql.getValue("spWEBGetDeviceCount"));
            Label1.Text = recived.ToString();
            if(recived != 0)
                Label2.Text = ( (double)(recived/totalcount) * 100).ToString().Substring(0,5) + " %";
        }

        protected void ProgrammedPU()
        {
            double count = Convert.ToDouble(sql.getValue("spWEBGetProgrammedCount"));
            Label4.Text = count.ToString();
            if (count != 0)
                Label6.Text = ((double)(count / recived) * 100).ToString().Substring(0, 5) + " %";
        }

        protected void AssembledPU()
        {
            double count = Convert.ToDouble(sql.getValue("spWEBGetAssembledCount"));
            Label8.Text = Label4.Text;
            Label7.Text = count.ToString();
            if (count != 0)
                Label9.Text = ((double)(count / recived) * 100).ToString().Substring(0, 5) + " %";
        }

        protected void DileveredPU()
        {
            double count = Convert.ToDouble(sql.getValue("spWEBGetDeliveredCount"));
            Label11.Text = Label7.Text;
            Label10.Text = count.ToString();
            if (count != 0)
                Label12.Text = ((double)(count / recived) * 100).ToString().Substring(0, 5) + " %";
        }

        protected void MountedPU()
        {
            double count = Convert.ToDouble(sql.getValue("spWEBGetMountedCount"));
            Label14.Text = Label10.Text;
            Label13.Text = count.ToString();
            if (count != 0)
                Label15.Text = ((double)(count / recived) * 100).ToString().Substring(0, 5) + " %";
        }

        protected void DefectPU()
        {
            double count = Convert.ToDouble(sql.getValue("spWEBGetDefectCount"));
            Label16.Text = count.ToString();
            Label17.Text = Label4.Text;
            if (count != 0)
                Label18.Text = ((double)(count / recived) * 100).ToString().Substring(0, 5) + " %";
        }

        protected void Totalcount()
        {
            Label5.Text = recived.ToString();
            //Label8.Text = recived.ToString();
            //Label11.Text = recived.ToString();
            //Label14.Text = recived.ToString();
            //Label17.Text = recived.ToString();

        }

    }
}
