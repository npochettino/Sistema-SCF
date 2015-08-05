using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;

namespace SCF.nota_pedido
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGridNotaPedidos();
            }
            Session["notaDePedidoActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridNotaPedidos()
        {
            //throw new NotImplementedException();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaNotaPedido();
        }

        private void NuevaNotaPedido()
        {
            Response.Redirect("nota_pedido.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarNotaPedido();
        }

        private void EditarNotaPedido()
        {
            NotaDePedido notaDePedidoActual = new NotaDePedido();

            notaDePedidoActual.Codigo = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido").ToString());
            
            Session.Add("notaDePedidoActual", notaDePedidoActual);

            Response.Redirect("nota_pedido.aspx");
        }
        
        protected void btnAceptarEliminarNotaPedido_Click(object sender, EventArgs e)
        {

        }
    }
}