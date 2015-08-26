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
using System.Drawing;
using System.Globalization;

namespace SCF.nota_pedido
{
    public partial class nota_pedido : System.Web.UI.Page
    {


        int indice = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


            CargarComboClientes();
            CargarGrillaArticulos();

            txtFechaEmision.Value = DateTime.Now;



            if (!IsPostBack)
            {

                txtFechaEmision.Value = DateTime.Now;

                CargarGrillaItemsNotaDePedido(false);


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
                    cbClientes.SelectedItem = cbClientes.Items.FindByValue(Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoCliente"]));

                    DataTable tablaItemsNotaDePedido = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
                    tablaItemsNotaDePedido.Columns.Add("isEliminada");
                    gvArticulosSeleccionados.DataSource = tablaItemsNotaDePedido;
                    gvArticulosSeleccionados.DataBind();

                    Session["tablaItemsNotaDePedido"] = tablaItemsNotaDePedido;


                }
            }


        }

        private void CargarGrillaItemsNotaDePedido(bool isSeleccionar)
        {
            //CargarGrillaArticulosPorCliente();

            DataTable tablaItemsNotaDePedido = new DataTable();

            if (Session["tablaItemsNotaDePedido"] == null)
            {
                tablaItemsNotaDePedido.Columns.Add("codigoArticulo");
                tablaItemsNotaDePedido.Columns.Add("descripcionCorta");
                tablaItemsNotaDePedido.Columns.Add("descripcionLarga");
                tablaItemsNotaDePedido.Columns.Add("marca");
                tablaItemsNotaDePedido.Columns.Add("cantidad", typeof(int));
                tablaItemsNotaDePedido.Columns.Add("fechaEntrega", typeof(DateTime));
                tablaItemsNotaDePedido.Columns.Add("codigoItemNotaDePedido", typeof(int));
                tablaItemsNotaDePedido.Columns.Add("precio", typeof(float));
                tablaItemsNotaDePedido.Columns.Add("isEliminada");

                if (Session["tablaNotaDePedido"] != null)
                {
                    int codigoNotaDePedido = Convert.ToInt32(((DataTable)Session["tablaNotaDePedido"]).Rows[0]["codigoNotaDePedido"]);

                    DataTable tablaItemsNotaDePedidoActual = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
                    tablaItemsNotaDePedidoActual.Columns.Add("isEliminada");

                    tablaItemsNotaDePedido = tablaItemsNotaDePedidoActual.Copy();
                }

                for (int i = 0; i < gvArticulos.VisibleRowCount; i++)
                {
                    if (gvArticulos.Selection.IsRowSelected(i))
                    {
                        DataRowView mRow = (DataRowView)gvArticulos.GetRow(i);
                        tablaItemsNotaDePedido.Rows.Add(mRow.Row.ItemArray[0], mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], mRow.Row.ItemArray[3], 1, DateTime.Now, 0, mRow.Row.ItemArray[4], false);
                    }
                }

                Session["tablaItemsNotaDePedido"] = tablaItemsNotaDePedido;
            }
            else
            {
                tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];

