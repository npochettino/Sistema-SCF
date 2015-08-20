using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.remitos
{
    public partial class remito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tablaUltimaEntrega = ControladorGeneral.RecuperarUltimaEntrega();
                txtCodigoRemito.Text = tablaUltimaEntrega.Rows.Count > 0 ? tablaUltimaEntrega.Rows[0]["codigoEntrega"].ToString() : string.Empty;
            }

            cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido();
            cbNotaDePedido.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void cbNotaDePedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigoNotaDePedido = Convert.ToInt32(cbNotaDePedido.SelectedItem.Value);
            DataTable tablaItemsNotaDePedido = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);

            gvItemsNotaDePedido.DataSource = tablaItemsNotaDePedido;
            gvItemsNotaDePedido.DataBind();
        }

    }
}