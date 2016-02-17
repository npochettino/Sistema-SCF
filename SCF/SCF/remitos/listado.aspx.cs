﻿using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCF.remitos
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            gvEntregas.DataSource = ControladorGeneral.RecuperarTodasEntregas();
            gvEntregas.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["tablaEntrega"] = null;
            Session["tablaItemsEntrega"] = null;
            Response.Redirect("remito.aspx");
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            pcShowDetalleRemito.ShowOnPageLoad = true;

            int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
            int codigoNotaDePedido = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoNotaDePedido"));
            string numeroNotaDePedido = Convert.ToString(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroNotaDePedido"));
            int codigoCliente = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoCliente"));
            string razonSocialCliente = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialCliente").ToString();
            DateTime fechaEmision = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaEmision"));
            int numeroRemito = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroRemito"));
            int codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
            string observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();

            txtCodigo.Text = numeroRemito.ToString();
            txtFechaRemito.Value = fechaEmision;
            txtNotaDePedido.Text = numeroNotaDePedido.ToString();
            txtObservacion.InnerText = observaciones;

            DataTable tablaItemsEntrega = ControladorGeneral.RecuperarItemsEntrega(codigoEntrega);

            gvItemsRemito.DataSource = tablaItemsEntrega;
            gvItemsRemito.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
            int codigoNotaDePedido = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoNotaDePedido"));
            int codigoCliente = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoCliente"));
            string razonSocialCliente = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialCliente").ToString();
            DateTime fechaEmision = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaEmision"));
            int numeroRemito = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroRemito"));
            int codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
            string observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();
            int codigoTransporte = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoTransporte"));
            int codigoDireccion = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoDireccion"));
            string cai = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "cai").ToString();
            DateTime fechaVencimientoCai = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaVencimientoCai"));

            DataTable tablaEntrega = new DataTable();
            tablaEntrega.Columns.Add("codigoEntrega");
            tablaEntrega.Columns.Add("codigoNotaDePedido");
            tablaEntrega.Columns.Add("codigoCliente");
            tablaEntrega.Columns.Add("razonSocialCliente");
            tablaEntrega.Columns.Add("fechaEmision");
            tablaEntrega.Columns.Add("numeroRemito");
            tablaEntrega.Columns.Add("codigoEstado");
            tablaEntrega.Columns.Add("observaciones");
            tablaEntrega.Columns.Add("codigoTransporte");
            tablaEntrega.Columns.Add("codigoDireccion");
            tablaEntrega.Columns.Add("cai");
            tablaEntrega.Columns.Add("fechaVencimientoCai");

            tablaEntrega.Rows.Add(new object[] { codigoEntrega, codigoNotaDePedido, codigoCliente, razonSocialCliente, fechaEmision, numeroRemito, codigoEstado, observaciones, codigoTransporte, 
                codigoDireccion, cai, fechaVencimientoCai });

            Session["tablaEntrega"] = tablaEntrega;

            Response.Redirect("remito.aspx");
        }

        protected void btnAceptarEliminarRemito_Click(object sender, EventArgs e)
        {
            if (gvEntregas.FocusedRowIndex != -1)
            {
                int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
                string mensaje = ControladorGeneral.EliminarEntrega(codigoEntrega);
                pcError.ShowOnPageLoad = true;

                if (mensaje == "ok")
                {
                    lblMensaje.Text = "Se ha eliminado correctamente.";
                    pcError.ShowOnPageLoad = true;
                }
                else
                {
                    lblMensaje.Text = "No se permite elimnar el remito ya que está asociado a una factura";
                    pcError.ShowOnPageLoad = true;
                }

                pcConfirmarEliminarRemito.ShowOnPageLoad = false;
            }
        }

        protected void btnEntregada_Click(object sender, EventArgs e)
        {
            int codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
            if (codigoEstado != Constantes.Estados.ANULADA)
            {
                int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
                string observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();
                ControladorGeneral.EntregadaPendienteEntrega(codigoEntrega, observaciones);
                CargarGrilla();
            }
            else
            {
                lblMensaje.Text = "No se permite entregar un remito que esta anulado.";
                pcError.ShowOnPageLoad = true;
            }
        }

        /*Se elimina la siguiente llamada al boton y se agrega la opcion que levanta el popup para devolver items del remito..*/
        protected void btnAnulada_Click(object sender, EventArgs e)
        {
            int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
            string observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();
            ControladorGeneral.ActivarAnularEntrega(codigoEntrega, observaciones);
            CargarGrilla();
        }

        protected void gvEntregas_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            int codigoEstado = e.GetValue("codigoEstado") == null ? 0 : Convert.ToInt32(e.GetValue("codigoEstado"));
            Color color;

            switch (codigoEstado)
            {
                case Constantes.Estados.VIGENTE:
                    color = Color.Yellow;
                    break;
                case Constantes.Estados.ENTREGADA:
                    color = Color.Green;
                    break;
                case Constantes.Estados.ANULADA:
                    color = Color.LightGray;
                    break;
                default:
                    color = Color.White;
                    break;
            }

            e.Row.BackColor = color;
        }

        protected void btnDevolucion_Click(object sender, EventArgs e)
        {
            pcDevolucionItemsRemito.ShowOnPageLoad = true;
            CargarItemsRemitoEnVariblaSession();
        }

        private void CargarItemsRemitoEnVariblaSession()
        {

        }

        protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarArticulos_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void gvItemsEntrega_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

        }

        protected void gvItemsEntrega_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {

        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (gvEntregas.FocusedRowIndex != -1)
            {
                DataTable tableRemitoActual = GetTablaRemitoActualSession();
                Session["tablaRemito"] = tableRemitoActual;
                Response.Write("<script>window.open('generar_pdf.aspx','_blank');</script>");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar una factura para poder generar el PDF.";
                pcError.ShowOnPageLoad = true;
            }
        }

        private DataTable GetTablaRemitoActualSession()
        {
            int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
            int codigoNotaDePedido = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoNotaDePedido"));
            int codigoCliente = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoCliente"));
            string razonSocialCliente = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialCliente").ToString();
            DateTime fechaEmision = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaEmision"));
            int numeroRemito = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroRemito"));
            int codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
            string observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();
            string razonSocialTransporte = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialTransporte").ToString();
            string domicilio = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "domicilio").ToString();
            string localidad = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "localidad").ToString();
            string cai = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "cai").ToString();
            DateTime fechaVencimientoCAI = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaVencimientoCai"));

            DataTable tablaEntrega = new DataTable();
            tablaEntrega.Columns.Add("codigoEntrega");
            tablaEntrega.Columns.Add("codigoNotaDePedido");
            tablaEntrega.Columns.Add("codigoCliente");
            tablaEntrega.Columns.Add("razonSocialCliente");
            tablaEntrega.Columns.Add("fechaEmision");
            tablaEntrega.Columns.Add("numeroRemito");
            tablaEntrega.Columns.Add("codigoEstado");
            tablaEntrega.Columns.Add("observaciones");
            tablaEntrega.Columns.Add("razonSocialTransporte");
            tablaEntrega.Columns.Add("domicilio");
            tablaEntrega.Columns.Add("localidad");
            tablaEntrega.Columns.Add("cai");
            tablaEntrega.Columns.Add("fechaVencimientoCai");

            tablaEntrega.Rows.Add(new object[] { codigoEntrega, codigoNotaDePedido, codigoCliente, razonSocialCliente, fechaEmision, numeroRemito, codigoEstado, observaciones, razonSocialTransporte,
            domicilio, localidad, cai, fechaVencimientoCAI});

            return tablaEntrega;
        }
    }
}