using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            //cbRemito.DataSource = ControladorGeneral.RecuperarTodosRemitos();
            //cbRemito.DataBind();
        }

        protected void cbRemito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void txtIVA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}