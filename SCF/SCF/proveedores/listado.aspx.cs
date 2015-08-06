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

namespace SCF.proveedores
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            loadGridProveedores();
            
            Session["proveedorActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridProveedores()
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaProveedoresActivos();
            else
                LoadGrillaProveedoresInactivos();
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
            ControladorGeneral.EliminarProveedor(int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString()));
            Response.Redirect("listado.aspx");
        }

        protected void btnActivarProveedor_Click(object sender, EventArgs e)
        {
            ControladorGeneral.ActivarInactivarProveedor(int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString()));
            LoadGrillaProveedoresInactivos();
        }

        protected void rbActivoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaProveedoresActivos();
            else
                LoadGrillaProveedoresInactivos();
        }

        protected void rbActivoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoNo.Checked == true)
                LoadGrillaProveedoresInactivos();
            else
                LoadGrillaProveedoresActivos();
        }

        private void LoadGrillaProveedoresInactivos()
        {
            btnInactivarProveedor.Visible = false;
            btnEditar.Visible = false;
            btnActivarProveedor.Visible = true;
            gvProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores(true);
            gvProveedores.DataBind();
        }

        private void LoadGrillaProveedoresActivos()
        {
            btnInactivarProveedor.Visible = true;
            btnEditar.Visible = true;
            btnActivarProveedor.Visible = false;
            gvProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores(false);
            gvProveedores.DataBind();
        }

        protected void btnAceptarInactivarProveedor_Click(object sender, EventArgs e)
        {
            ControladorGeneral.ActivarInactivarProveedor(int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString()));
            LoadGrillaProveedoresActivos();
        }


    }
}