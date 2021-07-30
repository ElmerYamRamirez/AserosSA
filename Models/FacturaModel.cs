using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FacturaModel : IValidatableObject
    {
        [Required(ErrorMessage = "El folio es requerido")]
        public string Id { get; set; }

        [Required(ErrorMessage = "La fecha es requerido")]
        public DateTime? FechaFactura { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El proveedor es requerido")]
        public string NombreProveedor { get; set; }

        public string Comentarios { get; set; }

        [Required(ErrorMessage = "La forma de pago es requerida")]
        public string FormaPago { get; set; }
        public double Subtotal { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
        public List<DetalleFacturaModel> DetalleFactura { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Iva < 0)
            {
                yield return new ValidationResult(
                    $"El minimo debe de ser menor al maximo",
                    new[] { nameof(Iva) });
            }
        }
    }
}
