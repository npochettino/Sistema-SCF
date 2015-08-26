﻿using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ProveedorMap : ClassMap<Proveedor>
    {
        public ProveedorMap()
        {
            Table("Proveedores");
            Id(x => x.Codigo).Column("codigoProveedor").GeneratedBy.Identity();
            Map(x => x.NumeroInterno).Column("numeroInterno");
            Map(x => x.RazonSocial).Column("razonSocial");
            Map(x => x.Provincia).Column("provincia");
            Map(x => x.Localidad).Column("localidad");
            Map(x => x.Direccion).Column("direccion");
            Map(x => x.Telefono).Column("telefono");
            Map(x => x.Fax).Column("fax");
            Map(x => x.Mail).Column("mail");
            Map(x => x.Cuil).Column("cuil");
            Map(x => x.PersonaContacto).Column("personaContacto");
            Map(x => x.NumeroCuenta).Column("numeroCuenta");
            Map(x => x.Banco).Column("banco");
            Map(x => x.Cbu).Column("cbu");
            Map(x => x.Observaciones).Column("observaciones");
            Map(x => x.IsInactivo).Column("isInactivo");
        }
    }
}
