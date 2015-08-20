using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using System.Web.Services;

namespace SCF.remitos
{
    public partial class remito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tablaEntrega"] != null)
                {
                    DataTable tablaUltimaEntrega = ControladorGeneral.RecuperarUltimaEntrega();
                    txtCodigoRemito.Text = tablaUltimaEntrega.Rows.Count > 0 ? tablaUltimaEntrega.Rows[0]["codigoEntrega"].ToString() : string.Empty;
                }
            }

            cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido();
            cbNotaDePedido.DataBind();
            CargarGrillaItemsEntrega();

            if (Session["tablaEntrega"] != null)
            {
                DataTable tablaEntrega = (DataTable)Session["tablaEntrega"];
                txtCodigoRemito.Text = tablaEntrega.Rows[0]["numeroRemito"].ToString(); ;
                txtFechaEmision.Value = Convert.ToDateTime(tablaEntrega.Rows[0]["fechaEmision"]);
                txtObservacion.InnerText = tablaEntrega.Rows[0]["observaciones"].ToString();

                int codigoNotaDePedido = Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]);
                gvItemsNotaDePedido.DataSource = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
                gvItemsNotaDePedido.DataBind();

                int codigoEntrega = Convert.ToInt32(tablaEntrega.Rows[0]["codigoEntrega"]);
                gvItemsEntrega.DataSource = ControladorGeneral.RecuperaritemsEntrega(codigoEntrega);
                gvItemsEntrega.DataBind();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
        {
            Session["tablaItemsEntrega"] = null;
            CargarGrillaItemsEntrega();
        }

        private void CargarGrillaItemsEntrega()
        {
            CargarGrillaItemsNotaDePedido();
            DataTable tablaItemsEntrega = new DataTable();

            if (Session["tablaItemsEntrega"] == null)
            {
                tablaItemsEntrega.Columns.Add("codigoItemEntrega");
                tablaItemsEntrega.Columns.Add("codigoArticulo");
                tablaItemsEntrega.Columns.Add("descripcionCorta");
                tablaItemsEntrega.Columns.Add("cantidad");
                tablaItemsEntrega.Columns.Add("codigoProveedor");
                tablaItemsEntrega.Columns.Add("razonSocialProveedor");

                for (int i = 0; i < gvItemsNotaDePedido.VisibleRowCount; i++)
                {
                    if (gvItemsNotaDePedido.Selection.IsRowSelected(i))
                    {
                        DataRowView mRow = (DataRowView)gvItemsNotaDePedido.GetRow(i);
                        tablaItemsEntrega.Rows.Add(-i, mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], 1, 0, string.Empty);
                    }
                }

                Session["tablaItemsEntrega"] = tablaItemsEntrega;
            }
            else
            {
                tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];
            }

            gvItemsEntrega.DataSource = tablaItemsEntrega;
            gvItemsEntrega.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void cbNotaDePedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrillaItemsNotaDePedido();
        }

        private void CargarGrillaItemsNotaDePedido()
        {
            if (cbNotaDePedido.SelectedItem != null)
            {
                int codigoNotaDePedido = Convert.ToInt32(cbNotaDePedido.SelectedItem.Value);
                DataTable tablaItemsNotaDePedido = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);

                gvItemsNotaDePedido.DataSource = tablaItemsNotaDePedido;
                gvItemsNotaDePedido.DataBind();
            }
        }

        protected void gvItemsEntrega_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            DataTable tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];
            int codigoItemEntregaEditado = Convert.ToInt32(e.Keys["codigoItemEntrega"]);
            DataRow fila = (from t in tablaItemsEntrega.AsEnumerable() where Convert.ToInt32(t["codigoItemEntrega"]) == codigoItemEntregaEditado select t).SingleOrDefault();
            int cantidad = Convert.ToInt32(e.NewValues["cantidad"]);
            fila["cantidad"] = cantidad;
            Session["tablaItemsEntrega"] = tablaItemsEntrega;
            e.Cancel = true;
            gvItemsEntrega.CancelEdit();
        }

        //[WebMethod]
        //public static void GuardarGrilla(string[] s)
        //{
        //    int a = 0;
        //}
    }
}