﻿using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("Clientes");
            Id(x => x.Codigo).Column("codigoProveedor").GeneratedBy.Identity();
            Map(x => x.RazonSocial).Column("razonSocial");
            Map(x => x.Provincia).Column("provincia");
            Map(x => x.Localidad).Column("localidad");
            Map(x => x.Direccion).Column("direccion");
            Map(x => x.Telefono).Column("telefono");
            Map(x => x.Mail).Column("mail");
            Map(x => x.Cuil).Column("cuil");
        }
    }
}
