using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClosedXML.Excel;
using System.Drawing;

namespace WebSklad2.Forms.Statistics
{
    public partial class StatUGES : System.Web.UI.Page
    {
        sqlRead sql = new sqlRead();
        DataTable data;
        DataTable data1;
        DataTable data2;
        DataTable data3;
        DataTable data4;
        DataTable data5;
        DataTable data6;
        DataTable data7;
        DataTable data8;
        DataTable data9;
        DataTable data10;
        DataTable data11;
        DataTable data12;
        DataTable data13;
        DataTable data14;
        DataTable data15;
        DataTable data16;
        DataTable data17;
        DataTable data18;
        DataTable data19;
        DataTable data20;
        DataTable data21;
        DataTable data22;
        DataTable data23;
        DataTable data24;
        DataTable data25;
        DataTable data26;
        DataTable data27;
        DataTable data28;
        DataTable data29;

        protected void Page_Load(object sender, EventArgs e)
        {
           // sql.openConnection();
            stats();
        }
        protected void Button_stats_Click(object sender, EventArgs e)
        {
            stats();
        }

        protected void Button_xlc_Click(object sender, EventArgs e)
        {

            using (var workbook = new XLWorkbook())  //@"D:\reports\Templates\deviceMoving.xlsm")
            {
                stats();
                workbook.Worksheets.Add(data, "Лист1");
                workbook.Worksheet(1).Row(1).InsertRowsAbove(3);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    switch (GridView1.Rows[i].Cells[0].Text.ToString())
                    {
                        case "1. Поступило на склад                                                      ":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.1. Возвращено в Башкирэнерго, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.2. Итого поступило на склад, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.3. Остаток на складе, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.4. Счетчиков выдано в работу, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.5. Бракованных счетчиков, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.6. Демонтированных счетчиков, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "2. Количество точек учета в БД по РЭС, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "3. Количество объектов в БД, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "4. Установлено точек учета, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "5. Акты допуска, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "6. Распечатано в ПО &quot;УГЭС&quot; (ком, тех):":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "7. Передано в ПО &quot;УГЭС&quot; на бумажном носителе (ком, тех):":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                    }
                }
                workbook.Worksheet(1).Cell(1, 1).Value = "Договор подряда №РЭС-1.16.3-Д-03206 от 17.05.2017г.";
                workbook.Worksheet(1).Cell(1, 2).Value = "Дата печати:";
                workbook.Worksheet(1).Cell(1, 3).Value = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                workbook.Worksheet(1).Column(1).AdjustToContents();
                workbook.Worksheet(1).Column(2).AdjustToContents();
                workbook.Worksheet(1).Column(3).AdjustToContents();

                workbook.SaveAs(@"D:\stats.xlsx");
            }
            string fileName = string.Format(@"D:\stats.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
            Response.TransmitFile(fileName);
            Response.End();
        }

