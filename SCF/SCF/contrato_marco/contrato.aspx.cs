using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using DevExpress.Web.ASPxUploadControl;

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
            DataTable tabla = OpenExcelFile("C:\\Eze\\SCF.xls");
            ControladorGeneral.InsertarActualizarContratoMarco(0, "CM 1", 2, DateTime.Now.AddYears(-1), DateTime.Now.AddYears(2), tabla);
        }

        protected DataTable OpenExcelFile(string fileName)
        {
            DataTable dataTable = new DataTable();
            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [scf$]", connectionString);
            adapter.Fill(dataTable);

            return dataTable;
        }

        protected void btnCargarGrilla_Click(object sender, EventArgs e)
        {
            DataTable tabla = OpenExcelFile("C:\\Eze\\SCF.xls");
            gvArticulos.DataSource = tabla;
            gvArticulos.DataBind();
        }
    }
}