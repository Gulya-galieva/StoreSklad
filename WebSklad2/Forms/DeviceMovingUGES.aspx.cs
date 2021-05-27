﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

//using WebSklad2.Classes;

namespace WebSklad2.Forms
{
    public partial class DeviceMovingUGES : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable movingData;
            movingData = sql.GetDataBySPUGES(new string[] { "spWEBdeviceMovingUGES", "@SerialNumber", TextBox1.Text, "@DeviceType", DropDownList1.Text }, true);
            if (TextBox1.Text.Length == 15)
            {
                string model = sql.getValueUGES("SELECT Name FROM [REG2].[dbo].Reg_device_type WHERE Code = '" + TextBox1.Text.Substring(0, 6) + "'");
                Label1.Text = "Отчет по движению ПУ " + model + " № " + TextBox1.Text;
                DropDownList1.Text = model;
            }
            else
                Label1.Text = "Отчет по движению ПУ " + DropDownList1.Text + " № " + sql.getValueUGES("SELECT Code FROM [REG2].[dbo].Reg_device_type WHERE Name = '" + DropDownList1.Text + "'") + TextBox1.Text;
            
            GridView1.DataSource = movingData;
            GridView1.DataBind();
            
            if (GridView1.Rows.Count > 0)
            {
                Panel1.Visible = true;
                DataTable data = sql.GetDataBySPUGES(new string[] { "spWEBGetDeviceInstallAdressUGES", "@SerialNumber", TextBox1.Text, "@Model", DropDownList1.Text }, false);
                if (data.Rows.Count != 0)
                {
                    for (int i = 0; i<data.Rows.Count; i++)
                    {
                       for(int j=0; j<data.Columns.Count; j++)
                       {
                            if( data.Rows[i][j].ToString() == string.Empty)
                            {
                                data.Rows[i][j] = "---";
                            }
                       }
                    }

                    GridView2.DataSource = data;
                    GridView2.DataBind();
                    Panel2.Visible = true;
                    
                }
                string PhoneNumber = string.Empty;
                if (sql.GetDataBySPUGES(new string[] { "spWEBGetPhoneNumberBySerialUGES", "@SerialNumber", TextBox1.Text, "@Model", DropDownList1.Text }, false).Rows.Count > 0)
                    PhoneNumber = sql.GetDataBySPUGES(new string[] { "spWEBGetPhoneNumberBySerialUGES", "@SerialNumber", TextBox1.Text, "@Model", DropDownList1.Text }, false).Rows[0][0].ToString();
                if (PhoneNumber != string.Empty)
                    Label1.Text += " Номер сим: " + PhoneNumber;
            }
            else
                Panel3.Visible = true;
                Label4.Text = "ПУ № " + TextBox1.Text + " не найден в БД";
        }
      
    }
}