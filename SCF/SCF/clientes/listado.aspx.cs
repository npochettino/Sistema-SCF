using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.clientes
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }            

            loadGridClientes();
            
            Session["clienteActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridClientes()
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaClientesActivos();
            else
                LoadGrillaClientesInactivos();
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

            clienteActual.Codigo = int.Parse(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoCliente").ToString());
            clienteActual.Cuil = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "cuil").ToString();
            clienteActual.Direccion = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "direccion").ToString();
            clienteActual.Localidad = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "localidad").ToString();
            clienteActual.Mail = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "mail").ToString();
            clienteActual.Provincia = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "provincia").ToString();
            clienteActual.RazonSocial = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "razonSocial").ToString();
            clienteActual.Telefono = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "telefono").ToString();

            Session.Add("clienteActual", clienteActual);

            Response.Redirect("cliente.aspx");
        }

        protected void btnAceptarEliminarCliente_Click(object sender, EventArgs e)
        {
            ControladorGeneral.EliminarCliente(int.Parse(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoCliente").ToString()));
            Response.Redirect("listado.aspx");
        }

        
        protected void rbActivoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaClientesActivos();
            else
                LoadGrillaClientesInactivos();
        }

        protected void rbActivoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoNo.Checked == true)
                LoadGrillaClientesInactivos();
            else
                LoadGrillaClientesActivos();
        }              

        private void LoadGrillaClientesInactivos()
        {
            btnInactivarCliente.Visible = false;
            btnActivarCliente.Visible = true;
            btnEditar.Visible = false;
            gvClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(true);
            gvClientes.DataBind();
        }

        private void LoadGrillaClientesActivos()
        {
            btnInactivarCliente.Visible = true;
            btnEditar.Visible = true;
            btnActivarCliente.Visible = false;
            gvClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            gvClientes.DataBind();
        }

        protected void btnActivarCliente_Click(object sender, EventArgs e)
        {
            ActivarInactivarCliente();
            LoadGrillaClientesInactivos();
        }

        private void ActivarInactivarCliente()
        {
            ControladorGeneral.ActivarInactivarCliente(int.Parse(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoCliente").ToString()));
        }

        protected void btnAceptarInactivarCliente_Click(object sender, EventArgs e)
        {
            ActivarInactivarCliente();
            LoadGrillaClientesActivos();
        }
    }
}