using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class ItemNotaDeCredito
    {
        public virtual int Codigo { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual ItemEntrega ItemEntrega { get; set; }
    }
}
