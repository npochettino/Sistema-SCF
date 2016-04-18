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
    public partial class credito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tablaNotaCredito"] != null)
                { }
                else
                { 
                    CargarNumeroNotaCredito();
                    CargarComboFacturas();
                    txtFechaEmision.Value = DateTime.Now;
                }
            }
            else
            {

            }
            
                        
        }

        private void CargarComboFacturas()
        {
            //cbFactura.DataSource = ControladorGeneral.RecuperarTodasFacturasSinNotaCredito();
            //cbFactura.DataBind();
        }

        private void CargarNumeroNotaCredito()
        {
            //Obtengo el Ultimo numero de nota de Credito y le sumo 1.
            //DataTable tablaUltimaNotaCredito = ControladorGeneral.RecuperarUltimaNotaCredito();
            //txtNotaCredito.Value = tablaUltimaNotaCredito.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaNotaCredito.Rows[0]["numeroNotaCredito"]) + 1).ToString() : "1";
        }

        //Retorna el ultimo comprobante autorizado para el tipo de comprobante / cuit / punto de venta ingresado/ Tipo de Emisión
        //Enviar CUIT,PtoVta,CbteTipo
        protected void btnUltimoNroComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                lblUltimoNroComprobante.Text = Convert.ToString(ControladorGeneral.ConsultarUltimoNroComprobante(2, 3));
                pcUltimoComprobanteAfip.ShowOnPageLoad = true;
            }
            catch
            {
                lblError.Text = "Ha ocurrido un error. No hay conexion con los servidor de AFIP, vuelva a intentar.";
                pcError.ShowOnPageLoad = true;
            }
        }

        protected void cbFactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateImporte_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void gvItemsEntrega_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

        }

        protected void gvItemsEntrega_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {

        }
    }
}