                if (isSeleccionar)
                {
                    for (int i = 0; i < gvArticulos.VisibleRowCount; i++)
                    {
                        if (gvArticulos.Selection.IsRowSelected(i))
                        {
                            DataRowView mRow = (DataRowView)gvArticulos.GetRow(i);
                            int codigoItemNotaDePedido = Convert.ToInt32(mRow.Row.ItemArray[0]);
                            DataRow filaRepetida = (from t in tablaItemsNotaDePedido.AsEnumerable() where Convert.ToInt32(t["codigoItemNotaDePedido"]) == codigoItemNotaDePedido select t).SingleOrDefault();

                            if (filaRepetida == null)
                            {
                                tablaItemsNotaDePedido.Rows.Add(mRow.Row.ItemArray[0], mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], mRow.Row.ItemArray[3], 1, DateTime.Now, 0, mRow.Row.ItemArray[4], false);
                            }
                        }
                    }
                }
            }


            Session["tablaItemsNotaDePedido"] = tablaItemsNotaDePedido;
            gvArticulosSeleccionados.DataSource = tablaItemsNotaDePedido;
            gvArticulosSeleccionados.DataBind();


        }

        private void CargarGrillaArticulosPorCliente()
        {
            if (cbClientes.SelectedItem != null)
            {
                //int codigoCliente = Convert.ToInt32(cbClientes.SelectedItem.Value);
                //DataTable tablaItemsNotaDePedido = ControladorGeneral.RecuperarArticuloPorCodigoInternoCliente(

                //gvArticulos.DataSource = tablaItemsNotaDePedido;
                //gvArticulos.DataBind();
            }
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
            DataTable tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];
            int codigoNotaDePedido = 0;

            if (Session["tablaNotaDePedido"] != null)
            {
                DataTable tablaNotaDePedido = (DataTable)Session["tablaNotaDePedido"];
                codigoNotaDePedido = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoNotaDePedido"]);
            }

            ControladorGeneral.InsertarActualizarNotaDePedido(codigoNotaDePedido, txtNroInternoCliente.Text.ToString(), DateTime.Parse(txtFechaEmision.Value.ToString()), txtObservacion.InnerText.ToString(), 0, (int)cbClientes.SelectedItem.Value, tablaItemsNotaDePedido);

            Response.Redirect("listado.aspx");
        }



        protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
        {
            DataTable tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];
            CargarGrillaItemsNotaDePedido(true);
        }



        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            DataTable tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];
            int codigoItemNotaDePedidoEliminado = Convert.ToInt32(gvArticulosSeleccionados.GetRowValues(gvArticulosSeleccionados.FocusedRowIndex, "codigoItemNotaDePedido"));

            DataRow filaEliminada = (from t in tablaItemsNotaDePedido.AsEnumerable() where Convert.ToInt32(t["codigoItemNotaDePedido"]) == codigoItemNotaDePedidoEliminado select t).SingleOrDefault();

            if (codigoItemNotaDePedidoEliminado < 1)
            {
                tablaItemsNotaDePedido.Rows.Remove(filaEliminada);
            }
            else
            {
                bool isEliminada = Convert.IsDBNull(filaEliminada["isEliminada"]) ? false : Convert.ToBoolean(filaEliminada["isEliminada"]);
                if (isEliminada)
                {
                    filaEliminada["isEliminada"] = false;
                }
                else
                {
                    filaEliminada["isEliminada"] = true;
                }
            }

            Session["tablaItemNotaDePedido"] = tablaItemsNotaDePedido;
            CargarGrillaItemsNotaDePedido(false);
        }


        protected void gvItemsEntrega_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            DataTable tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];
            int codigoItemNotaDePedido = Convert.ToInt32(e.Keys["codigoItemNotaDePedido"]);
            DataRow fila = (from t in tablaItemsNotaDePedido.AsEnumerable() where Convert.ToInt32(t["codigoItemNotaDePedido"]) == codigoItemNotaDePedido select t).SingleOrDefault();

            fila["cantidad"] = Convert.ToInt32(e.NewValues["cantidad"]);
            DateTime fechaEntrega = Convert.ToDateTime(e.NewValues["fechaEntrega"]).ToLocalTime();

            fila["fechaEntrega"] = fechaEntrega;
            Session["tablaItemsNotaDePedido"] = tablaItemsNotaDePedido;
            e.Cancel = true;
            gvArticulosSeleccionados.CancelEdit();
            CargarGrillaItemsNotaDePedido(false);
        }

        protected void gvItemsEntrega_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            bool isEliminada = Convert.IsDBNull(e.GetValue("isEliminada")) ? false : Convert.ToBoolean(e.GetValue("isEliminada"));
            if (isEliminada)
            {
                e.Row.BackColor = Color.Red;
            }
        }

    }
}