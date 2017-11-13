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
            //rep.Load(Server.MapPath("Reportes/CrystalReport1.rpt"));
            rep.Load(Server.MapPath("Reportes/Reporte2.rpt"));
            rep.Refresh();
            rep.SetDataSource(dt);

            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            //CrDiskFileDestinationOptions.DiskFileName = @"C:\Users\fer_9\Documents\Visual Studio 2013\Projects\Etiquetas\Etiquetas\Files\Reporte.pdf";
            CrExportOptions = rep.ExportOptions;
            {
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
            }
            rep.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Reporte");
        }
    }
}