using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.transportes
{
    public partial class transporte : System.Web.UI.Page
    {
        Transporte oTransporteActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Transporte)Session["transporteActual"] != null)
                {
                    CargarDatosParaEditar((Transporte)Session["transporteActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                }
            }
            CargarComboTipoDocumento();
        }

        private void CargarDatosParaEditar(Transporte transporte)
        {
            cbTipoDocumento.SelectedItem = cbTipoDocumento.Items.FindByValue(oTransporteActual.TipoDocumento.Codigo);

            txtNroDocumento.Value = oTransporteActual.NumeroDocumento;
            txtRazonSocial.Value = oTransporteActual.RazonSocial;
            txtCiudad.Value = oTransporteActual.Localidad;
            txtDireccion.Value = oTransporteActual.Direccion;
            txtMail.Value = oTransporteActual.Mail;
            txtProvincia.Value = oTransporteActual.Provincia;
            txtTelefono.Value = oTransporteActual.Telefono;
            txtPersonaContacto.Value = oTransporteActual.PersonaContacto;
            txtBanco.Value = oTransporteActual.Banco;
            txtCBU.Value = oTransporteActual.Cbu;
            txtNroCuentaBancaria.Value = oTransporteActual.NumeroCuenta;
            txtObservacion.Value = oTransporteActual.Observaciones;
            txtFax.Value = oTransporteActual.Fax;

        }

        private void CargarComboTipoDocumento()
        {
            cbTipoDocumento.DataSource = ControladorGeneral.RecuperarTodosTiposDocumentos();
            cbTipoDocumento.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oTransporteActual = (Transporte)Session["transporteActual"];
                ControladorGeneral.InsertarActualizarTransporte(oTransporteActual.Codigo, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, 
                    txtFax.Value, txtMail.Value, txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 80); //agregar tipo documento
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarTransporte(0, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, txtMail.Value, txtFax.Value,
                    txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 80); //agregar tipo documento
            }
            Response.Redirect("listado.aspx");
        }
    }
}