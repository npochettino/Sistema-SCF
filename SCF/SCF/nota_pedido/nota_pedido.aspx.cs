using BibliotecaSCF.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCF.nota_pedido
{
    public partial class nota_pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboClientes();
                CargarGrillaArticulos();
                if (Session["tablaNotaDePedido"] != null)
                {
                    DataTable tablaNotaDePedido = (DataTable)Session["tablaNotaDePedido"];
                    int codigoNotaDePedido = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoNotaDePedido"]);
                    string numeroInternoCliente = tablaNotaDePedido.Rows[0]["numeroInternoCliente"].ToString();
                    DateTime fechaEmision = Convert.ToDateTime(tablaNotaDePedido.Rows[0]["fechaEmision"]);
                    int codigoEstado = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoEstado"]);
                    int codigoContratoMarco = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoContratoMarco"]);
                    int codigoCliente = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoCliente"]);
                    DateTime fechaHoraProximaEntrega = Convert.ToDateTime(tablaNotaDePedido.Rows[0]["fechaHoraProximaEntrega"]);
                    string observaciones = tablaNotaDePedido.Rows[0]["observaciones"].ToString();

                    txtCodigoInterno.Text = numeroInternoCliente;
                    txtFechaEmision.Value = fechaEmision.ToString();
                    txtNroInternoCliente.Text = numeroInternoCliente;
                    txtObservacion.InnerText = observaciones;
                    cbClientes.SelectedItem = cbClientes.Items.FindByValue(codigoCliente);
                    CargarGrillaArticulosSeleccionados(codigoNotaDePedido);
                }
            }
        }

        private void CargarGrillaArticulosSeleccionados(int codigoNotaDePedido)
        {
            gvArticulosSeleccionados.DataSource = ControladorGeneral.RecuperarArticulosEnNotaDePedido(codigoNotaDePedido);
            gvArticulosSeleccionados.DataBind();
        }

        private void CargarGrillaArticulos()
        {
            gvArticulos.DataSource = ControladorGeneral.RecuperarTodosArticulos();
            gvArticulos.DataBind();
        }

        private void CargarComboClientes()
        {
            cbClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            cbClientes.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int codigoNotaDePedido = Session["tablaNotaDePedido"] == null ? 0 : Convert.ToInt32(((DataTable)Session["tablaNotaDePedido"]).Rows[0]["codigoNotaDePedido"]);
            string numeroInterno = txtCodigoInterno.Text;
            DateTime fechaEmision = Convert.ToDateTime(txtFechaEmision.Value);
            string numeroInternoCliente = txtNroInternoCliente.Text;
            string observaciones = txtObservacion.InnerText;
            int codigoCliente = Convert.ToInt32(cbClientes.Value);
            DataTable tablaItems = (DataTable)gvArticulosSeleccionados.DataSource;

            ControladorGeneral.InsertarActualizarNotaDePedido(codigoNotaDePedido, numeroInternoCliente, fechaEmision, observaciones, 0, codigoCliente, tablaItems);

            Response.Redirect("listado.aspx");
        }

        protected void btnGuardarItemsNotaDePedido_Click(object sender, EventArgs e)
        {
        }

        protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int a = 1;
        }

    }
}