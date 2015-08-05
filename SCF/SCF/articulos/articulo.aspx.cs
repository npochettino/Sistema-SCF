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
    public partial class articulo : System.Web.UI.Page
    {
        Articulo oArticuloActual;
        private int codigoOperacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Articulo)Session["articuloActual"] != null)
                {
                    CargarDatosParaEditar((Articulo)Session["articuloActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                }
            }
        }

        private void CargarDatosParaEditar(Articulo oArticuloActual)
        {
            txtDescripcionCorta.Value = oArticuloActual.DescripcionCorta;
            txtDescripcionLarga.Value = oArticuloActual.DescripcionLarga;
            txtMarca.Value = oArticuloActual.Marca;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oArticuloActual = (Articulo)Session["articuloActual"];
                ControladorGeneral.InsertarActualizarArticulo(oArticuloActual.Codigo, txtDescripcionCorta.Value, txtDescripcionLarga.Value, txtMarca.Value);
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarArticulo(0, txtDescripcionCorta.Value, txtDescripcionLarga.Value, txtMarca.Value);
            }
            Response.Redirect("articulo.aspx");
        }

        protected void btnEditarArticuloProveedor_Click(object sender, EventArgs e)
        {
            pcArticuloProveedor.ShowOnPageLoad = true;
            
        }

        protected void btnEliminarArticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarArticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarPrecio_Click(object sender, EventArgs e)
        {
            pcAddPrecio.ShowOnPageLoad = true;
        }

        protected void btnEliminarPrecio_Click(object sender, EventArgs e)
        {

        }

        protected void btnGurdarAticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarAddPrecio_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarAddCosto_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptarEliminarArticuloProveedor_Click(object sender, EventArgs e)
        {

        }
    }
}