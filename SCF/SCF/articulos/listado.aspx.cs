using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.articulos
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            if (string.IsNullOrEmpty(txtCodigoCliente.Text))
            {
                loadGridArticulos();
            }
            else
            {
                gvArticulos.DataSource = ControladorGeneral.RecuperarArticuloPorCodigoInternoCliente(txtCodigoCliente.Text);
                gvArticulos.DataBind();
                gvArticulos.Columns["codigoCliente"].Visible = false;
                gvArticulos.Columns["razonSocialCliente"].Visible = true;
                gvArticulos.Columns["codigoArticuloCliente"].Visible = true;
            }

            Session["articuloActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridArticulos()
        {
            gvArticulos.DataSource = ControladorGeneral.RecuperarTodosArticulos();
            gvArticulos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoArticulo();
        }

        private void NuevoArticulo()
        {
            Response.Redirect("articulo.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarArticulo();
        }

        private void EditarArticulo()
        {
            cargarArticuloEnVariableSession();

            Response.Redirect("articulo.aspx");
        }

        private void cargarArticuloEnVariableSession()
        {
            Articulo articuloActual = new Articulo();

            articuloActual.Codigo = int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString());
            articuloActual.DescripcionCorta = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "descripcionCorta").ToString();
            articuloActual.DescripcionLarga = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "descripcionLarga").ToString();
            articuloActual.Marca = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "marca").ToString();
            
            //Como recupero la unidad de medida

            Session.Add("articuloActual", articuloActual);
        }

        protected void btnAceptarEliminarArticulo_Click(object sender, EventArgs e)
        {
            if (gvArticulos.FocusedRowIndex != -1)
            {
                try
                {
                    ControladorGeneral.EliminarArticulo(int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString()));
                    loadGridArticulos();
                }
                catch { }
            }
        }

        protected void btnBuscarPorCodigoCliente_Click(object sender, EventArgs e)
        {
            gvArticulos.DataSource = ControladorGeneral.RecuperarArticuloPorCodigoInternoCliente(txtCodigoCliente.Text);
            gvArticulos.DataBind();

            gvArticulos.Columns["codigoCliente"].Visible = true;
            gvArticulos.Columns["razonSocialCliente"].Visible = true;
            gvArticulos.Columns["codigoArticuloCliente"].Visible = true;

        }

        protected void btnRelacionArticuloCliente_Click(object sender, EventArgs e)
        {
            cargarArticuloEnVariableSession();
            cargarGrillaRelacionArticuloCliente();
        }

        private void cargarGrillaRelacionArticuloCliente()
        {
            cbClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            cbClientes.DataBind();

            if (gvArticulos.FocusedRowIndex != -1)
            {
                gvArticuloCliente.DataSource = ControladorGeneral.RecuperarArticulosClientesPorArticulo(int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString()));
                gvArticuloCliente.DataBind();
            }

            pcRelacionArticuloCliente.ShowOnPageLoad = true;
        }

        protected void btnEliminarRelacionArticuloCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarRelacionArticuloCliente_Click(object sender, EventArgs e)
        {
            int test = int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString());
            cargarArticuloEnVariableSession();
            Articulo mArticulo = (Articulo)Session["articuloActual"];
            if (!txtCodigoClienteArticulo.Text.Equals(""))
                ControladorGeneral.InsertarActualizarArticuloCliente(0, mArticulo.Codigo, txtCodigoClienteArticulo.Text.ToString(), (int)cbClientes.SelectedItem.Value);


            pcNuevaRelacionArticuloCliente.ShowOnPageLoad = false;
            cargarGrillaRelacionArticuloCliente();
        }

        protected void pcRelacionArticuloCliente_Unload(object sender, EventArgs e)
        {
            if (gvArticulos.FocusedRowIndex != -1)
            {
                Articulo mArticulo = (Articulo)Session["articuloActual"];

                gvArticuloCliente.DataSource = ControladorGeneral.RecuperarArticulosClientesPorArticulo(mArticulo.Codigo);
                gvArticuloCliente.DataBind();
            }

        }

        protected void pcNuevaRelacionArticuloCliente_Unload(object sender, EventArgs e)
        {
            cbClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);

            cbClientes.DataBind();
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            pcShowDetalleArticulo.ShowOnPageLoad = true;


            int codigoArticulo = int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString());
            txtDescripcionCorta.InnerText = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "descripcionCorta").ToString();
            txtDescripcionLarga.InnerText = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "descripcionLarga").ToString();
            txtMarca.Value = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "marca").ToString();
            //txtUnidadDeMedida.Value = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "unidadDeMedida").ToString();
            txtPrecioActual.Value = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "precio").ToString();
            //txtUnidadDeMedida.Value = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "unidadMedida").ToString();

            gvCliente.DataSource = ControladorGeneral.RecuperarArticulosClientesPorArticulo(codigoArticulo);
            gvCliente.DataBind();
            gvArticuloProveedores.DataSource = ControladorGeneral.RecuperarArticulosProveedoresPorArticulo(codigoArticulo);
            gvArticuloProveedores.DataBind();
        }


        protected void btnConfirmarEliminarRelacionArticuloCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            loadGridArticulos();
            gvArticulos.Columns["codigoCliente"].Visible = false;
            gvArticulos.Columns["razonSocialCliente"].Visible = false;
            gvArticulos.Columns["codigoArticuloCliente"].Visible = false;
        }

        //protected void BtnNuevaRelacionCliente_Click(object sender, EventArgs e)
        //{
        //    pcNuevaRelacionArticuloCliente.ShowOnPageLoad = true;

        //    cbClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
        //    cbClientes.DataBind();


        //}

        #region Relacion Articulo Proveedor

        protected void btnRelacionArticuloProvevedor_Click(object sender, EventArgs e)
        {

            cbMonedaCosto.DataSource = ControladorGeneral.RecuperarTodasMonedas();
            cbMonedaCosto.DataBind();
            cbProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores(false);
            cbProveedores.DataBind();

            pcRelacionArticuloProveedor.ShowOnPageLoad = true;
        }

        protected void btnConfirmarEliminarRelacionArticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarRelacionArticuloProveedor_Click(object sender, EventArgs e)
        {
            //int test = int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString());
            //cargarArticuloEnVariableSession();
            //Articulo mArticulo = (Articulo)Session["articuloActual"];
            //if (!txtCosto.Text.Equals(""))
            //    ControladorGeneral.InsertarActualizarArticuloProveedor(0, mArticulo.Codigo, (int)cbProveedores.SelectedItem.Value, Double.Parse(txtCosto.Text), (int)cbMonedaCosto.SelectedItem.Value);


            //pcNuevaRelacionArticuloCliente.ShowOnPageLoad = false;
            //cargarGrillaRelacionArticuloCliente();
        }

        #endregion

        protected void pcRelacionArticuloProveedor_Unload(object sender, EventArgs e)
        {

        }

        protected void pcNuevaRelacionArticuloProveedor_Unload(object sender, EventArgs e)
        {

        }

    }
}