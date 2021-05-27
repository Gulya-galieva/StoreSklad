using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClosedXML.Excel;
using System.Data;

namespace WebSklad2.Classes
{
    public static class ExcelReport
    {
        public static void makeKurReport(DataTable data, string worker, string date)
        {
            var wb = new XLWorkbook();
            data.Columns.Add("РЭС");
            data.Columns.Add("ТП/РП");
            data.Columns.Add("Нас. п.");
            data.Columns.Add("Улица");
            data.Columns.Add("Дом");
            data.Columns.Add("Корп.");
            data.Columns.Add("Кв.");
            data.Columns.Add("Куратор");
            data.Columns.Add("Подрядчик");
            data.Columns.Add("отв. за БД");
            var ws = wb.Worksheets.Add(data, "Лист1");
            ws.Row(1).InsertRowsAbove(4);
            ws.Cell(1, 6).Value = "Опись переданных отчетов";
            ws.Cell(2, 6).Value = "(таблиц)";
            ws.Cell(3, 1).Value = "Подрядчик";
            ws.Cell(3, 3).Value = worker;
            ws.Cell(3, 6).Value = "Куратор";
            ws.Cell(3, 7).Value = "Отв. за БД";
            ws.Range("K2:L2").Merge();
            ws.Range("K3:L3").Merge();
            ws.Cell(2, 11).Value = "Дата выдачи ПУ";
            ws.Cell(3, 11).Value = date;
            ws.Column(1).Width = 2.57;
            ws.Column(2).Width = 15;
            ws.Column(3).Width = 7;
            ws.Column(4).Width = 7;
            ws.Column(5).Width = 13;
            ws.Column(6).Width = 28;
            ws.Column(7).Width = 7;
            ws.Column(8).Width = 7;
            ws.Column(9).Width = 7;
            ws.Column(10).Width = 9;
            ws.Column(11).Width = 9;
            ws.Column(12).Width = 9;
            ws.Rows("4:1000").Height = 25;
            ws.Range("A4:L5").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Range("A6:L100").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Range("K2:L2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Range("K3:L3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Range("F1:F2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Range("A3:J3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            
            ws.Range("A1:L100").Style.Font.FontSize = 11;
            ws.Range("K2:L3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range("A6:L" + (data.Rows.Count + 5).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range("A6:L" + (data.Rows.Count + 5).ToString()).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.SetPagesWide(1);
            wb.SaveAs(@"C:\\WEB\Reports\kurator.xlsx");
            wb.Dispose();
            ws.Dispose();
        }

        public static void BaseWorkerReport (DataTable data)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(data, "Лист1");
            ws.Row(1).InsertRowsAbove(2);
            ws.Row(1).Cell(1).Value = "Сводный отчет по подрядчикам";
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.SetPagesWide(1);
            wb.SaveAs(@"C:\\WEB\Reports\base.xlsx");
            wb.Dispose();
            ws.Dispose();
        }
        public static void ShortWorkerReport(DataTable data, string worker)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(data, "Лист1");
            ws.Row(1).InsertRowsAbove(3);
            ws.Row(1).Cell(1).Value = "Краткий отчет по подрядчику";
            ws.Row(2).Cell(1).Value = "ФИО";
            ws.Row(2).Cell(2).Value = worker;
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.SetPagesWide(1);
            wb.SaveAs(@"C:\\WEB\Reports\short.xlsx");
            wb.Dispose();
            ws.Dispose();
        }
        public static void DefectList(DataTable data)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(data, "Лист1");
            ws.Row(1).InsertRowsAbove(3);
            ws.Row(1).Cell(1).Value = "Список бракованного оборудования";
            ws.Row(2).Cell(1).Value = "Дата формирования";
            ws.Row(2).Cell(3).Value = DateTime.Now.ToLongDateString();
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.SetPagesWide(1);
            wb.SaveAs(@"C:\\WEB\Reports\Defects.xlsx");
            wb.Dispose();
            ws.Dispose();
        }

