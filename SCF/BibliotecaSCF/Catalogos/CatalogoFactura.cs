using BibliotecaSCF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoFactura : CatalogoGenerico<Factura>
    {
        public static Factura RecuperarUltima(NHibernate.ISession nhSesion)
        {
            try
            {
                Factura factura = nhSesion.QueryOver<Factura>().OrderBy(x => x.Codigo).Desc.Take(1).SingleOrDefault();
                return factura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
