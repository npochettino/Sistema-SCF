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
            ControladorGeneral.InsertarActualizarProveedor(1, "Razon Pepe", "Santa Fe", "Rosario", "Viamonte 67 bis", "4586593", "pepe@pepe.com", "20-65656565-2");
            DataTable t1 = ControladorGeneral.RecuperarTodosProveedores();
        }
    }
}
