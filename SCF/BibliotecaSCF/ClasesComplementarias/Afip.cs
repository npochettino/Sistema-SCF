using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSFEv1;
using WSFEv1.Logica.Wsfe;

namespace BibliotecaSCF.ClasesComplementarias
{
    public class Afip
    {
        public int ConsultarUltimoNro(int ptoVenta, int tipoComptobanteAfip)
        {
            var clsFac = new clsFacturacion();
            var ultNroComprobante = clsFac.ConsultarUltNroOrden(ptoVenta, tipoComptobanteAfip);
 
            return ultNroComprobante;
        }

        private static string GetFechaAFIP(System.DateTime fecha)
        {
            return string.Format("{0}{1}{2}", fecha.Year.ToString("0000"), fecha.Month.ToString("00"), fecha.Day.ToString("00"));
        }
    }
}
