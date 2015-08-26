﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
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
            //CargarClientes();

            if (Session["tablaItemsContratoMarco"] != null)
            {
                gvArticulos.DataSource = (DataTable)Session["tablaItemsContratoMarco"];
                gvArticulos.DataBind();
            }
        }

        private void CargarClientes()
        {
            //cbCliente.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            //cbCliente.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["rutaExcel"] == null)
            {
                pcError.ShowOnPageLoad = true;
                lblError.Text = "Debe cargar la grilla";
            }
            else
            {

                DataTable tabla = OpenExcelFile(Session["rutaExcel"].ToString());
                string rta = ControladorGeneral.InsertarContratosMarcosPorTabla(tabla);

                if (rta != "ok")
                {
                    pcError.ShowOnPageLoad = true;
                    lblError.Text = rta;
                }

                Session["rutaExcel"] = null;
            }
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
            if (fuExcel.HasFile)
            {
                string path = Server.MapPath(".") + "\\contratos\\" + fuExcel.FileName;
                fuExcel.PostedFile.SaveAs(path);
                StreamReader reader = new StreamReader(fuExcel.FileContent);
                string text = reader.ReadToEnd();
                Session.Add("rutaExcel", path);

                DataTable tabla = OpenExcelFile(path);
                gvArticulos.DataSource = tabla;
                gvArticulos.DataBind();

                Session["tablaItemsContratoMarco"] = tabla;
            }
        }
    }
}