using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;
using DevExpress.Web.ASPxGridView;

namespace SCF.facturas
{
    public partial class factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tablaFactura"] != null)
                {

                }
                else
                {
                    CargarNumeroDeFactura();
                }

            }
            else
            {
                
            }
            txtFechaFacturacion.Value = DateTime.Now;
            CargarComboRemito();
            CargarComboTipoComprobante();
            CargarComboConcepto();
            CargarComboTipoMoneda();
            CargarNumeroDeFactura();
        }

        private void CargarNumeroDeFactura()
        {
            //Obtengo el Ultimo numero de factura y le sumo 1.
            DataTable tablaUltimaFactura = ControladorGeneral.RecuperarUltimaFactura();
            txtNroFactura.Text = tablaUltimaFactura.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaFactura.Rows[0]["numeroFactura"]) + 1).ToString() : string.Empty;
        }

        private void CargarComboTipoMoneda()
        {
            cbTipoMoneda.DataSource = ControladorGeneral.RecuperarTodasMonedas();
            cbTipoMoneda.DataBind();
        }

        private void CargarComboConcepto()
        {
            cbConcepto.DataSource = ControladorGeneral.RecuperarTodosConceptos();
            cbConcepto.DataBind();
        }

        private void CargarComboTipoComprobante()
        {
            cbTipoComprobante.DataSource = ControladorGeneral.RecuperarTodosTipoComprobantes();
            cbTipoComprobante.DataBind();
        }

        private void CargarComboRemito()
        {
            gluRemito.DataSource = ControladorGeneral.RecuperarTodasEntregas();
            gluRemito.DataBind();
        }

        //Retorna el ultimo comprobante autorizado para el tipo de comprobante / cuit / punto de venta ingresado/ Tipo de Emisión
        //Enviar CUIT,PtoVta,CbteTipo
        protected void btnUltimoNroComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                lblUltimoNroComprobante.Text = Convert.ToString(ControladorGeneral.ConsultarUltimoNroComprobante(2, 1));
                pcUltimoComprobanteAfip.ShowOnPageLoad = true;
            }
            catch
            {
                lblError.Text = "Ha ocurrido un error. No hay conexion con los servidor de AFIP, vuelva a intentar.";
                pcError.ShowOnPageLoad = true;
            }
        }

        protected void btnEmitir_Click(object sender, EventArgs e)
        {
            lblNroFacturaAEmitir.Text = txtNroFactura.Text;
            lblCondicionVenta.Text = cbCondicionVenta.Text;
            lblDomicilio.Text = "";
            lblNombreApellidoCliente.Text = txtRazonSocial.Text;
            lblNroRemitos.Text = gluRemito.Text;
            lblNumeroDocumento.Text = txtNroDocumento.Text;
            lblTipoDocumento.Text = "CUIT";
            lblFechaVencimientoCAE.Text = "";
            lblNroCAE.Text = "";
            lblImporteSubtotal.Text = txtSubtotal.Text;
            lblImporteTotal.Text = txtTotal.Text;

            pcValidarComprobante.ShowOnPageLoad = true;
        }
        
        protected void btnEmitirComprobante_Click(object sender, EventArgs e)
        {
            object[] arrayListRemitos = (object[])Session["listRemitos"];
            List<int> codigoRemitos = new List<int>();
            foreach(object[] itmes in arrayListRemitos)
            {
                codigoRemitos.Add(Convert.ToInt32(itmes[0].ToString()));
            }

            ControladorGeneral.InsertarActualizarFactura(0, Convert.ToInt32(txtNroFactura.Text), Convert.ToDateTime(txtFechaFacturacion.Text), codigoRemitos, Convert.ToInt32(cbTipoMoneda.ValueField), Convert.ToInt32(cbConcepto.ValueField),
               Convert.ToInt32(cbCondicionIVA.ValueField), Convert.ToDouble(txtSubtotal.Text), Convert.ToDouble(txtTotal.Text));

            //Obtengo ultimo codigo de factura y emito la factura
            DataTable tablaUltimaFactura = ControladorGeneral.RecuperarUltimaFactura();
            string codigoFactura = tablaUltimaFactura.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaFactura.Rows[0]["codigoFactura"])).ToString() : string.Empty;
            try 
            {
                ControladorGeneral.EmitirFactura(Convert.ToInt32(codigoFactura)); 
            }
            catch 
            {
                lblError.Text = "Ha ocurrido un error. No hay conexion con los servidor de AFIP, vuelva a intentar.";
                pcError.ShowOnPageLoad = true;
            }
            
        }

        protected void gluRemito_TextChanged(object sender, EventArgs e)
        {
            string[] myFields = { "codigoEntrega","numeroRemito", "razonSocialCliente", "cuitCliente" };
            List<Object> nroRemitosActual = gluRemito.GridView.GetSelectedFieldValues(myFields);

            if (nroRemitosActual.Count > 0)
            {
                foreach (object[] item in nroRemitosActual)
                {
                    txtRazonSocial.Text = item[2].ToString();
                    txtNroDocumento.Text = item[3].ToString();
                }
            }
            
            CargarItemsDeLaFactura(nroRemitosActual);
        }

        protected void btnObtenerDatosRemito_Click(object sender, EventArgs e)
        {
            ObtenerDatosRemito();
        }

        private void ObtenerDatosRemito()
        {
            string[] myFields = { "codigoEntrega", "numeroRemito", "razonSocialCliente", "cuitCliente" };
            List<Object> nroRemitosActual = gluRemito.GridView.GetSelectedFieldValues(myFields);
            Session["listRemitos"] = nroRemitosActual;

            if (nroRemitosActual.Count > 0)
            {
                foreach (object[] item in nroRemitosActual)
                {
                    txtRazonSocial.Text = item[2].ToString();
                    txtNroDocumento.Text = item[3].ToString();
                }
            }

            CargarItemsDeLaFactura(nroRemitosActual);
        }

        private void CargarItemsDeLaFactura(List<object> nroRemitosActual)
        {
            foreach (object[] item in nroRemitosActual)
            {
                gvItemsFactura.DataSource = ControladorGeneral.RecuperarItemsEntrega(Convert.ToInt32(item[0].ToString()));
                gvItemsFactura.DataBind();
            }

        }
    }
}