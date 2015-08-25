using BibliotecaSCF.ClasesComplementarias;
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
            int numeroNotaDePedido = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroNotaDePedido"));
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

            DataTable tablaEntrega = new DataTable();
            tablaEntrega.Columns.Add("codigoEntrega");
            tablaEntrega.Columns.Add("codigoNotaDePedido");
            tablaEntrega.Columns.Add("codigoCliente");
            tablaEntrega.Columns.Add("razonSocialCliente");
            tablaEntrega.Columns.Add("fechaEmision");
            tablaEntrega.Columns.Add("numeroRemito");
            tablaEntrega.Columns.Add("codigoEstado");
            tablaEntrega.Columns.Add("observaciones");

            tablaEntrega.Rows.Add(new object[] { codigoEntrega, codigoNotaDePedido, codigoCliente, razonSocialCliente, fechaEmision, numeroRemito, codigoEstado, observaciones });

            Session["tablaEntrega"] = tablaEntrega;

            Response.Redirect("remito.aspx");
        }

        protected void btnAceptarEliminarRemito_Click(object sender, EventArgs e)
        {
            int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));

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
                pcError.ShowOnPageLoad = true;
            }
        }

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
    }
}