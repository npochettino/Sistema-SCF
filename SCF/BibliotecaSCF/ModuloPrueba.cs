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
            DataTable t = ControladorGeneral.RecuperarItemsNotaDePedido(4);
            //ControladorGeneral.InsertarActualizarArticulo(0, "Articulo con precio", "", "Marca 3", "Articulo.jpg", 2.5, 3);
            //ControladorGeneral.InsertarActualizarArticuloCliente(0, 1, "00002313", 2);
        }
    }
}
