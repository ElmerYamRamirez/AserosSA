using System;
using System.Collections.Generic;
using AserosSA.Reporte;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using OfficeOpenXml;

namespace AserosSA.Data
{
    public class Report : PageModel
    {
        public int ReporteId { get; set; }
        public string Articulo { get; set; }
        public string Marca { get; set; }
        public string Minimo { get; set; }
        public string Maximo { get; set; }
        public string PuntoReorden { get; set; }

        public void GeneratePDF(IJSRuntime js)
        {
            List<Report> oReports = new List<Report>();
            for(int i = 1; i<=9; i++)
            {
                oReports.Add(new Report()
                {
                    ReporteId = i,
                    Articulo = "FOCO LAMPARA FCM"+i,
                    Marca = "RAYOBAC"+i,
                    Minimo = "2"+1,
                    Maximo = "10"+i,
                    PuntoReorden = "10"+i
                });
            }
            RptExistenciasAlmacen oRptExistenciasAlmacen = new RptExistenciasAlmacen();
            js.InvokeAsync<Report>(
                "saveAsFile",
                "ReporteExistenciasAlmacen.pdf",
                Convert.ToBase64String(oRptExistenciasAlmacen.Report(oReports))
            );
        }

        public void GenerateExcel(IJSRuntime iJSRuntime)
        {
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("PuntoReorden");

                #region Header Row
                workSheet.Cells[1, 1].Value = "Articulo";
                workSheet.Cells[1, 1].Style.Font.Size = 12;
                workSheet.Cells[1, 1].Style.Font.Bold = true;
                workSheet.Cells[1, 1].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[1, 2].Value = "Minimo";
                workSheet.Cells[1, 2].Style.Font.Size = 12;
                workSheet.Cells[1, 2].Style.Font.Bold = true;
                workSheet.Cells[1, 2].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[1, 3].Value = "Maximo";
                workSheet.Cells[1, 3].Style.Font.Size = 12;
                workSheet.Cells[1, 3].Style.Font.Bold = true;
                workSheet.Cells[1, 3].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[1, 4].Value = "Punto reorden";
                workSheet.Cells[1, 4].Style.Font.Size = 12;
                workSheet.Cells[1, 4].Style.Font.Bold = true;
                workSheet.Cells[1, 4].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                #endregion

                #region Body 1st Row
                workSheet.Cells[2, 1].Value = "FOCO LAMPARA FCM";
                workSheet.Cells[2, 1].Style.Font.Size = 12;
                workSheet.Cells[2, 1].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[2, 2].Value = "2";
                workSheet.Cells[2, 2].Style.Font.Size = 12;
                workSheet.Cells[2, 2].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[2, 3].Value = "10";
                workSheet.Cells[2, 3].Style.Font.Size = 12;
                workSheet.Cells[2, 3].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[2, 4].Value = "3";
                workSheet.Cells[2, 4].Style.Font.Size = 12;
                workSheet.Cells[2, 4].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                #endregion

                #region Body 2nd Row
                workSheet.Cells[3, 1].Value = "PILA C";
                workSheet.Cells[3, 1].Style.Font.Size = 12;
                workSheet.Cells[3, 1].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[3, 2].Value = "2";
                workSheet.Cells[3, 2].Style.Font.Size = 12;
                workSheet.Cells[3, 2].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[3, 3].Value = "10";
                workSheet.Cells[3, 3].Style.Font.Size = 12;
                workSheet.Cells[3, 3].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                workSheet.Cells[3, 4].Value = "5";
                workSheet.Cells[3, 4].Style.Font.Size = 12;
                workSheet.Cells[3, 4].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

                #endregion

                fileContents = package.GetAsByteArray();
            }
            iJSRuntime.InvokeAsync<Report>(
                "saveAsFile",
                "Report Punto de Reorden.xlsx",
                Convert.ToBase64String(fileContents)
                );
        }
    }
}

