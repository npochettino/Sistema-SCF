using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ItemContratoMarcoMap : ClassMap<ItemContratoMarco>
    {
        public ItemContratoMarcoMap()
        {
            Table("ItemsContratoMarco");
            Id(x => x.Codigo).Column("codigoItemContratoMarco").GeneratedBy.Identity();
            Map(x => x.Precio).Column("precio");

            References(x => x.Articulo).Column("codigoArticulo").Cascade.None().Nullable().LazyLoad(Laziness.Proxy);
        }
    }
}
