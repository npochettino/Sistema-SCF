using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoEntrega : CatalogoGenerico<Entrega>
    {
        public static Entrega RecuperarUltima(NHibernate.ISession nhSesion)
        {
            try
            {
                Entrega entrega = nhSesion.QueryOver<Entrega>().OrderBy(x => x.Codigo).Desc.Take(1).SingleOrDefault();
                return entrega;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
