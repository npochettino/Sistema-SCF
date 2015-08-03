using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class Cliente
    {
        public virtual int Codigo { get; set; }
        public virtual string RazonSocial { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Localidad { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Cuil { get; set; }
        public virtual bool IsInactivo { get; set; }
    }
}
