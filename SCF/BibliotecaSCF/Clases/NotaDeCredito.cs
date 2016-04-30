﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class NotaDeCredito
    {
        public NotaDeCredito()
        {
            ItemsNotaDeCredito = new List<ItemNotaDeCredito>();
        }

        public virtual int Codigo { get; set; }
        public virtual double Total { get; set; }
        public virtual bool IsFacturaCompleta { get; set; }
        public virtual DateTime FechaHoraNotaDeCredito { get; set; }
        public virtual string CAE { get; set; }
        public virtual DateTime? FechaHoraVencimientoCAE { get; set; }
        public virtual double Subtotal { get; set; }

        public virtual TipoComprobante TipoComprobante { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual IList<ItemNotaDeCredito> ItemsNotaDeCredito { get; set; }

        private static DataTable Tabla
        {
            get
            {
                DataTable tablaNotaDeCredito = new DataTable();
                tablaNotaDeCredito.Columns.Add("codigoNotaDeCredito");
                tablaNotaDeCredito.Columns.Add("subtotal");
                tablaNotaDeCredito.Columns.Add("total");
                tablaNotaDeCredito.Columns.Add("isFacturaCompleta");
                tablaNotaDeCredito.Columns.Add("codigoFactura");
                tablaNotaDeCredito.Columns.Add("numeroFactura");
                tablaNotaDeCredito.Columns.Add("totalFactura");
                tablaNotaDeCredito.Columns.Add("cae");
                tablaNotaDeCredito.Columns.Add("fechaHoraVencimientoCAE");
                tablaNotaDeCredito.Columns.Add("codigoTipoComprobante");
                tablaNotaDeCredito.Columns.Add("descripcionTipoComprobante");

                return tablaNotaDeCredito;
            }
        }

        /// <summary>
        /// Recupera una tabla con la lista completa de las notas de credito
        /// </summary>
        /// <param name="listaNotasDeCredito"></param>
        /// <returns></returns>
        public static DataTable RecuperarTabla(List<NotaDeCredito> listaNotasDeCredito)
        {
            DataTable tablaNotasDeCredito = Tabla;

            listaNotasDeCredito.Aggregate(tablaNotasDeCredito, (dt, r) =>
            {
                dt.Rows.Add(r.Codigo, r.Subtotal, r.Total, r.IsFacturaCompleta, r.Factura.Codigo, r.Factura.NumeroFactura, r.Factura.Total, r.CAE, r.FechaHoraVencimientoCAE, r.TipoComprobante.Codigo, r.TipoComprobante.Descripcion); 
                return dt;
            });

            return tablaNotasDeCredito;
        }

        /// <summary>
        /// Recupera una tabla para una nota de credito sola
        /// </summary>
        /// <param name="notaDeCredito"></param>
        /// <returns></returns>
        public static DataTable RecuperarTabla(NotaDeCredito notaDeCredito)
        {
            DataTable tablaNotaDeCredito = Tabla;

            tablaNotaDeCredito.Rows.Add(notaDeCredito.Codigo, notaDeCredito.Subtotal, notaDeCredito.Total, notaDeCredito.IsFacturaCompleta, notaDeCredito.Factura.Codigo, notaDeCredito.Factura.NumeroFactura, notaDeCredito.Factura.Total, notaDeCredito.CAE, notaDeCredito.FechaHoraVencimientoCAE, notaDeCredito.TipoComprobante.Codigo, notaDeCredito.TipoComprobante.Descripcion); 

            return tablaNotaDeCredito;
        }
    }
}
