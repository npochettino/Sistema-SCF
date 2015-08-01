using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF
{
    public partial class listado_proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGridProveedores();
            }
            Session["proveedorActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridProveedores()
        {
            gvProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores();
            gvProveedores.DataBind();

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoProveedor();
        }

        private void NuevoProveedor()
        {
            Response.Redirect("proveedor.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarProveedor();
        }

        private void EditarProveedor()
        {
            Proveedor proveedorActual = new Proveedor();

            proveedorActual.Codigo = int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString());
            proveedorActual.Cuil = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "cuil").ToString();
            proveedorActual.Direccion = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "direccion").ToString();
            proveedorActual.Localidad = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "localidad").ToString();
            proveedorActual.Mail = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "mail").ToString();
            proveedorActual.Provincia = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "provincia").ToString();
            proveedorActual.RazonSocial = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "razonSocial").ToString();
            proveedorActual.Telefono = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "telefono").ToString();

            Session.Add("proveedorActual", proveedorActual);

            Response.Redirect("proveedor.aspx");
        }
               
        protected void btnAceptarEliminarProveedor_Click(object sender, EventArgs e)
        {

<<<<<<< HEAD
=======
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar proveedor
            //string test = "";
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
>>>>>>> Se agregan metodos de usuarios y clientes
        }



    }
}