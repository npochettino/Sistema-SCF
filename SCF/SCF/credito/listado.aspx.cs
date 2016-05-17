using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.credito
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            gvNotaCredito.DataSource = ControladorGeneral.RecuperarTodasNotasDeCredito();
            gvNotaCredito.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["tablaNotaCredito"] = null;
            Session["tablaItemsNotaCredito"] = null;
            Response.Redirect("credito.aspx");
        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (gvNotaCredito.FocusedRowIndex != -1)
            {
                DataTable tableNotaCreditoActual = GetTablaNotaCreditoActualSession();
                Session["tablaNotaCredito"] = tableNotaCreditoActual;
                Response.Write("<script>window.open('generar_pdf.aspx','_blank');</script>");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar una Nota de Credito para poder generar el PDF.";
                pcError.ShowOnPageLoad = true;
            }
        }

        private DataTable GetTablaNotaCreditoActualSession()
        {
            int codigoNotaDeCredito = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaDeCredito"));
            int numeroNotaDeCredito = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroNotaDeCredito"));
            DateTime fechaNotaDeCredito = Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "fechaEmisionNotaDeCredito"));
            string descripcionTipoComprobante = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "descripcionTipoComprobante").ToString();
            string descripcionTipoMoneda = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "descripcionTipoMoneda").ToString();
            Double subtotal = Convert.ToDouble(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "subtotal"));
            Double total = Convert.ToDouble(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "total"));
            string cae = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae").ToString();
            DateTime fechaVencimientoCAE = Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "fechaHoraVencimientoCAE"));
            
            DataTable tablaNotaDeCredito = new DataTable();
            tablaNotaDeCredito.Columns.Add("codigoNotaDeCredito");
            tablaNotaDeCredito.Columns.Add("numeroNotaDeCredito");
            tablaNotaDeCredito.Columns.Add("fechaEmisionNotaDeCredito");
            tablaNotaDeCredito.Columns.Add("descripcionTipoComprobante");
            tablaNotaDeCredito.Columns.Add("descripcionTipoMoneda");
            tablaNotaDeCredito.Columns.Add("subtotal");
            tablaNotaDeCredito.Columns.Add("total");
            tablaNotaDeCredito.Columns.Add("cae");
            tablaNotaDeCredito.Columns.Add("fechaHoraVencimientoCAE");
            
            tablaNotaDeCredito.Rows.Add(new object[] { codigoNotaDeCredito, numeroNotaDeCredito, fechaNotaDeCredito, descripcionTipoComprobante, descripcionTipoMoneda, subtotal,
            total,cae,fechaVencimientoCAE});

            return tablaNotaDeCredito;
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (gvNotaCredito.FocusedRowIndex != -1)
            {
                if (gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae").ToString() == "")
                { btnEmitirComprobante.Visible = true; }

                DataTable dtItemsNotaDeCreditoActual = ControladorGeneral.RecuperarNotaDeCredito(Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaDeCredito")));
                gvDetalleNotaDeCredito.DataSource = dtItemsNotaDeCreditoActual;
                gvDetalleNotaDeCredito.DataBind();

                /*string nroAMostrar = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString();
                lblNroFacturaAEmitir.Text = "0002 - " + Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "numeroFactura")).ToString("D8");
                lblNroRemitos.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "remitos")).ToString(); //;remitos;
                lblCondicionVenta.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "condicionVenta")).ToString(); ;
                lblLocalidad.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["localidadCliente"]);
                lblDomicilio.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["direccionCliente"]);
                lblNombreApellidoCliente.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["razonSocialCliente"]);
                lblNumeroDocumento.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["nroDocumentoCliente"]);

                lblSubtotal.Text = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "subtotal").ToString();
                lblImporteTotal.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "total"));

                if (gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString() != null)
                {
                    lblNroCAE.Text = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString();
                    lblFechaVencimientoCAE.Text = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE").ToString();
                }
                */
                //lblFechaVencimientoCAE.Text = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE")).ToString() == null ? "NO EMITIDO" : Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE")).ToString("dd/MM/yyy");
                //lblNroCAE.Text = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae")).ToString() == null ? "NO EMITIDO" : Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae")).ToString();

                pcDetalleComprobante.ShowOnPageLoad = true;
            }
        }

        protected void btnAceptarEliminarNotaCredito_Click(object sender, EventArgs e)
        {
            if (gvNotaCredito.FocusedRowIndex != -1)
            {
                pcConfirmarEliminarNotaCredito.ShowOnPageLoad = false;
                try
                {
                    if (gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cai").ToString() == "")
                    {
                        //ControladorGeneral.EliminarNotaDeCredito(int.Parse(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaCredito").ToString()));
                        Response.Redirect("listado.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "La Nota de Credito posee CAI, no puede ser eliminada";
                        pcError.ShowOnPageLoad = true;
                    }

                }

                catch
                {
                    //Muestro el mensaje que me devuelve del metodo Eliminar
                    lblMensaje.Text = "No se pude eliminar la NC";
                    pcError.ShowOnPageLoad = true;
                }
            }
        }

        protected void btnEmitirComprobante_Click(object sender, EventArgs e)
        {

        }
    }
}