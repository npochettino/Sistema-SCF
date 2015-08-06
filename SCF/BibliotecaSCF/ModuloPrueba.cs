using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF
{
    class ModuloPrueba
    {
        public static void Main()
        {
            //ControladorGeneral.InsertarActualizarArticulo(0, "LINTERNA BOLIGRAFO METAL PENLIGHT    *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "FICHA STECK 2P+T S-2078              *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "TOMACORRIENTE ACOPLE STECK S-2058    *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "CAÑO FLEXIBLE ACERO GALVAN. (PVC) 3/4*I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "FICHA BIPOLAR 250V 16A S-2076        *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "CAÑO FLEXIBLE ZOLODA LT-13 1\" PVC.   *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "PILA DE LITIO 3V ( CR2450)           *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "FLASHLIGHT,AAA,BLACK MAG-LITE M3A756K*I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "CAÑO FLEX P/PROT COND ELECTR 12,7MM  *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "FLEXIBLE ACERO GALVANIZADO           *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "PILA RECARGABLE N-M 1,2 V 1700 MAH  A*I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "CABLECANAL DE 40X40 CON RANURA.TIPO E*I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "CAJA (GABINETE) CHAPA 300 X 300 X 150*I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "FUSIBLE;FERRAZ;2                     *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "FLEXIBLE ACERO GALVANIZADO           *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "PILA RECARGABLE 1,2 V NH12-750 / AAA *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "BATERIA ALCALINA 1.5 V 11.6 X 5.4 MM *I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "TOMACORRIENTE EXT 250V 16A STECK S-21*I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "TOMACORRIENTE EXTERIOR 3P+T 32A 380VC*I*", "", "Marca 1");
            //ControladorGeneral.InsertarActualizarArticulo(0, "CAJA (GABINETE) CHAPA 450X450X300 MM *I*", "", "Marca 1");

            //DateTime fechahora = DateTime.Now.AddDays(-1);

            //DataTable tabla = new DataTable();
            //tabla.Columns.Add("codigoItemNotaDePedido");
            //tabla.Columns.Add("codigoArticulo");
            //tabla.Columns.Add("cantidad");
            //tabla.Columns.Add("fechaEntrega");

            //tabla.Rows.Add(new object[] {0, 1, 10, "05/08/2015 00:00:00"});

            //ControladorGeneral.InsertarActualizarNotaDePedido(0, "0000001415456", fechahora, "", 0, 1, tabla);

            DateTime fechahora2 = DateTime.Now.AddDays(-1);

            DataTable tabla2 = new DataTable();
            tabla2.Columns.Add("codigoItemNotaDePedido");
            tabla2.Columns.Add("codigoArticulo");
            tabla2.Columns.Add("cantidad");
            tabla2.Columns.Add("fechaEntrega");

            tabla2.Rows.Add(new object[] { 0, 7, 10, "10/08/2015 00:00:00" });
            tabla2.Rows.Add(new object[] { 0, 6, 10, "12/08/2015 00:00:00" });
            tabla2.Rows.Add(new object[] { 0, 5, 10, "15/08/2015 00:00:00" });

            ControladorGeneral.InsertarActualizarNotaDePedido(0, "004145646", fechahora2, "", 0, 1, tabla2);

            DateTime fechahora3 = DateTime.Now.AddDays(-1);

            DataTable tabla3 = new DataTable();
            tabla3.Columns.Add("codigoItemNotaDePedido");
            tabla3.Columns.Add("codigoArticulo");
            tabla3.Columns.Add("cantidad");
            tabla3.Columns.Add("fechaEntrega");

            tabla3.Rows.Add(new object[] { 0, 8, 10, "15/08/2015 00:00:00" });
            tabla3.Rows.Add(new object[] { 0, 9, 10, "20/08/2015 00:00:00" });
            tabla3.Rows.Add(new object[] { 0, 5, 10, "20/08/2015 00:00:00" });

            ControladorGeneral.InsertarActualizarNotaDePedido(0, "0000087489", fechahora3, "", 0, 1, tabla3);

            DateTime fechahora4 = DateTime.Now.AddDays(-1);

            DataTable tabla4 = new DataTable();
            tabla4.Columns.Add("codigoItemNotaDePedido");
            tabla4.Columns.Add("codigoArticulo");
            tabla4.Columns.Add("cantidad");
            tabla4.Columns.Add("fechaEntrega");

            tabla4.Rows.Add(new object[] { 0, 10, 10, "07/08/2015 00:00:00" });

            ControladorGeneral.InsertarActualizarNotaDePedido(0, "2313", fechahora4, "", 0, 1, tabla4);
        }
    }
}
