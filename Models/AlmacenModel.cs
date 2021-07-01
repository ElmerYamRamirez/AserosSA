using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AlmacenModel : IValidatableObject
    {
        [RegularExpression(@"^ALM-[A-Z]{4}-[0-9]{2}",
         ErrorMessage = "Caracteres no permitidos.ALM-XXXX-00")]
        [Required(ErrorMessage = "La clave es requerida")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(10, ErrorMessage = "Nombre es muy largo.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El status es requerido")]
        public string Status { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id == Nombre) {
                yield return new ValidationResult(
                    $"El id {Id} ya existe.",
                    new[] { nameof(Id) });
            }
        }
    }
}
