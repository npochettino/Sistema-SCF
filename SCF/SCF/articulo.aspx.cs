using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCF
{
    public partial class articulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarArticuloProveedor_Click(object sender, EventArgs e)
        {
            pcArticuloProveedor.ShowOnPageLoad = true;
            
        }

        protected void btnEliminarArticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarArticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarPrecio_Click(object sender, EventArgs e)
        {
            pcAddPrecio.ShowOnPageLoad = true;
        }

        protected void btnEliminarPrecio_Click(object sender, EventArgs e)
        {

        }
    }
}