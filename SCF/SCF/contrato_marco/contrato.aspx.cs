using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.contrato_marco
{
    public partial class contrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            cbCliente.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            cbCliente.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}