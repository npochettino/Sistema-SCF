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
            
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            CatalogoEntrega.TieneRemito(885, nhSesion);


        }
    }
}
