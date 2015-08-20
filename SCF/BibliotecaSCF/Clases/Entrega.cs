using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class Entrega
    {
        public Entrega()
        {
            ItemsEntrega = new List<ItemEntrega>();
        }

        public virtual int Codigo { get; set; }
        public virtual DateTime FechaEmision { get; set; }
        public virtual int NumeroRemito { get; set; }
        public virtual int CodigoEstado { get; set; }
        public virtual string Observaciones { get; set; }

        public virtual List<ItemEntrega> ItemsEntrega { get; set; }
    }
}
