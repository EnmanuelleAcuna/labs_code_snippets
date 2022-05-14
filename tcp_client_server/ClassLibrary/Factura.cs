using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Factura
    {
        public Factura() { }

        public Factura(Guid id, string concepto, DateTime fecha, float monto, string proveedor)
        {
            Id = id;
            Concepto = concepto;
            Fecha = fecha;
            Monto = monto;
            Proveedor = proveedor;
        }

        public Guid Id { get; set; }
        public string Concepto { get; set; }
        public DateTime Fecha { get; set; }
        public float Monto { get; set; }
        public string Proveedor { get; set; }
    }
}
