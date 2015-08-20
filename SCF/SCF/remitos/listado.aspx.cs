using BibliotecaSCF.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCF.remitos
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            gvEntregas.DataSource = ControladorGeneral.RecuperarTodasEntregas();
            gvEntregas.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["tablaEntrega"] = null;
            Response.Redirect("remito.aspx");
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
            int codigoNotaDePedido = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoNotaDePedido"));
            int codigoCliente = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoCliente"));
            string razonSocialCliente = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialCliente").ToString();
            DateTime fechaEmision = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaEmision"));
            int numeroRemito = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroRemito"));
            int codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
            string observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();

            DataTable tablaEntrega = new DataTable();
            tablaEntrega.Columns.Add("codigoEntrega");
            tablaEntrega.Columns.Add("codigoNotaDePedido");
            tablaEntrega.Columns.Add("codigoCliente");
            tablaEntrega.Columns.Add("razonSocialCliente");
            tablaEntrega.Columns.Add("fechaEmision");
            tablaEntrega.Columns.Add("numeroRemito");
            tablaEntrega.Columns.Add("codigoEstado");
            tablaEntrega.Columns.Add("observaciones");

            tablaEntrega.Rows.Add(new object[] { codigoEntrega, codigoNotaDePedido, codigoCliente, razonSocialCliente, fechaEmision, numeroRemito, codigoEstado, observaciones });

            Session["tablaEntrega"] = tablaEntrega;

            Response.Redirect("remito.aspx");
        }

        protected void btnAceptarEliminarRemito_Click(object sender, EventArgs e)
        {
            int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));

        }
    }
}