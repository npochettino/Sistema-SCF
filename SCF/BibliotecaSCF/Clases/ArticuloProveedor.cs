using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class ArticuloProveedor
    {
        public ArticuloProveedor()
        {
            HistorialPrecio = new List<HistorialPrecio>();
        }

        public virtual int Codigo { get; set; }
        public virtual string CodigoInterno { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual IList<HistorialPrecio> HistorialPrecio { get; set; }
    }
}
