using BibliotecaSCF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoNotaDePedido : CatalogoGenerico<NotaDePedido>
    {
        public static List<NotaDePedido> RecuperarPorArticulo(int codigoArticulo, NHibernate.ISession nhSesion)
        {
            try
            {
                List<NotaDePedido> listaNP = nhSesion.Query<NotaDePedido>().Where(x => x.ItemsNotaDePedido.Any(i => i.Articulo.Codigo == codigoArticulo)).ToList();
                return listaNP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
