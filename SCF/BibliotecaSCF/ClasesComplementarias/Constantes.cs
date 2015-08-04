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
        }

        public class ColorEstadosNotaDePedido
        {
            public const string VIGENTE = "#00FF00";
            public const string ENTREGADA = "00FFFF";
            public const string ANULADA = "#A4A4A4";
            public const string PROXIMA_VENCER = "#FFFF00"; //estado calculado
            public const string VENCIDA = "#FF0000"; //estado calculado
        }
    }
}
