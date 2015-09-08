using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class Factura
    {
        public virtual int Codigo { get; set; }
        public virtual int NumeroFactura { get; set; }
        public virtual DateTime FechaFacturacion { get; set; }
        public virtual double Subtotal { get; set; }
        public virtual double Total { get; set; }

        public virtual TipoComprobante TipoComprobante { get; set; }
        public virtual Entrega Entrega { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual Concepto Concepto { get; set; }
        public virtual Iva Iva { get; set; }
    }
}
