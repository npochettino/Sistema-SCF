using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.ClasesComplementarias
{
    public class ManejoDeNHibernate
    {
        private static ISessionFactory singleton;

        private static ISessionFactory CrearSesion()
        {
            if (singleton == null)
            {

                singleton = Fluently.Configure()

               // .Database(MsSqlConfiguration.MsSql2012.ConnectionString("data source=SUPLENTE4-PC\\EZEQUIELSQL;initial catalog=SCF;Integrated Security=SSPI;"))//Eze trabajo
               //.Database(MsSqlConfiguration.MsSql2012.ConnectionString("data source=TSIS0220\\SQLEXPRESS;initial catalog=SCF;Integrated Security=SSPI;"))
              .Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=SCF;Integrated Security=SSPI;"))//Eze PC
               //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=SCF;user=sa;password=ana"))//Nico PC 
               //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=w1402088_SCF;user=w1402088_SCF;password=Algoritmos2015"))//Hosting
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ModuloPrueba>())
                .BuildSessionFactory();
            }

            return singleton;
        }

        public static ISession IniciarSesion()
        {
            return CrearSesion().OpenSession();
        }
    }
}
