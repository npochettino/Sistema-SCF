using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.facturas
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            gvFacturas.DataSource = ControladorGeneral.RecuperarTodasFacturas();
            gvFacturas.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["tablaFactura"] = null;
            Response.Redirect("factura.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int codigoFactura = Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "codigoFactura"));
            int numeroFactura = Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "numeroFactura"));
            DateTime fechaFacturacion = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaFacturacion"));
            string descripcionTipoComprobante = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "descripcionTipoComprobante").ToString();
            string descripcionTipoMoneda = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "descripcionTipoMoneda").ToString();
            string descripcionConcepto = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "descripcionConcepto").ToString();
            string descripcionIVA = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "descripcionIVA").ToString();
            Double subtotal = Convert.ToDouble(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "subtotal"));
            Double total = Convert.ToDouble(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "total"));
            string cae = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "razonSocialCliente").ToString();
            DateTime fechaVencimientoCAE = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE"));

            DataTable tablaFactura = new DataTable();
            tablaFactura.Columns.Add("codigoFactura");
            tablaFactura.Columns.Add("numeroFactura");
            tablaFactura.Columns.Add("fechaFacturacion");
            tablaFactura.Columns.Add("descripcionTipoComprobante");
            tablaFactura.Columns.Add("descripcionTipoMoneda");
            tablaFactura.Columns.Add("descripcionConcepto");
            tablaFactura.Columns.Add("descripcionIVA");
            tablaFactura.Columns.Add("subtotal");
            tablaFactura.Columns.Add("total");
            tablaFactura.Columns.Add("cae");
            tablaFactura.Columns.Add("fechaVencimientoCAE");

            tablaFactura.Rows.Add(new object[] { codigoFactura, numeroFactura, fechaFacturacion, descripcionTipoComprobante, descripcionTipoMoneda, descripcionConcepto, descripcionIVA, subtotal,
            total,cae,fechaVencimientoCAE});

            Session["tablaFactura"] = tablaFactura;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConfirmarEliminarFactura_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            //DataTable dtItemsFacturaActual = (DataTable)Session["dtItemsFacturaActual"];
            //gvDetalleFactura.DataSource = dtItemsFacturaActual;
            //gvDetalleFactura.DataBind();

            //lblNroFacturaAEmitir.Text = "002 - " + string.Format("{0:00000000}", txtNroFactura.Text);
            //lblCondicionVenta.Text = cbCondicionVenta.Text;
            //lblLocalidad.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["localidadCliente"]);
            //lblDomicilio.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["direccionCliente"]);
            //lblNombreApellidoCliente.Text = txtRazonSocial.Text;
            //lblNroRemitos.Text = gluRemito.Text;
            //lblNumeroDocumento.Text = txtNroDocumento.Text;
            ////lblTipoDocumento.Text = "CUIT";
            //lblFechaVencimientoCAE.Text = "NO FACTURADO";
            //lblNroCAE.Text = "NO FACTURADO";
            //lblSubtotal.Text = txtSubtotal.Text;
            //lblImporteIVA.Text = txtImporteIVA.Text;
            //lblImporteTotal.Text = txtTotal.Text;

            pcDetalleComprobante.ShowOnPageLoad = true;
        }

        protected void btnEmitirComprobante_Click(object sender, EventArgs e)
        {

        }
    }
}