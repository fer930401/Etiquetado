using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Etiquetas.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etiquetas
{
    public partial class EtiquetasPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["GridView"];

            ReportDocument rep = new ReportDocument();
            rep.Load(Server.MapPath("Reportes/CrystalReport1.rpt"));
            rep.Refresh();
            rep.SetDataSource(dt);

            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = @"C:\Users\fer_9\Documents\Visual Studio 2013\Projects\Etiquetas\Etiquetas\Files\Reporte.pdf";
            CrExportOptions = rep.ExportOptions;
            {
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
            }
            //nombre de la impresora
            //rep.PrintOptions.PrinterName = "Epson SQ-1170 ESC/P 2"
            var doctoPrint = new System.Drawing.Printing.PrintDocument();
            doctoPrint.PrinterSettings.PrinterName = "EPSON LX-300+ /II"; ; //printer es el nombre de la impresora por donde imprimirá

            for (var j = 0; j < doctoPrint.PrinterSettings.PaperSizes.Count; j++)
                if (doctoPrint.PrinterSettings.PaperSizes[j].PaperName == "fact") //tamañoPapel es el nombre del tamaño parametrizado
                {
                    rep.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)doctoPrint.PrinterSettings.PaperSizes[j].RawKind;
                    break;
                }
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Reporte");
        }
    }
}