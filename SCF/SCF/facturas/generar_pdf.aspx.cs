using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace SCF.facturas
{
    public partial class generar_pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadReporte();
        }

        private void LoadReporte()
        {
            rvFacturaA.ProcessingMode = ProcessingMode.Local;
            ReportParameter txtNroFactura = new ReportParameter("txtNroFactura", "002 - 00000001");
            rvFacturaA.LocalReport.ReportPath = Server.MapPath("..") + "\\reportes\\facturaA.rdlc";
            this.rvFacturaA.LocalReport.SetParameters(new ReportParameter[] { txtNroFactura });
            rvFacturaA.LocalReport.DataSources.Clear();
            
        }
    }
}