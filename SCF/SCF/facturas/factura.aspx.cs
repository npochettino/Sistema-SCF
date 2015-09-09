using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;

namespace SCF.facturas
{
    public partial class factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFechaFacturacion.Value = DateTime.Now;
            CargarComboRemito();
        }

        private void CargarComboRemito()
        {
            //cbRemito.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(true);
            //cbRemito.DataBind();

            gluRemito.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(true);
            gluRemito.DataBind();
        }

        protected void cbRemito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Retorna el ultimo comprobante autorizado para el tipo de comprobante / cuit / punto de venta ingresado/ Tipo de Emisión
        //Enviar CUIT,PtoVta,CbteTipo
        protected void btnUltimoNroComprobante_Click(object sender, EventArgs e)
        {
            //pcUltimoComprobanteAfip.ShowOnPageLoad = true;
            Afip clsAfip = new Afip();

            lblUltimoNroComprobante.Text = Convert.ToString(clsAfip.ConsultarUltimoNro(2,1));

            pcUltimoComprobanteAfip.ShowOnPageLoad = true;
        }

        protected void btnEmitir_Click(object sender, EventArgs e)
        {
            pcValidarComprobante.ShowOnPageLoad = true;
        }

        protected void pcValidarComprobante_Unload(object sender, EventArgs e)
        {

        }

        protected void btnEmitirComprobante_Click(object sender, EventArgs e)
        {

        }
    }
}