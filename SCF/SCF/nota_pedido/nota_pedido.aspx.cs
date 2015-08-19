using BibliotecaSCF.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using DevExpress.Web.ASPxEditors;

namespace SCF.nota_pedido
{
    public partial class nota_pedido : System.Web.UI.Page
    {




        protected void Page_Load(object sender, EventArgs e)
        {

            txtFechaEmision.Value = DateTime.Now;
            CargarComboClientes();
            CargarGrillaArticulos();

            if (!IsPostBack)
            {

                txtFechaEmision.Value = DateTime.Now;


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
                }
            }

            int codigoNotaDePedido2 = Session["tablaNotaDePedido"] == null ? 0 : Convert.ToInt32(((DataTable)Session["tablaNotaDePedido"]).Rows[0]["codigoNotaDePedido"]);
            if (codigoNotaDePedido2 != 0)
            {
                CargarGrillaArticulosSeleccionados(codigoNotaDePedido2);
            }
            else
            {
                Cargar();
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

            guardarNotaDePedido();


            Response.Redirect("listado.aspx");
        }

        protected void btnGuardarItemsNotaDePedido_Click(object sender, EventArgs e)
        {
        }

        protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            DataTable mArticulosSeleccionados = new DataTable();

            mArticulosSeleccionados.Columns.Add("codigoArticulo");
            mArticulosSeleccionados.Columns.Add("descripcionCorta");
            mArticulosSeleccionados.Columns.Add("descripcionLarga");
            mArticulosSeleccionados.Columns.Add("marca");
            mArticulosSeleccionados.Columns.Add("cantidad", typeof(int));
            mArticulosSeleccionados.Columns.Add("fechaEntrega", typeof(DateTime));
            mArticulosSeleccionados.Columns.Add("codigoItemNotaDePedido", typeof(int));
            mArticulosSeleccionados.Columns.Add("precio", typeof(float));

            for (int i = 0; i < gvArticulos.VisibleRowCount; i++)
            {
                if (gvArticulos.Selection.IsRowSelected(i))
                {
                    DataRowView mRow = (DataRowView)gvArticulos.GetRow(i);
                    mArticulosSeleccionados.Rows.Add(mRow.Row.ItemArray[0], mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], mRow.Row.ItemArray[3], 1, DateTime.Now, 0, mRow.Row.ItemArray[4]);
                }
            }

            gvArticulosSeleccionados.DataSource = mArticulosSeleccionados;

            gvArticulosSeleccionados.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            guardarNotaDePedido();
        }



        private void guardarNotaDePedido()
        {
            DataTable m = (DataTable)gvArticulosSeleccionados.DataSource;
            ControladorGeneral.InsertarActualizarNotaDePedido(0, txtNroInternoCliente.Text.ToString(), DateTime.Parse(txtFechaEmision.Value.ToString()), txtObservacion.InnerText.ToString(), 0, (int)cbClientes.SelectedItem.Value, m);
        }

        protected void fecha_Init(object sender, EventArgs e)
        {
            ((ASPxDateEdit)sender).Date = DateTime.Now.Date;
        }

    }
}