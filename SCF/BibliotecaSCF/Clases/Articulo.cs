using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class Articulo
    {
        public Articulo()
        {
            ArticulosProveedor = new List<ArticuloProveedor>();
        }

        public virtual int Codigo { get; set; }
        public virtual string DescripcionCorta { get; set; }
        public virtual string DescripcionLarga { get; set; }
        public virtual string Marca { get; set; }
        public virtual string NombreImagen { get; set; }

        public virtual IList<ArticuloProveedor> ArticulosProveedor { get; set; }
    }
}
