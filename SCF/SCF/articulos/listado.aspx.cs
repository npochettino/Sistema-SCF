﻿using System;
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

            loadGridArticulos();

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

            Session.Add("articuloActual", articuloActual);
        }

        protected void btnAceptarEliminarArticulo_Click(object sender, EventArgs e)
        {
            ControladorGeneral.EliminarArticulo(int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString()));
            gvArticulos.DataBind();
        }

        protected void btnBuscarPorCodigoCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnRelacionArticuloCliente_Click(object sender, EventArgs e)
        {
            pcRelacionArticuloCliente.ShowOnPageLoad = true;
        }

        protected void btnEliminarRelacionArticuloCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevaRelacionArticuloCliente_Click(object sender, EventArgs e)
        {
            pcNuevaRelacionArticuloCliente.ShowOnPageLoad = true;
            cargarArticuloEnVariableSession();
        }

        protected void btnGuardarRelacionArticuloCliente_Click(object sender, EventArgs e)
        {
            Articulo mArticulo = (Articulo)Session["articuloActual"];
            if (!txtCodigoClienteArticulo.Value.Equals(""))
                ControladorGeneral.InsertarActualizarArticuloCliente(0, mArticulo.Codigo, txtCodigoClienteArticulo.Value.ToString(), (int)cbClientes.SelectedItem.Value);
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
        }

        protected void btnConfirmarEliminarRelacionArticuloCliente_Click(object sender, EventArgs e)
        {

        }

    }
}