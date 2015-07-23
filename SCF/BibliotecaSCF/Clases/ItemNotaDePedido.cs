﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class ItemNotaDePedido
    {
        public virtual int Codigo { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual DateTime FechaEntrega { get; set; }

        public virtual Articulo Articulo { get; set; }
    }
}
