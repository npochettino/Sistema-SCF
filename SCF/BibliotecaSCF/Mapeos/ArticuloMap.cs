﻿using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ArticuloMap : ClassMap<Articulo>
    {
        public ArticuloMap()
        {
            Table("Articulos");
            Id(x => x.Codigo).Column("codigoArticulo").GeneratedBy.Identity();
            Map(x => x.DescripcionCorta).Column("descripcionCorta");
            Map(x => x.DescripcionLarga).Column("descripcionLarga");
            Map(x => x.Marca).Column("marca");
            Map(x => x.NombreImagen).Column("nombreImagen");

            HasMany<ArticuloProveedor>(x => x.ArticulosProveedor).KeyColumn("codigoArticulo").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
