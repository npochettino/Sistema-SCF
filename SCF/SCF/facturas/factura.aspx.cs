﻿using System;
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
            txtNroFactura.Text = "1"; 
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
            //ControladorGeneral.InsertarActualizarFactura(0,txtNroFactura.Text,txtFechaFacturacion.Text,
            
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

        private void CargarItemsDeLaFactura(List<object> nroRemitos)
        {
            foreach (object[] item in nroRemitos)
            {
                //DataTable dtItemsFactura = ControladorGeneral.RecuperarItemsEntrega(Convert.ToInt32(item[0].ToString()));
            }
            
        }
    }
}