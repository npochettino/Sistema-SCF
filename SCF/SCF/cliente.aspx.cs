using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF
{
    public partial class cliente : System.Web.UI.Page
    {
        Cliente oClienteActual;
        private int codigoOperacion;

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
        }

        private void CargarDatosParaEditar(Cliente oClienteActual)
        {
            txtCUIL.Value = oClienteActual.Cuil;
            txtRazonSocial.Value = oClienteActual.RazonSocial;
            txtCiudad.Value = oClienteActual.Localidad;
            txtDireccion.Value = oClienteActual.Direccion;
            txtMail.Value = oClienteActual.Mail;
            txtProvincia.Value = oClienteActual.Provincia;
            txtTelefono.Value = oClienteActual.Telefono;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oClienteActual = (Cliente)Session["clienteActual"];
                ControladorGeneral.InsertarActualizarCliente(oClienteActual.Codigo, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, txtMail.Value, txtCUIL.Value);
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarCliente(0, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, txtMail.Value, txtCUIL.Value);
            }
            Response.Redirect("listado_clientes.aspx");
        }
    }
}