using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DetalleFacturaModel
    {
        public int Id { get; set; }
        public string FacturaId { get; set; }
        public ArticuloModel Articulo { get; set; }
        public int CantidadArticulos { get; set; }
        public double Subtotal => CantidadArticulos * Articulo.PrecioUnitario;
        public double Iva => Subtotal * 0.16;
        public double Total => Subtotal + Iva;
    }
}
