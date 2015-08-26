using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.proveedores
{
    public partial class proveedor : System.Web.UI.Page
    {
        Proveedor oProveedorActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Proveedor)Session["proveedorActual"] != null)
                {
                    CargarDatosParaEditar((Proveedor)Session["proveedorActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                }
            }
        }

        private void CargarDatosParaEditar(Proveedor oProveedorActual)
        {
            txtCUIL.Value = oProveedorActual.Cuil;
            txtRazonSocial.Value = oProveedorActual.RazonSocial;
            txtCiudad.Value = oProveedorActual.Localidad;
            txtDireccion.Value = oProveedorActual.Direccion;
            txtMail.Value = oProveedorActual.Mail;
            txtProvincia.Value = oProveedorActual.Provincia;
            txtTelefono.Value = oProveedorActual.Telefono;
            txtPersonaContacto.Value = oProveedorActual.PersonaContacto;
            txtBanco.Value = oProveedorActual.Banco;
            txtCBU.Value = oProveedorActual.Cbu;
            txtNroCuentaBancaria.Value = oProveedorActual.NumeroCuenta;
            txtObservacion.Value = oProveedorActual.Observaciones;
            txtFax.Value = oProveedorActual.Fax;
            //txtNroInternoCliente.Value = oProveedorActual.NumeroInterno.ToString();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oProveedorActual = (Proveedor)Session["proveedorActual"];
                ControladorGeneral.InsertarActualizarProveedor(oProveedorActual.Codigo, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, "fax", txtMail.Value, txtCUIL.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 0);
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarProveedor(0, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, "fax", txtMail.Value, txtCUIL.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 0);
            }
            Response.Redirect("listado.aspx");
        }
    }
}