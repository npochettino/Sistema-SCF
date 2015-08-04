using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class HistorialPrecioMap : ClassMap<HistorialPrecio>
    {
        public HistorialPrecioMap()
        {
            Table("HistorialPreciosArticuloProveedor");
            Id(x => x.Codigo).Column("codigoHistorialPrecioArticuloProveedor").GeneratedBy.Identity();
            Map(x => x.FechaDesde).Column("fechaDesde");
            Map(x => x.FechaHasta).Column("fechaHasta");
            Map(x => x.Precio).Column("precio");
            Map(x => x.IsDolar).Column("isDolar");
        }
    }
}
