﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class ItemEntrega
    {
        public virtual int Codigo { get; set; }
        public virtual int Cantidad { get; set; }

        public virtual ArticuloProveedor ArticuloProveedor { get; set; }
        public virtual ItemNotaDePedido ItemNotaDePedido { get; set; }
    }
}
