using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using Microsoft.Reporting.WebForms;

namespace SCF.remitos
{
    public partial class generar_pdf : System.Web.UI.Page
    {
        dsItemsRemito dsReporte = new dsItemsRemito();
        DataTable tablaReporte = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadReporte();
        }

        private void LoadReporte()
        {           
            DataTable dtRemitoActual = (DataTable)Session["tablaRemito"];
            DataTable dtItemsRemitoActual = ControladorGeneral.RecuperarItemsEntrega(Convert.ToInt32(dtRemitoActual.Rows[0]["codigoEntrega"]));

            rvRemito.ProcessingMode = ProcessingMode.Local;
            rvRemito.LocalReport.ReportPath = Server.MapPath("..") + "\\reportes\\remito.rdlc";
            ReportParameter txtNroRemito = new ReportParameter("txtNroRemito", Convert.ToInt32(dtRemitoActual.Rows[0]["numeroRemito"]).ToString("D8"));
            ReportParameter txtCliente = new ReportParameter("txtCliente", Convert.ToString(dtRemitoActual.Rows[0]["razonSocialCliente"]));
            ReportParameter txtDomicilio = new ReportParameter("txtDomicilio", Convert.ToString(dtItemsRemitoActual.Rows[0]["direccionCliente"]));
            ReportParameter txtLocalidad = new ReportParameter("txtLocalidad", Convert.ToString(dtItemsRemitoActual.Rows[0]["localidadCliente"]));
            ReportParameter txtNroDocumento = new ReportParameter("txtNroDocumento", Convert.ToString(dtItemsRemitoActual.Rows[0]["nroDocumentoCliente"]));
            ReportParameter txtCondicionVenta = new ReportParameter("txtCondicionVenta", "15 días");
            ReportParameter txtFechaRemito = new ReportParameter("txtFechaRemito", Convert.ToDateTime(dtRemitoActual.Rows[0]["fechaEmision"]).ToString("dd/MM/yyyy"));

            this.rvRemito.LocalReport.SetParameters(new ReportParameter[] { txtNroRemito,txtCliente,txtDomicilio,txtLocalidad,txtNroDocumento,
            txtCondicionVenta,txtFechaRemito});

            dsReporte.DataTable1.Clear();
            tablaReporte = dtItemsRemitoActual;

            foreach (DataRow fila in tablaReporte.Rows)
            {
                DataRow filaReporte = dsReporte.DataTable1.NewRow();
                filaReporte["codigoArticulo"] = fila["codigoArticuloCliente"];
                filaReporte["descripcion"] = fila["descripcionCorta"];
                filaReporte["cantidad"] = fila["cantidad"];
                
                dsReporte.DataTable1.Rows.Add(filaReporte);
            }

            for (int i = 0; i < (5 - tablaReporte.Rows.Count); i++)
            {
                DataRow filaReporte = dsReporte.DataTable1.NewRow();
                dsReporte.DataTable1.Rows.Add(filaReporte);
            }
            dsItemsRemito dsReporte1 = dsReporte;

            ReportDataSource datasource = new ReportDataSource("dsItemsRemito", dsReporte1.Tables[0]);
            rvRemito.LocalReport.DataSources.Clear();
            rvRemito.LocalReport.DataSources.Add(datasource);      
            
        }
    }
}