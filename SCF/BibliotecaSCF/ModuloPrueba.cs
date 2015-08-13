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
            ControladorGeneral.InsertarActualizarArticuloCliente(0, 1, "00002313", 2, 4.50, 1);
        }
    }
}
