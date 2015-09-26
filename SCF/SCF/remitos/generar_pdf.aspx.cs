using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace SCF.remitos
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
            rvRemito.ProcessingMode = ProcessingMode.Local;
            ReportParameter txtNroRemito = new ReportParameter("txtNroRemito", "00000001");
            rvRemito.LocalReport.ReportPath = Server.MapPath("..") + "\\reportes\\remito.rdlc";
            this.rvRemito.LocalReport.SetParameters(new ReportParameter[] { txtNroRemito });
            rvRemito.LocalReport.DataSources.Clear();
            
        }
    }
}