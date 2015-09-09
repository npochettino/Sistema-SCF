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
    public partial class cliente : System.Web.UI.Page
    {
        Cliente oClienteActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Cliente)Session["clienteActual"] != null)
                {
                    CargarDatosParaEditar((Cliente)Session["clienteActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                }
            }
            CargarComboTipoDocumento();
        }

        private void CargarDatosParaEditar(Cliente oClienteActual)
        {
            ddlTipoDocumento.Text = oClienteActual.TipoDocumento.Descripcion;
            
            txtNroDocumento.Value = oClienteActual.NumeroDocumento;
            txtRazonSocial.Value = oClienteActual.RazonSocial;
            txtCiudad.Value = oClienteActual.Localidad;
            txtDireccion.Value = oClienteActual.Direccion;
            txtMail.Value = oClienteActual.Mail;
            txtProvincia.Value = oClienteActual.Provincia;
            txtTelefono.Value = oClienteActual.Telefono;
            txtPersonaContacto.Value = oClienteActual.PersonaContacto;
            txtBanco.Value = oClienteActual.Banco;
            txtCBU.Value = oClienteActual.Cbu;
            txtNroCuentaBancaria.Value = oClienteActual.NumeroCuenta;
            txtObservacion.Value = oClienteActual.Observaciones;
            txtFax.Value = oClienteActual.Fax;
        }

        private void CargarComboTipoDocumento()
        {
            //ddlTipoDocumento.DataSource = ControladorGeneral.RecuperarTodosTipoDocumento();
            //ddlTipoDocumento.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oClienteActual = (Cliente)Session["clienteActual"];
                ControladorGeneral.InsertarActualizarCliente(oClienteActual.Codigo, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, txtFax.Value, txtMail.Value,txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 0, 80); //agregar tipo documento
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarCliente(0, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, txtMail.Value, txtFax.Value, txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 0, 80); //agregar tipo documento
            }
            Response.Redirect("listado.aspx");
        }
    }
}