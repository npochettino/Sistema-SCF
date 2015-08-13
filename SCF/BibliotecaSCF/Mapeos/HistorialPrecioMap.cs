using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class HistorialPrecioMap : ClassMap<HistorialPrecio>
    {
        public HistorialPrecioMap()
        {
            Table("HistorialPreciosArticuloCliente");
            Id(x => x.Codigo).Column("codigoHistorialPrecioArticuloCliente").GeneratedBy.Identity();
            Map(x => x.FechaDesde).Column("fechaDesde");
            Map(x => x.FechaHasta).Column("fechaHasta");
            Map(x => x.Precio).Column("precio");
            Map(x => x.CodigoMoneda).Column("codigoMoneda");
        }
    }
}
