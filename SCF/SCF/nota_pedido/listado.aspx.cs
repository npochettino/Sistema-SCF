using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;
using System.Data;
using System.Drawing;

namespace SCF.nota_pedido
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

            loadGridNotaPedidos();
        }

        private void loadGridNotaPedidos()
        {
            gvNotasPedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido();
            gvNotasPedido.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaNotaPedido();
        }

        private void NuevaNotaPedido()
        {
            Session["tablaNotaDePedido"] = null;
            Response.Redirect("nota_pedido.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarNotaPedido();
        }

        private void EditarNotaPedido()
        {
            int codigoNotaDePedido = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido").ToString());
            int numeroInternoCliente = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "numeroInternoCliente").ToString());
            DateTime fechaEmision = Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaEmision").ToString());
            int codigoEstado = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoEstado").ToString());
            //string colorEstado = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "colorEstado").ToString());
            int codigoContratoMarco = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoContratoMarco").ToString());
            //string descripcionContratoMarco = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "descripcionContratoMarco").ToString());
            int codigoCliente = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoCliente").ToString());
            //int razonSocialCliente = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "razonSocialCliente").ToString());
            DateTime fechaHoraProximaEntrega = Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaHoraProximaEntrega").ToString());
            string observaciones = gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones").ToString();

            DataTable tablaNotasDePedido = new DataTable();
            tablaNotasDePedido.Columns.Add("codigoNotaDePedido");
            tablaNotasDePedido.Columns.Add("numeroInternoCliente");
            tablaNotasDePedido.Columns.Add("fechaEmision");
            tablaNotasDePedido.Columns.Add("codigoEstado");
            //tablaNotasDePedido.Columns.Add("colorEstado");
            tablaNotasDePedido.Columns.Add("codigoContratoMarco");
            //tablaNotasDePedido.Columns.Add("descripcionContratoMarco");
            tablaNotasDePedido.Columns.Add("codigoCliente");
            //tablaNotasDePedido.Columns.Add("razonSocialCliente");
            tablaNotasDePedido.Columns.Add("fechaHoraProximaEntrega");
            tablaNotasDePedido.Columns.Add("observaciones");

            tablaNotasDePedido.Rows.Add(new object[] { codigoNotaDePedido, numeroInternoCliente, fechaEmision, codigoEstado, codigoContratoMarco, codigoCliente, fechaHoraProximaEntrega, observaciones });

            Session["tablaNotaDePedido"] = tablaNotasDePedido;

            Response.Redirect("nota_pedido.aspx");
        }

        protected void btnAceptarEliminarNotaPedido_Click(object sender, EventArgs e)
        {

        }

        protected void gvNotasPedido_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            string colorEstado = e.GetValue("colorEstado") == null ? string.Empty : e.GetValue("colorEstado").ToString();
            if (!string.IsNullOrEmpty(colorEstado))
            {
                Color color;
                switch (colorEstado)
                {
                    case "#00FF00":
                        color = Color.LightGreen;
                        break;
                    case "#00FFFF":
                        color = Color.LightCyan;
                        break;
                    case "#A4A4A4":
                        color = Color.LightGray;
                        break;
                    case "#FFFF00":
                        color = Color.LightYellow;
                        break;
                    case "#FF0000":
                        color = Color.OrangeRed;
                        break;
                    default:
                        color = Color.White;
                        break;
                }

                e.Row.BackColor = color;
            }
            //foreach (var c in e.Row.Cells)
            //{
            //    foreach (var t in c)
            //    {
            //        t.BackColor = color;
            //    }
            //}
        }

        protected void gvNotasPedido_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            //e.bac

        }

    }
}