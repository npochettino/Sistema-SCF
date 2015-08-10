using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.ClasesComplementarias
{
    public class Constantes
    {
        public class EstadosNotaDePedido
        {
            public const int VIGENTE = 1;
            public const int ENTREGADA = 2;
            public const int ANULADA = 3;
            public const int PROXIMA_VENCER = 4; //estado calculado
            public const int VENCIDA = 5; //estado calculado
        }
    }
}
