using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;

namespace SCF
{
    public partial class listado_clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGridClientes();
            }
            Session["clienteActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridClientes()
        {
            // gvProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores();
            //gvProveedores.DataBind();


        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoCliente();
        }

        private void NuevoCliente()
        {
            Response.Redirect("cliente.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarCliente();
        }

        private void EditarCliente()
        {
            Cliente clienteActual = new Cliente();

            clienteActual.Codigo = int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoCliente").ToString());
            clienteActual.Cuil = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "cuil").ToString();
            clienteActual.Direccion = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "direccion").ToString();
            clienteActual.Localidad = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "localidad").ToString();
            clienteActual.Mail = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "mail").ToString();
            clienteActual.Provincia = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "provincia").ToString();
            clienteActual.RazonSocial = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "razonSocial").ToString();
            clienteActual.Telefono = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "telefono").ToString();

            Session.Add("clienteActual", clienteActual);

            Response.Redirect("cliente.aspx");
        }

        protected void btnAceptarEliminarCliente_Click(object sender, EventArgs e)
        {

        }
    }
}