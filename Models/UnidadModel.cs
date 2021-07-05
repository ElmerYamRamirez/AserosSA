using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UnidadModel : IValidatableObject
    {
        [RegularExpression(@"^UNI-[A-Z]{4}-[0-9]{2}",
         ErrorMessage = "Caracteres no permitidos.UNI-XXXX-00")]
        [Required(ErrorMessage = "La clave es requerida")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El simbolo es requerido")]
        [StringLength(3, ErrorMessage = "Simbolo es muy largo.")]
        public string Simbolo { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El status es requerido")]
        public string Estatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id == Simbolo)
            {
                yield return new ValidationResult(
                    $"El id {Id} ya existe.",
                    new[] { nameof(Id) });
            }
        }
    }
}
