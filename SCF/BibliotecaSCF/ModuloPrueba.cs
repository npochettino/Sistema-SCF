using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Catalogos;

namespace BibliotecaSCF
{
    class ModuloPrueba
    {
        public static void Main()
        {

            //ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            ControladorGeneral.InsertarActualizarNotaDeCredito(0, 19, 15, true, 5, DateTime.Now, 1, new DataTable());
            ControladorGeneral.RecuperarNotaDeCredito(1);
            DataTable t = ControladorGeneral.RecuperarTodasNotasDeCredito();


        }
    }
}
