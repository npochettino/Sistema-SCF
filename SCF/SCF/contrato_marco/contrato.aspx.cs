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
        const string UploadDirectory = "~/ArchivosGenerar/";

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

        protected void ucExcel_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            String ruta = SavePostedFile(e.UploadedFile);
            e.CallbackData = ruta;

            if (!String.IsNullOrEmpty(ruta))
            {
                //Creamos el string para conectar con el archivo de Excel y manejarlo como una base de datos
                string sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=" + ruta + ";" + "Extended Properties=Excel 8.0;";
                //Creamos la consula SELECT para leer una Hoja del Excel authors, como si fuera un SELECT a una tabla de SQL
                string sqlExcel = "Select * From [Hoja1$]";
                DataTable dt = new DataTable();
                //agregar para la version nueva
                //dt.Columns.Add("Linea", typeof(System.String));
                //dt.Columns.Add("Bandera", typeof(System.String));
                //dt.Columns.Add("Horario", typeof(System.String));
                //dt.Columns.Add("Servicio", typeof(System.String));
                //dt.Columns.Add("Dia Salida", typeof(System.String));
                //dt.Columns.Add("Duracion", typeof(System.String));
                //dt.Columns.Add("Hora Salida", typeof(System.String));
                //dt.Columns.Add("Hora Llegada", typeof(System.String));

                //Definimos la conexión OleDb al fichero Excel y la abrimos
                OleDbConnection oledbConn = new OleDbConnection(sConnectionString);
                oledbConn.Open();
                //Creamos un command para ejecutar la sentencia SELECT
                OleDbCommand oledbCmd = new OleDbCommand(sqlExcel, oledbConn);
                //Creamos un dataAdapter para leer los datos y asociarlos al DataTable
                OleDbDataAdapter da = new OleDbDataAdapter(oledbCmd);
                da.Fill(dt);

                //DataTable dt2 = new DataTable();
                //OleDbCommand oledbCmd2 = new OleDbCommand("Select * From [MediasVueltas$]", oledbConn);
                ////Creamos un dataAdapter para leer los datos y asociarlos al DataTable
                //OleDbDataAdapter da2 = new OleDbDataAdapter(oledbCmd2);
                //da2.Fill(dt2);

                //DataTable dt3 = new DataTable();
                //OleDbCommand oledbCmd3 = new OleDbCommand("Select * From [DistribucionesHorarias$]", oledbConn);
                ////Creamos un dataAdapter para leer los datos y asociarlos al DataTable
                //OleDbDataAdapter da3 = new OleDbDataAdapter(oledbCmd3);
                //da3.Fill(dt3);

                //DataTable dt4 = new DataTable();
                //OleDbCommand oledbCmd4 = new OleDbCommand("Select * From [DetallesDistribucionesHorarias$]", oledbConn);
                ////Creamos un dataAdapter para leer los datos y asociarlos al DataTable
                //OleDbDataAdapter da4 = new OleDbDataAdapter(oledbCmd4);
                //da4.Fill(dt4);

                //DataTable dt5 = new DataTable();
                //OleDbCommand oledbCmd5 = new OleDbCommand("Select * From [TiposDistribucionesHorarias$]", oledbConn);
                ////Creamos un dataAdapter para leer los datos y asociarlos al DataTable
                //OleDbDataAdapter da5 = new OleDbDataAdapter(oledbCmd5);
                //da5.Fill(dt5);
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dt);
                //ds.Tables.Add(dt2);
                //ds.Tables.Add(dt3);
                //ds.Tables.Add(dt4);
                //ds.Tables.Add(dt5);
                //Biblioteca.Controladores.Horarios.ControladorHorarios ctrlHor = new Biblioteca.Controladores.Horarios.ControladorHorarios();
                //ctrlHor.InsertarHorarioWeb(
                //Cerramos la conexion
                oledbConn.Close();

                //Validamos el archivo desde biblioteca
                //String mensaje = ctrlDespacho.ValidarArchivosXMLHorarioExcel(ref dt, Convert.ToInt32(Session["codigoEmpresa"]));

            }
        }

        protected string SavePostedFile(UploadedFile uploadedFile)
        {
            String rutaDelArchivo = "";
            if (uploadedFile.IsValid)
            {
                String ruta = ucExcel.PostedFile.FileName.ToString();//Obtengo la ruta del archivo
                String[] arrayRuta = ruta.Split('\\');
                Int16 orden = Convert.ToInt16(arrayRuta.Count());
                String fileName = arrayRuta[orden - 1]; //Obtengo el nombre del archivo que debe ser de extension xls
                rutaDelArchivo = MapPath(UploadDirectory) + fileName; //Me va a quedar en ~/ArchivosGenerar/NombreDelArchivo.xls
                uploadedFile.SaveAs(rutaDelArchivo);
                //File.Delete(tempFileName);
            }
            return rutaDelArchivo;
        }

        protected void ucExcel_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
        {
            int a = 0;
        }
    }
}