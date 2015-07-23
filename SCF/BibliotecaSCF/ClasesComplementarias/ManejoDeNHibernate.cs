﻿using FluentNHibernate.Cfg;
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
                  .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString("data source=SUPLENTE4-PC\\EZEQUIELSQL;initial catalog=SCF;Integrated Security=SSPI;"))//Eze trabajo
                  //.ConnectionString("data source=localhost;initial catalog=SCF;Integrated Security=SSPI;"))//Eze notebook
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
