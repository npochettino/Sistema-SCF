using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoArticulo : CatalogoGenerico<Articulo>
    {
        public static List<Articulo> RecuperarPorCodigoInternoCliente(string codigoInternoCliente, NHibernate.ISession nhSesion)
        {
            try
            {
                List<Articulo> listaArticulos = nhSesion.QueryOver<Articulo>().Where(x => x.ArticulosClientes.Any(ac => ac.CodigoInterno.Contains(codigoInternoCliente))).List().ToList();
                return listaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
