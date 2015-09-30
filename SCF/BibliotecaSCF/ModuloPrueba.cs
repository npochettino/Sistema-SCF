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
            List<int> l = new List<int>();
            l.Add(10);
            l.Add(11);
            ControladorGeneral.InsertarActualizarFactura(0, 1, DateTime.Now, l, 1, 1, 5, 100, 121, string.Empty);
        }
    }
}
