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
            ControladorGeneral.RecuperarFacturasPorFechas(DateTime.Now.AddDays(-40), DateTime.Now);


        }
    }
}
