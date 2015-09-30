﻿using System;
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
            DataTable tablaFactura = GetTablaFacturaActualSession();

            Session["tablaFactura"] = tablaFactura;
        }

        private DataTable GetTablaFacturaActualSession()
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
            string cae = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString();
            DateTime fechaVencimientoCAE = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE"));
            string condicionVenta = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "condicionVenta").ToString();

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
            tablaFactura.Columns.Add("condicionVenta");

            tablaFactura.Rows.Add(new object[] { codigoFactura, numeroFactura, fechaFacturacion, descripcionTipoComprobante, descripcionTipoMoneda, descripcionConcepto, descripcionIVA, subtotal,
            total,cae,fechaVencimientoCAE,condicionVenta});

            return tablaFactura;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConfirmarEliminarFactura_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            if (gvFacturas.FocusedRowIndex != -1)
            {
                string remitos = "";
                if (gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString() == "")
                { btnEmitirComprobante.Visible = true; }
                DataTable dtItemsFacturaActual = ControladorGeneral.RecuperarItemsEntregaPorFactura(Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "codigoFactura")));
                gvDetalleFactura.DataSource = dtItemsFacturaActual;
                gvDetalleFactura.DataBind();
                string nroAMostrar = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString();
            
                lblNroFacturaAEmitir.Text = "002 - " + Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "numeroFactura")).ToString("D8");
            
                for (int i = 0; i < dtItemsFacturaActual.Rows.Count; i++)
                {
                    remitos = dtItemsFacturaActual.Rows[0]["nroRemito"] + ", ";
                }
                lblNroRemitos.Text = remitos;
                lblCondicionVenta.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex,"condicionVenta")).ToString();;
                lblLocalidad.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["localidadCliente"]);
                lblDomicilio.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["direccionCliente"]);
                lblNombreApellidoCliente.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["razonSocialCliente"]);


                lblNumeroDocumento.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["nroDocumentoCliente"]);
                lblFechaVencimientoCAE.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE"));
                lblNroCAE.Text = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString();
                lblSubtotal.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "subtotal"));
                lblImporteIVA.Text = Convert.ToString(Convert.ToDouble(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "subtotal")) * 0.21);
                lblImporteTotal.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "total"));

                pcDetalleComprobante.ShowOnPageLoad = true;
            }
            else
            {
                lblError.Text = "Debe seleccionar una factura para ver el detalle de la misma.";
                pcError.ShowOnPageLoad = true;
            }
        }

        protected void btnEmitirComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                string status = ControladorGeneral.EmitirFactura(Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "codigoFactura")));
                lblError.Text = status;
                pcError.ShowOnPageLoad = true;
            }
            catch
            {
                lblError.Text = "Ha ocurrido un error. No hay conexion con los servidor de AFIP, vuelva a intentar.";
                pcError.ShowOnPageLoad = true;
            }
        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (gvFacturas.FocusedRowIndex != -1)
            {
                if (gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString() != "")
                {
                    DataTable tableFacturaActual = GetTablaFacturaActualSession();
                    Session["tablaFactura"] = tableFacturaActual;

                    Response.Write("<script>window.open('generar_pdf.aspx','_blank');</script>");
                }
                else
                {
                    lblError.Text = "La factura no tiene CAE. No es posible generar el PDF";
                    pcError.ShowOnPageLoad = true;
                }
            }
            else
            {
                lblError.Text = "Debe seleccionar una factura para poder generar el PDF.";
                pcError.ShowOnPageLoad = true;
            }
        }
    }
}