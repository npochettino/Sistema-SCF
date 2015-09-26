using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.contrato_marco
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }

            gvContratosMarco.DataSource = ControladorGeneral.RecuperarTodosContratosMarcos(true);
            gvContratosMarco.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("contrato.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptarEliminarContratoMarco_Click(object sender, EventArgs e)
        {
            //Falta el desarrollo del metodo que devuelve un string.
            //string mensaje = ControladorGeneral.EliminarContratoMarco(int.Parse(gvContratosMarco.GetRowValues(gvContratosMarco.FocusedRowIndex, "codigoContratoMarco").ToString()));
            //lblError.Text = mensaje;
            pcError.ShowOnPageLoad = true;
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            pcShowDetalleContratoMarco.ShowOnPageLoad = true;
        }
    }
}