using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.credito
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            //gvNotaCredito.DataSource = ControladorGeneral.RecuperarTodasNotaCredito();
            //gvNotaCredito.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["tablaNotaCredito"] = null;
            Session["tablaItemsNotaCredito"] = null;
            Response.Redirect("credito.aspx");
        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (gvNotaCredito.FocusedRowIndex != -1)
            {
                DataTable tableNotaCreditoActual = GetTablaNotaCreditoActualSession();
                Session["tablaNotaCredito"] = tableNotaCreditoActual;
                Response.Write("<script>window.open('generar_pdf.aspx','_blank');</script>");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar una Nota de Credito para poder generar el PDF.";
                pcError.ShowOnPageLoad = true;
            }
        }

        private DataTable GetTablaNotaCreditoActualSession()
        {
            throw new NotImplementedException();
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptarEliminarNotaCredito_Click(object sender, EventArgs e)
        {
            if (gvNotaCredito.FocusedRowIndex != -1)
            {
                pcConfirmarEliminarNotaCredito.ShowOnPageLoad = false;
                try
                {
                    if (gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cai").ToString() == "")
                    {
                        //ControladorGeneral.EliminarNotaCredito(int.Parse(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaCredito").ToString()));
                        Response.Redirect("listado.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "La Nota de Credito posee CAI, no puede ser eliminada";
                        pcError.ShowOnPageLoad = true;
                    }

                }

                catch
                {
                    //Muestro el mensaje que me devuelve del metodo Eliminar
                    lblMensaje.Text = "No se pude eliminar la NC";
                    pcError.ShowOnPageLoad = true;
                }
            }
        }
    }
}