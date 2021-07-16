using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UbicacionModel : IValidatableObject
    {
        [RegularExpression(@"^UBI-[A-Z]{2}-[0-9]{2}",
         ErrorMessage = "Caracteres no permitidos.UBI-XX-00")]
        [Required(ErrorMessage = "La clave es requerida")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(10, ErrorMessage = "Nombre es muy largo.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El status es requerido")]
        public string Status { get; set; }

        [Required(ErrorMessage = "La dimensión es requerida")]
        public string Dimension { get; set; }

        [Required(ErrorMessage = "El pasillo es requerido")]
        public int Pasillo { get; set; }

        [Required(ErrorMessage = "El estante es requerido")]
        public int Estante { get; set; }

        [Required(ErrorMessage = "El nivel es requerido")]
        public int Nivel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Pasillo < 0)
            {
                yield return new ValidationResult(
                    $"El valor de pasillo no puede ser negativo",
                    new[] { nameof(Pasillo) });
            }
            if (Estante < 0)
            {
                yield return new ValidationResult(
                    $"El valor de estante no puede ser negativo",
                    new[] { nameof(Estante) });
            }
            if (Nivel < 0)
            {
                yield return new ValidationResult(
                    $"El valor de nivel puede ser negativo",
                    new[] { nameof(Nivel) });
            }
        }
    }
}
