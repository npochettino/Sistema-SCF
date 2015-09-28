using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using Microsoft.Reporting.WebForms;

namespace SCF.facturas
{
    public partial class generar_pdf : System.Web.UI.Page
    {
        dsItemsFacturaA dsReporte = new dsItemsFacturaA();
        DataTable tablaReporte = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadReporte();
        }

        private void LoadReporte()
        {
            DataTable dtFacturaActual = (DataTable)Session["tablaFactura"];
            DataTable dtItemsFacturaActual = ControladorGeneral.RecuperarItemsEntregaPorFactura(Convert.ToInt32(dtFacturaActual.Rows[0]["codigoFactura"]));
            
            string remitos = "";
            for (int i = 0; i < dtItemsFacturaActual.Rows.Count; i++)
            { remitos = dtItemsFacturaActual.Rows[0]["nroRemito"] + ", "; }

            rvFacturaA.ProcessingMode = ProcessingMode.Local;
            rvFacturaA.LocalReport.ReportPath = Server.MapPath("..") + "\\reportes\\facturaA.rdlc";
            ReportParameter txtNroFactura = new ReportParameter("txtNroFactura", "002 - " +  Convert.ToInt32(dtFacturaActual.Rows[0]["numeroFactura"]).ToString("D8"));
            ReportParameter txtCliente = new ReportParameter("txtCliente", Convert.ToString(dtItemsFacturaActual.Rows[0]["razonSocialCliente"]));
            ReportParameter txtDomicilio = new ReportParameter("txtDomicilio", Convert.ToString(dtItemsFacturaActual.Rows[0]["direccionCliente"]));
            ReportParameter txtLocalidad = new ReportParameter("txtLocalidad", Convert.ToString(dtItemsFacturaActual.Rows[0]["localidadCliente"]));
            ReportParameter txtNroDocumento = new ReportParameter("txtNroDocumento", Convert.ToString(dtItemsFacturaActual.Rows[0]["nroDocumentoCliente"]));
            ReportParameter txtNroRemitos = new ReportParameter("txtNroRemitos", remitos);
            ReportParameter txtCondicionVenta = new ReportParameter("txtCondicionVenta", "15 días");
            ReportParameter txtSubtotal = new ReportParameter("txtSubtotal", Convert.ToString(dtFacturaActual.Rows[0]["subtotal"]));
            ReportParameter txtIVA = new ReportParameter("txtIVA", Convert.ToString(Convert.ToDouble(dtFacturaActual.Rows[0]["subtotal"])*0.21));
            ReportParameter txtTotal = new ReportParameter("txtTotal", Convert.ToString(dtFacturaActual.Rows[0]["total"]));
            ReportParameter txtCAE = new ReportParameter("txtCAE", Convert.ToString(dtFacturaActual.Rows[0]["cae"]));
            ReportParameter txtFechaVencimientoCAE = new ReportParameter("txtFechaVencimientoCAE", Convert.ToString(dtFacturaActual.Rows[0]["fechaVencimientoCAE"]));
            ReportParameter txtFechaFacturacion = new ReportParameter("txtFechaFacturacion", Convert.ToString(dtFacturaActual.Rows[0]["fechaFacturacion"]));

            this.rvFacturaA.LocalReport.SetParameters(new ReportParameter[] { txtNroFactura,txtCliente,txtDomicilio,txtLocalidad,txtNroDocumento,txtNroRemitos,
            txtCondicionVenta,txtSubtotal,txtIVA,txtTotal,txtCAE,txtFechaVencimientoCAE,txtFechaFacturacion});
            
            dsReporte.DataTable1.Clear();
            tablaReporte = dtItemsFacturaActual;

            foreach (DataRow fila in tablaReporte.Rows)
            {
                DataRow filaReporte = dsReporte.DataTable1.NewRow();
                filaReporte["codigoArticulo"] = fila["codigoArticulo"];
                filaReporte["descripcionCorta"] = fila["descripcionCorta"];
                filaReporte["cantidad"] = fila["cantidad"];
                filaReporte["precioUnitario"] = fila["precioUnitario"];
                filaReporte["precioTotal"] = fila["precioTotal"];

                dsReporte.DataTable1.Rows.Add(filaReporte);
            }

            for(int i = 0; i < (5 - tablaReporte.Rows.Count); i ++)
            {
                DataRow filaReporte = dsReporte.DataTable1.NewRow();
                dsReporte.DataTable1.Rows.Add(filaReporte);
            }
            dsItemsFacturaA dsReporte1 = dsReporte;

            ReportDataSource datasource = new ReportDataSource("dsItemsFacturaA", dsReporte1.Tables[0]);
            rvFacturaA.LocalReport.DataSources.Clear();
            rvFacturaA.LocalReport.DataSources.Add(datasource);            
        }
    }
}