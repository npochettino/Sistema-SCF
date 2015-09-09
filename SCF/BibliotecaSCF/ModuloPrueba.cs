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
            ControladorGeneral.InsertarActualizarFactura(0, 1, DateTime.Now, 10, 1, 1, 5, 10, 12.1);
        }
    }
}