        protected void stats()
        {
            string type = "";
            int count = 0;
            string direction = "";
            //sql.openConnection();

            //Итого поступило
            data = sql.getDataByQuery("SELECT '1. Поступило на склад                                                      ' AS 'Название параметра', " +
                               "COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device",false);
            int cnt = Convert.ToInt32(data.Rows[0][1].ToString());
            foreach (DataRow r in data.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            //Возвращено в Башкирэнерго
            data1 = sql.getDataByQuery("SELECT '1.1. Возвращено в Башкирэнерго, шт.:' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device, " +
                                  "[REG2].[dbo].Reg_device_delivery, " +
                                  "[REG2].[dbo].Delivery_act, " +
                                  "[REG2].[dbo].Reg_device_type, " +
                                  "[REG2].[dbo].Worker " +
                                  "WHERE Reg_device.ID = Reg_device_delivery.Reg_device_ID_FK " +
                                  "AND Delivery_act.ID = Reg_device_delivery.Delivery_act_ID_FK " +
                                  "AND Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                  "AND Worker.ID = Delivery_act.Worker_ID_FK " +
                                  "AND Worker.ID = 106", false);
            int over = Convert.ToInt32(data1.Rows[0][1].ToString());
            foreach (DataRow r in data1.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data1, false, MissingSchemaAction.Add);
            //Возвращено в Башкирэнерго по типам
            data2 = sql.getDataByQuery("SELECT Reg_device_type.Name  AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Reg_device, " +
                                "[REG2].[dbo].Reg_device_delivery, " +
                                "[REG2].[dbo].Delivery_act, " +
                                "[REG2].[dbo].Reg_device_type, " +
                                "[REG2].[dbo].Worker " +
                                "WHERE Reg_device.ID = Reg_device_delivery.Reg_device_ID_FK " +
                                "AND Delivery_act.ID = Reg_device_delivery.Delivery_act_ID_FK " +
                                "AND Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                "AND Worker.ID = Delivery_act.Worker_ID_FK " +
                                "AND Worker.ID = 106 " +
                                "GROUP BY Reg_device_type.Name ORDER BY Reg_device_type.Name", false);
            foreach (DataRow r in data1.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data2, false, MissingSchemaAction.Add);
            //Итого принято на склад
            int balance = cnt - over;
            data.Rows.Add(new object[] { "1.2. Итого поступило на склад, шт.:", balance, direction });
            //Итого принято на склад по типам
            data3 = sql.getDataByQuery("SELECT s1.name AS 'Название параметра', " +
                                "CASE WHEN s1.cnt - s2.cnt is NULL THEN s1.cnt ELSE s1.cnt - s2.cnt END 'Количество', ' ' AS 'Примечание' FROM " +
                                "(SELECT Reg_device_type.Name AS name, COUNT(*) AS cnt FROM[REG2].[dbo].Reg_device, [REG2].[dbo].Reg_device_type " +
                                "WHERE Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                "GROUP BY Reg_device_type.Name) s1 " +
                                "LEFT JOIN " +
                                "(SELECT Reg_device_type.Name AS name, COUNT(*) AS cnt " +
                                "FROM[REG2].[dbo].Reg_device, " +
                                "[REG2].[dbo].Reg_device_delivery, " +
                                "[REG2].[dbo].Delivery_act, " +
                                "[REG2].[dbo].Reg_device_type, " +
                                "[REG2].[dbo].Worker " +
                                "WHERE Reg_device.ID = Reg_device_delivery.Reg_device_ID_FK " +
                                "AND Delivery_act.ID = Reg_device_delivery.Delivery_act_ID_FK " +
                                "AND Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                "AND Worker.ID = Delivery_act.Worker_ID_FK " +
                                "AND Worker.ID = 106 " +
                                "GROUP BY Reg_device_type.Name) s2 " +
                                "ON s1.name = s2.name ORDER BY s1.name", false);
            foreach (DataRow r in data3.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data3, false, MissingSchemaAction.Add);
            //Остаток на складе
            data4 = sql.getDataByQuery("SELECT '1.3. Остаток на складе, шт.:' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device " +
                                "WHERE Reg_device.State = 'На складе'", false);
            foreach (DataRow r in data4.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data4, false, MissingSchemaAction.Add);
            //Остаток на складе по типам
            data5 = sql.getDataByQuery("SELECT Reg_device_type.Name AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device, [REG2].[dbo].Reg_device_type " +
                                "WHERE Reg_device.Reg_device_type_ID_FK = Reg_device_type.ID AND State = 'На складе' GROUP BY Reg_device_type.Name ORDER BY Reg_device_type.Name", false);
            foreach (DataRow r in data5.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data5, false, MissingSchemaAction.Add);
            //Выдано в работу
            data6 = sql.getDataByQuery("SELECT '1.4. Счетчиков выдано в работу, шт.:' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device " +
                                "WHERE Reg_device.State = 'выдан подрядчику'", false);
            foreach (DataRow r in data6.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data6, false, MissingSchemaAction.Add);
            //Выдано в работу по типу
            data7 = sql.getDataByQuery("SELECT Reg_device_type.Name AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device, [REG2].[dbo].Reg_device_type " +
                                "WHERE Reg_device.Reg_device_type_ID_FK = Reg_device_type.ID AND State = 'выдан подрядчику' GROUP BY Reg_device_type.Name ORDER BY Reg_device_type.Name", false);
            foreach (DataRow r in data7.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data7, false, MissingSchemaAction.Add);
            //Бракованные
            data8 = sql.getDataByQuery("SELECT '1.5. Бракованных счетчиков, шт.:' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device " +
                                "WHERE Reg_device.State = 'Брак'", false);
            foreach (DataRow r in data8.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data8, false, MissingSchemaAction.Add);
            //Бракованные по типу
            data9 = sql.getDataByQuery("SELECT Reg_device_type.Name AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device, [REG2].[dbo].Reg_device_type " +
                                "WHERE Reg_device.Reg_device_type_ID_FK = Reg_device_type.ID AND State = 'Брак' GROUP BY Reg_device_type.Name ORDER BY Reg_device_type.Name", false);
            foreach (DataRow r in data9.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data9, false, MissingSchemaAction.Add);
            //Демонтированные счетчики
            data10 = sql.getDataByQuery("SELECT '1.6. Демонтированных счетчиков, шт.:' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device " +
                                "WHERE Reg_device.State = 'демонтирован'", false);
            foreach (DataRow r in data10.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data10, false, MissingSchemaAction.Add);
            //Демонтированные счетчики по типу
            data11 = sql.getDataByQuery("SELECT Reg_device_type.Name AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Reg_device, [REG2].[dbo].Reg_device_type " +
                                "WHERE Reg_device.Reg_device_type_ID_FK = Reg_device_type.ID AND State = 'демонтирован' GROUP BY Reg_device_type.Name ORDER BY Reg_device_type.Name", false);
            foreach (DataRow r in data11.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data11, false, MissingSchemaAction.Add);

            //Количество точек учета в БД
            data12 = sql.getDataByQuery("WITH Act_info_table AS (" +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY[REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, " +
                                "(SELECT Name_short FROM REG2.dbo.Net_object, REG2.dbo.Net WHERE ID_net = Net_ID_FK and ID_object = Object_ID_FK) AS net_name, * " +
                                "FROM[REG2].[dbo].[Reg_point], " +
                                "[REG2].[dbo].[Install_act], " +
                                "[REG2].[dbo].[Letter], " +
                                "[REG2].[dbo].[Substation] " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK ) " +
                                "SELECT '2. Количество точек учета в БД по РЭС, шт.:' AS 'Название параметра', COUNT(RowNumber) AS 'Количество', ' ' AS 'Примечание' FROM Act_info_table", false);
            foreach (DataRow r in data12.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data12,false, MissingSchemaAction.Add);
            //Количество точек учета в БД по РЭС
            data13 = sql.getDataByQuery("WITH Act_info_table AS (" +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY[REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, " +
                                "(SELECT Name_short FROM REG2.dbo.Net_object, REG2.dbo.Net WHERE ID_net = Net_ID_FK and ID_object = Object_ID_FK) AS net_name, * " +
                                "FROM[REG2].[dbo].[Reg_point], " +
                                "[REG2].[dbo].[Install_act], " +
                                "[REG2].[dbo].[Letter], " +
                                "[REG2].[dbo].[Substation] " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK ) " +
                                "SELECT net_name AS 'Название параметра', COUNT(RowNumber) AS 'Количество', '' AS 'Примечание' FROM Act_info_table WHERE net_name != 'NULL' GROUP BY net_name ORDER BY net_name", false);
            foreach (DataRow r in data13.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data13, true, MissingSchemaAction.Add);
            
            //Количество объектов в БД
            data14 = sql.getDataByQuery("SELECT '3. Количество объектов в БД, шт.:' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Net_object, [REG2].[dbo].Net WHERE ID_net = Net_ID_FK", false);
            foreach (DataRow r in data14.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data14, false, MissingSchemaAction.Add);
            //Количество объектов в БД по РЭС
            data15 = sql.getDataByQuery("SELECT Name_short AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' FROM [REG2].[dbo].Net_object, [REG2].[dbo].Net " +
                                "WHERE ID_net = Net_ID_FK GROUP BY Name_short ORDER BY Name_short", false);
            foreach (DataRow r in data15.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data15, false, MissingSchemaAction.Add);

            //Установлено точек учета
            data14 = sql.getDataByQuery("WITH Act_info_table AS (" +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY [REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, " +
                                "(SELECT Name FROM REG2.dbo.Reg_device_type, REG2.dbo.Reg_device WHERE Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK AND REG2.dbo.Reg_device.ID = Reg_device_ID_FK) AS Name_type_PU " +
                                "FROM [REG2].[dbo].[Reg_point], " +
                                "[REG2].[dbo].[Install_act], " +
                                "[REG2].[dbo].[Letter], " +
                                "[REG2].[dbo].[Substation] " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK) " +
                                "SELECT '4. Установлено точек учета, шт.:' AS 'Название параметра', COUNT(RowNumber) AS 'Количество', ' ' AS 'Примечание' FROM Act_info_table", false);
            foreach (DataRow r in data14.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data14, false, MissingSchemaAction.Add);
            //Установлено точек учета по типам
            data15 = sql.getDataByQuery("WITH Act_info_table AS (" +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY [REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, Reg_point.Exsist_reg_device, " +
                                "(SELECT Name FROM REG2.dbo.Reg_device_type, REG2.dbo.Reg_device WHERE Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK AND REG2.dbo.Reg_device.ID = Reg_device_ID_FK) AS Name_type_PU " +
                                "FROM [REG2].[dbo].[Reg_point], " +
                                "[REG2].[dbo].[Install_act], " +
                                "[REG2].[dbo].[Letter], " +
                                "[REG2].[dbo].[Substation] " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK) " +
                                "SELECT CASE WHEN Name_type_PU is not NULL THEN Name_type_PU " +
                                "WHEN Name_type_PU is NULL AND Exsist_reg_device = 1 THEN 'Существующий' " +
                                "WHEN Name_type_PU is NULL AND Exsist_reg_device = 0 THEN 'Отсутствует в БД' END 'Название параметра', " +
                                "COUNT(RowNumber) AS 'Количество', '' AS 'Примечание' FROM Act_info_table GROUP BY Name_type_PU, Exsist_reg_device ORDER BY Name_type_PU", false);
            foreach (DataRow r in data15.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data15, false, MissingSchemaAction.Add);

            //Акты допуска
            data.Rows.Add(new object[] { "5. Акты допуска, шт.:", null, " " });
            //Отсутствуют данные в полном объеме по потребителям ком на ВЛ
            data16 = sql.getDataByQuery("SELECT '5.1. Отсутствуют данные в полном объеме по потребителям на ВЛ (ком/тех):' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Reg_point, [REG2].[dbo].Letter, [REG2].[dbo].Install_act, [REG2].[dbo].Substation " +
                                "WHERE Reg_point.Install_act_ID_FK = Install_act.ID_act and Reg_point.Letter_ID_FK = Letter.ID_letter and Substation.ID_substation = Reg_point.Substation_ID_FK " +
                                "AND Import = 0 AND Reg_point.Install_place like 'ВЛ%' AND (Reg_point.Type = 'ком' OR Reg_point.Type = '' OR Reg_point.Type is NULL)", false);
            foreach (DataRow r in data16.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data16, false, MissingSchemaAction.Add);
            //Отсутствуют данные в полном объеме по потребителям ком на РУ
            data17 = sql.getDataByQuery("SELECT '5.2. Отсутствуют данные в полном объеме по потребителям на РУ (ком/тех):' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Reg_point, [REG2].[dbo].Letter, [REG2].[dbo].Install_act, [REG2].[dbo].Substation " +
                                "WHERE Reg_point.Install_act_ID_FK = Install_act.ID_act and Reg_point.Letter_ID_FK = Letter.ID_letter and Substation.ID_substation = Reg_point.Substation_ID_FK " +
                                "AND Import = 0 AND Reg_point.Install_place not like 'ВЛ%' AND (Reg_point.Type = 'ком' OR Reg_point.Type = '' OR Reg_point.Type is NULL)", false);
            foreach (DataRow r in data17.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data17, false, MissingSchemaAction.Add);
            //Получено данных в полном объеме на потребителя ком
            data18 = sql.getDataByQuery("SELECT '5.3. Получено данных в полном объеме на потребителя (ком):' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Reg_point, [REG2].[dbo].Letter, [REG2].[dbo].Install_act, [REG2].[dbo].Substation " +
                                "WHERE Reg_point.Install_act_ID_FK = Install_act.ID_act and Reg_point.Letter_ID_FK = Letter.ID_letter and Substation.ID_substation = Reg_point.Substation_ID_FK " +
                                "AND Import = 1 AND Reg_point.Type = 'ком'", false);
            foreach (DataRow r in data18.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data18, false, MissingSchemaAction.Add);
            //Получено данных в полном объеме на потребителя тех
            data19 = sql.getDataByQuery("SELECT '5.4. Получено данных в полном объеме на потребителя (тех):' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Reg_point, [REG2].[dbo].Letter, [REG2].[dbo].Install_act, [REG2].[dbo].Substation " +
                                "WHERE Reg_point.Install_act_ID_FK = Install_act.ID_act and Reg_point.Letter_ID_FK = Letter.ID_letter and Substation.ID_substation = Reg_point.Substation_ID_FK " +
                                "AND Reg_point.Type = 'тех'", false);
            foreach (DataRow r in data19.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data19, false, MissingSchemaAction.Add);
            //Отправлено уведомлений
            data20 = sql.getDataByQuery("SELECT '5.5. Отправлено уведомлений (ком):' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Letter, [REG2].[dbo].Reg_point WHERE Reg_point.Letter_ID_FK = Letter.ID_Letter AND Letter.Printed_letter = 1", false);
            foreach (DataRow r in data20.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data20, false, MissingSchemaAction.Add);
            //Получено уведомлений
            data21 = sql.getDataByQuery("SELECT '5.6. Получено уведомлений (ком):' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Letter, [REG2].[dbo].Reg_point WHERE Reg_point.Letter_ID_FK = Letter.ID_Letter AND Letter.Notification_state  =  'Доставлено'", false);
            foreach (DataRow r in data21.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data21, false, MissingSchemaAction.Add);

            //Распечатано в ПО "УГЭС"
            data22 = sql.getDataByQuery("SELECT '6. Распечатано в ПО \"УГЭС\" (ком, тех):' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Reg_point WHERE Reg_point.Printed = 1 OR Reg_point.Sent = 1 OR Reg_point.Accepted = 1", false);
            foreach (DataRow r in data22.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data22, false, MissingSchemaAction.Add);
            //Распечатано в ПО "УГЭС" (тех)
            data23 = sql.getDataByQuery("WITH Act_info_table AS ( " +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY[REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, " +
                                "(SELECT Name FROM REG2.dbo.Reg_device_type, REG2.dbo.Reg_device WHERE Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                "AND REG2.dbo.Reg_device.ID = Reg_device_ID_FK) AS Name_type_PU " +
                                "FROM [REG2].[dbo].Reg_point, " +
                                "[REG2].[dbo].Install_act, " +
                                "[REG2].[dbo].Letter, " +
                                "[REG2].[dbo].Substation " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK and " +
                                "Reg_point.Type = 'тех' and " +
                                "(Reg_point.Printed = 1 OR Reg_point.Sent = 1 OR Reg_point.Accepted = 1)) " +
                                "SELECT Name_type_PU + ' (тех)' AS 'Название параметра', COUNT(RowNumber) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM Act_info_table WHERE Name_type_PU = 'CE303 S31 543-JAVZ(12)' GROUP BY Name_type_PU", false);
            int teh = Convert.ToInt32(data23.Rows[0][1]);
            foreach (DataRow r in data23.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data23, false, MissingSchemaAction.Add);
            //Распечатано в ПО "УГЭС" (ком)
            data24 = sql.getDataByQuery("WITH Act_info_table AS ( " +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY[REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, " +
                                "(SELECT Name FROM REG2.dbo.Reg_device_type, REG2.dbo.Reg_device WHERE Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                "AND REG2.dbo.Reg_device.ID = Reg_device_ID_FK) AS Name_type_PU " +
                                "FROM [REG2].[dbo].Reg_point, " +
                                "[REG2].[dbo].Install_act, " +
                                "[REG2].[dbo].Letter, " +
                                "[REG2].[dbo].Substation " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK and " +
                                "Reg_point.Type != 'тех' and " +
                                "(Reg_point.Printed = 1 OR Reg_point.Sent = 1 OR Reg_point.Accepted = 1)) " +
                                "SELECT Name_type_PU + ' (ком)' AS 'Название параметра', COUNT(RowNumber) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM Act_info_table WHERE Name_type_PU = 'CE303 S31 543-JAVZ(12)' GROUP BY Name_type_PU", false);
            int kom = Convert.ToInt32(data24.Rows[0][1]);
            foreach (DataRow r in data24.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data24, false, MissingSchemaAction.Add);
            //Распечатано в ПО "УГЭС" по типам
            data25 = sql.getDataByQuery("WITH Act_info_table AS ( " +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY[REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, " +
                                "(SELECT Name FROM REG2.dbo.Reg_device_type, REG2.dbo.Reg_device WHERE Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                "AND REG2.dbo.Reg_device.ID = Reg_device_ID_FK) AS Name_type_PU " +
                                "FROM [REG2].[dbo].Reg_point, " +
                                "[REG2].[dbo].Install_act, " +
                                "[REG2].[dbo].Letter, " +
                                "[REG2].[dbo].Substation " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK and " +
                                "(Reg_point.Printed = 1 OR Reg_point.Sent = 1 OR Reg_point.Accepted = 1)) " +
                                "SELECT CASE WHEN Name_type_PU is not NULL THEN Name_type_PU  " +
                                "WHEN Name_type_PU is NULL THEN 'Существующий' END 'Название параметра', COUNT(RowNumber) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM Act_info_table WHERE (Name_type_PU != 'CE303 S31 543-JAVZ(12)' OR Name_type_PU is NULL) GROUP BY Name_type_PU ORDER BY Name_type_PU", false);
            int exist = Convert.ToInt32(data25.Rows[0][1]);
            foreach (DataRow r in data25.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data25, false, MissingSchemaAction.Add);

            //Передано в ПО "УГЭС" на бумажном носителе
            data26 = sql.getDataByQuery("SELECT '7. Передано в ПО \"УГЭС\" на бумажном носителе (ком, тех):' AS 'Название параметра', COUNT(*) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM [REG2].[dbo].Reg_point WHERE Reg_point.Sent_paper = 1", false);
            int sent = teh + kom + exist + Convert.ToInt32(data26.Rows[0][1]);
            data.Rows.Add(new object[] { "7. Передано в ПО \"УГЭС\" на бумажном носителе (ком, тех):", sent, " " });
            //Передано в ПО "УГЭС" на бумажном носителе (тех)
            data.Rows.Add(new object[] { "CE303 S31 543-JAVZ(12) (тех)", teh, " " });
            //Передано в ПО "УГЭС" на бумажном носителе (ком)
            data28 = sql.getDataByQuery("WITH Act_info_table AS ( " +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY[REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, " +
                                "(SELECT Name FROM REG2.dbo.Reg_device_type, REG2.dbo.Reg_device WHERE Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                "AND REG2.dbo.Reg_device.ID = Reg_device_ID_FK) AS Name_type_PU " +
                                "FROM [REG2].[dbo].Reg_point, " +
                                "[REG2].[dbo].Install_act, " +
                                "[REG2].[dbo].Letter, " +
                                "[REG2].[dbo].Substation " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK and " +
                                "Reg_point.Type != 'тех' and " +
                                "Reg_point.Sent_paper = 1) " +
                                "SELECT Name_type_PU + ' (ком)' AS 'Название параметра', COUNT(RowNumber) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM Act_info_table WHERE Name_type_PU = 'CE303 S31 543-JAVZ(12)' GROUP BY Name_type_PU", false);
            int kom2 = kom + Convert.ToInt32(data28.Rows[0][1]);
            data.Rows.Add(new object[] { "CE303 S31 543-JAVZ(12) (ком)", kom2, " " });
            //Передано в ПО "УГЭС" на бумажном носителе по типам
            data29 = sql.getDataByQuery("WITH Act_info_table AS ( " +
                                "SELECT  ROW_NUMBER() OVER(ORDER BY[REG2].[dbo].Reg_point.ID_reg_point) AS RowNumber, " +
                                "(SELECT Name FROM REG2.dbo.Reg_device_type, REG2.dbo.Reg_device WHERE Reg_device_type.ID = Reg_device.Reg_device_type_ID_FK " +
                                "AND REG2.dbo.Reg_device.ID = Reg_device_ID_FK) AS Name_type_PU " +
                                "FROM [REG2].[dbo].Reg_point, " +
                                "[REG2].[dbo].Install_act, " +
                                "[REG2].[dbo].Letter, " +
                                "[REG2].[dbo].Substation " +
                                "WHERE " +
                                "Reg_point.Install_act_ID_FK = Install_act.ID_act and " +
                                "Reg_point.Letter_ID_FK = Letter.ID_letter and " +
                                "Substation.ID_substation = Reg_point.Substation_ID_FK and " +
                                "Reg_point.Sent_paper = 1) " +
                                "SELECT Name_type_PU AS 'Название параметра', COUNT(RowNumber) AS 'Количество', ' ' AS 'Примечание' " +
                                "FROM Act_info_table WHERE Name_type_PU != 'CE303 S31 543-JAVZ(12)' AND Name_type_PU is not NULL GROUP BY Name_type_PU ORDER BY Name_type_PU", false);
            foreach (DataRow r in data29.Rows)
            {
                type = r[0].ToString();
                count = Convert.ToInt32(r[1]);
                direction = r[2].ToString();
            }
            data.Merge(data29, false, MissingSchemaAction.Add);
            //Передано в ПО "УГЭС" на бумажном носителе (существующие)
            data.Rows.Add(new object[] { "Существующий", exist, " " });

            //
            GridView1.DataSource = data;
            GridView1.DataBind();
            color_row(Color.LightGreen);
            Label1.Text = "Статистика 2017";
            Panel1.Visible = true;
        }

