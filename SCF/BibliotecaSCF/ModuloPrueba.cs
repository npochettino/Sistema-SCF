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
            //DataTable t = ControladorGeneral.RecuperarTodosArticulos();
            //ControladorGeneral.InsertarActualizarArticulo(0, "prueba corta", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "marca prueba");
            //ControladorGeneral.InsertarActualizarArticulo(0, "prueba corta repetida", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "marca prueba");
            //ControladorGeneral.EliminarArticulo(2);
            //ControladorGeneral.InsertarActualizarArticulo(1, "prueba corta 2", "prueba largaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "marca prueba 2");
            //DataTable t2 = ControladorGeneral.RecuperarTodosArticulos();
            //ControladorGeneral.InsertarActualizarArticuloProveedor(0, 1, 545466, 3, 5.50, true);
            //ControladorGeneral.InsertarActualizarArticuloProveedor(4, 1, 2222, 4, 15.50, false);
            //ControladorGeneral.InsertarActualizarArticuloProveedor(4, 1, 1111, 4, 15.50, false);
            //ControladorGeneral.InsertarActualizarArticuloProveedor(4, 1, 1111, 4, 16.50, false);
            //DataTable t3 = ControladorGeneral.RecuperarArticulosProveedoresPorArticulo(1);
            //DataTable t4 = ControladorGeneral.RecuperarHistorialPreciosPorArticuloProveedor(4);
            ControladorGeneral.RecuperarContratosMarcoVigentePorCliente(1);


        }
    }
}