        public static void ObjectRegistry(DataTable data, string obj)
        {
            var wb = new XLWorkbook(@"C:\\WEB\Blank\Реестр ТП.xlsx");
            var ws = wb.Worksheet(1);
            int row = 7;
            ws.Cell(2, 1).Value += obj;
            ws.Cell(3, 1).Value = "по договору № РЭС 11.16.7/Д-02663 от 30.05.2018г.";
            for (int i=0; i<data.Rows.Count; i++)
            {
                ws.Row(row).InsertRowsBelow(1);
                ws.Cell(row, 1).Value = data.Rows[i][0].ToString();
                if (data.Rows[i][1].ToString() != string.Empty)
                    ws.Cell(row, 2).Value += "ул. " + data.Rows[i][1].ToString() + " ";
                if (data.Rows[i][2].ToString() != string.Empty)
                    ws.Cell(row, 2).Value += "д. " + data.Rows[i][2].ToString() + " ";
                if (data.Rows[i][3].ToString() != string.Empty)
                    ws.Cell(row, 2).Value += "корп. " + data.Rows[i][3].ToString() + " ";
                if (data.Rows[i][4].ToString() != string.Empty)
                    ws.Cell(row, 2).Value += "кв. " + data.Rows[i][4].ToString();
                ws.Cell(row, 4).Value = data.Rows[i][5].ToString().Substring(0,5);
                ws.Cell(row, 7).Value ="'" + data.Rows[i][6].ToString();
                if (data.Rows[i][5].ToString().StartsWith("CE303 S31 543"))
                {
                    ws.Row(row).Cell(2).Value = "Ввод";
                    ws.Row(row).Cell(5).Value = "GSM";
                    ws.Row(row).Cell(2).Value += "    " + data.Rows[i][10].ToString();
                }
                if (data.Rows[i][5].ToString().StartsWith("CE303 S31 746") || data.Rows[i][5].ToString().StartsWith("CE208 S7") || data.Rows[i][5].ToString().StartsWith("CE303 S31 543"))
                {
                    ws.Row(row).Cell(5).Value = "GSM";
                    ws.Cell(row, 8).Value ="'" + data.Rows[i][7].ToString();
                }
                else
                {
                    ws.Row(row).Cell(5).Value = "PLC";
                    ws.Row(row).Cell(8).Value = data.Rows[i][6].ToString().Substring(10, 5);
                }
                ws.Row(row).Cell(6).Value = "Есть";
                ws.Row(row).Height = 22;
                
                row++;
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][8].ToString() != string.Empty && data.Rows[i][9].ToString() != string.Empty)
                {
                    ws.Cell(3, 1).Value = "в н.п. "+ data.Rows[i][8].ToString() + " ("+ data.Rows[i][9].ToString() + ") по договору № РЭС 11.16.7/Д-02663 от 30.05.2018г.";
                    break;
                }
            }
            ws.PageSetup.SetPagesWide(1);
            wb.SaveAs(@"C:\WEB\Reports\Registry.xlsx");
        }

        public static void ObjectRegistry(DataTable[] data, string[] obj, string net)
        {
            int j = 0;
            var wb = new XLWorkbook(@"C:\\WEB\Blank\Реестр ТП.xlsx");
            var wsTempalte = wb.Worksheet(1);
            var wbOut = new XLWorkbook();
            int count = 0;
            foreach (DataTable d in data)
            {
                //var ws = wb.Worksheet(j+1);
                //var ws = wbOut.Worksheets.Add(obj[j]);
                
                wsTempalte.CopyTo(wbOut, obj[j]);
                var ws = wbOut.Worksheet(obj[j]);
                int row = 7;
                ws.Cell(2, 1).Value += obj[j];
                ws.Cell(3, 1).Value = "по договору № РЭС 11.16.7/Д-02663 от 30.05.2018г.";
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    ws.Row(row).InsertRowsBelow(1);
                    ws.Cell(row, 1).Value = d.Rows[i][0].ToString();
                    if (d.Rows[i][1].ToString() != string.Empty)
                        ws.Cell(row, 2).Value += "ул. " + d.Rows[i][1].ToString() + " ";
                    if (d.Rows[i][2].ToString() != string.Empty)
                        ws.Cell(row, 2).Value += "д. " + d.Rows[i][2].ToString() + " ";
                    if (d.Rows[i][3].ToString() != string.Empty)
                        ws.Cell(row, 2).Value += "корп. " + d.Rows[i][3].ToString() + " ";
                    if (d.Rows[i][4].ToString() != string.Empty)
                        ws.Cell(row, 2).Value += "кв. " + d.Rows[i][4].ToString();
                    ws.Cell(row, 4).Value = d.Rows[i][5].ToString().Substring(0, 5);
                    ws.Cell(row, 7).Value = "'" + d.Rows[i][6].ToString();
                    if (d.Rows[i][5].ToString().StartsWith("CE303 S31 543"))
                    {
                        ws.Row(row).Cell(2).Value = "Ввод";
                        ws.Row(row).Cell(5).Value = "GSM";
                        ws.Row(row).Cell(2).Value += "    " + d.Rows[i][10].ToString();
                        count++;
                    }
                    if (d.Rows[i][5].ToString().StartsWith("CE303 S31 746") || d.Rows[i][5].ToString().StartsWith("CE208 S7") || d.Rows[i][5].ToString().StartsWith("CE303 S31 543"))
                    {
                        ws.Row(row).Cell(5).Value = "GSM";
                        ws.Cell(row, 8).Value = "'" + d.Rows[i][7].ToString();
                        count++;
                    }
                    else
                    {
                        ws.Row(row).Cell(5).Value = "PLC";
                        ws.Row(row).Cell(8).Value = d.Rows[i][6].ToString().Substring(10, 5);
                        count++;
                    }
                    ws.Row(row).Cell(6).Value = "Есть";
                    ws.Row(row).Height = 22;

                    row++;
                }
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    if (d.Rows[i][8].ToString() != string.Empty && d.Rows[i][9].ToString() != string.Empty)
                    {
                        ws.Cell(3, 1).Value = "в н.п. " + d.Rows[i][8].ToString() + " (" + d.Rows[i][9].ToString() + ") по договору № РЭС 11.16.7/Д-02663 от 30.05.2018г.";
                        break;
                    }
                }
                ws.PageSetup.SetPagesWide(1);
                j++;
            }
            var wss = wbOut.Worksheets.Add("Stat");
            wss.Row(1).Cell(1).Value = "Кол-во ПУ по РЭСу";
            wss.Row(1).Cell(3).Value = count.ToString();
            wss.Row(1).Cell(4).Value = "шт.";
            wbOut.SaveAs(@"C:\WEB\Reports\Registry.xlsx");
        }
        
        public static void SimoleRepot (DataTable data, string fileName)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Лист1");
            int i = 1;
            foreach(DataRow r in data.Rows)
            {
                int j = 1;

                foreach(DataColumn c in data.Columns)
                {
                    ws.Cell(i, j).Value = "'" + data.Rows[i - 1][j - 1].ToString();
                    ws.Column(j).AdjustToContents();
                    j++;
                }
                i++;
                
            }
            wb.SaveAs(@"C:\Web\Reports" + fileName + ".xlsx");

        }
    }
}