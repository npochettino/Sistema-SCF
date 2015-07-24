using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF;
using BibliotecaSCF.Controladores;

namespace SCF
{
    public partial class listado_proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGridProveedores();
            }
        }

        private void loadGridProveedores()
        {
            gvProveedoes.DataSource = ControladorGeneral.RecuperarTodosProveedores();
            gvProveedoes.DataBind();
        }
    }
}