        //Покрасить последнюю строку
        void color_row(Color color)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                switch (GridView1.Rows[i].Cells[0].Text.ToString())
                {
                    case "1. Поступило на склад                                                      ":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "1.1. Возвращено в Башкирэнерго, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "1.2. Итого поступило на склад, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "1.3. Остаток на складе, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "1.4. Счетчиков выдано в работу, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "1.5. Бракованных счетчиков, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "1.6. Демонтированных счетчиков, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "2. Количество точек учета в БД по РЭС, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "3. Количество объектов в БД, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "4. Установлено точек учета, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "5. Акты допуска, шт.:":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "6. Распечатано в ПО &quot;УГЭС&quot; (ком, тех):":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                    case "7. Передано в ПО &quot;УГЭС&quot; на бумажном носителе (ком, тех):":
                        {
                            GridView1.Rows[i].BackColor = color;
                            break;
                        }
                }
            }
        }

        protected void Button_xlc_Click1(object sender, EventArgs e)
        {
            using (var workbook = new XLWorkbook())  //@"D:\reports\Templates\deviceMoving.xlsm")
            {
                stats();
                workbook.Worksheets.Add(data, "Лист1");
                workbook.Worksheet(1).Row(1).InsertRowsAbove(3);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    switch (GridView1.Rows[i].Cells[0].Text.ToString())
                    {
                        case "1. Поступило на склад                                                      ":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.1. Возвращено в Башкирэнерго, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.2. Итого поступило на склад, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.3. Остаток на складе, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.4. Счетчиков выдано в работу, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.5. Бракованных счетчиков, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "1.6. Демонтированных счетчиков, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "2. Количество точек учета в БД по РЭС, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "3. Количество объектов в БД, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "4. Установлено точек учета, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "5. Акты допуска, шт.:":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "6. Распечатано в ПО &quot;УГЭС&quot; (ком, тех):":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                        case "7. Передано в ПО &quot;УГЭС&quot; на бумажном носителе (ком, тех):":
                            {
                                workbook.Worksheet(1).Row(i + 5).Style.Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGreen);
                                break;
                            }
                    }
                }
                workbook.Worksheet(1).Cell(1, 1).Value = "Договор подряда №РЭС-1.16.3-Д-03206 от 17.05.2017г.";
                workbook.Worksheet(1).Cell(1, 2).Value = "Дата печати:";
                workbook.Worksheet(1).Cell(1, 3).Value = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                workbook.Worksheet(1).Column(1).AdjustToContents();
                workbook.Worksheet(1).Column(2).AdjustToContents();
                workbook.Worksheet(1).Column(3).AdjustToContents();

                workbook.SaveAs(@"D:\stats.xlsx");
            }
            string fileName = string.Format(@"D:\stats.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
            Response.TransmitFile(fileName);
            Response.End();
        }
    }
}
