using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ArticuloProveedorMap : ClassMap<ArticuloProveedor>
    {
        public ArticuloProveedorMap()
        {
            Table("ArticulosProveedor");
            Id(x => x.Codigo).Column("codigoArticuloProveedor").GeneratedBy.Identity();
            Map(x => x.CodigoInterno).Column("codigoInterno");

            References(x => x.Proveedor).Column("codigoProveedor").Cascade.None().Nullable().LazyLoad(Laziness.Proxy);
            HasMany<ItemNotaDePedido>(x => x.HistorialPrecio).KeyColumn("codigoArticuloProveedor").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
