using System;
using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;

namespace Models
{
    class ReportModel
    {
        public int ReporteId { get; set; }
        public string Articulo { get; set; }
        public string Marca { get; set; }
        public string Minimo { get; set; }
        public string Maximo { get; set; }
        public string PuntoReorden { get; set; }

        public void GeneratePDF(IJSRuntime js)
        {
            List<ReportModel> oReports = new List<ReportModel>();
            for(int i = 1; i<=9; i++)
            {
                oReports.Add(new ReportModel()
                {
                    ReporteId = i,
                    Articulo = "FOCO LAMPARA FCM"+i,
                    Marca = "RAYOBAC"+i,
                    Minimo = "2"+1,
                    Maximo = "10"+i,
                    PuntoReorden = "10"+i
                });
                ;
            }
            /*RptExistenciasAlmacen oRptExistenciasAlmacen = new RptExistenciasAlmacen();
            js.InvokeAsync<ReportModel>(
                "saveAsFile",
                "ReporteExistenciasAlmacen.pdf",
                Convert.ToBase64String(oRptExistenciasAlmacen.Report(oReports))
            );*/
        }
    }
}
