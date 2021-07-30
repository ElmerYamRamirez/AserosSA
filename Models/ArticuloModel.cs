using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ArticuloModel : IValidatableObject
    {
        [RegularExpression(@"^ART-[0-9]{2}",
         ErrorMessage = "Caracteres no permitidos.ART-00")]
        [Required(ErrorMessage = "La clave es requerida")]
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Marca { get; set; }

        //[MinLength(0, ErrorMessage = "Debe ser mayor a 0")]
        public int Cantidad { get; set; }

        //[MinLength(0, ErrorMessage = "Debe ser mayor a 0")]
        [Display(Name ="Precio unitario")]
        public double PrecioUnitario { get; set; }

        //[MinLength(0, ErrorMessage = "Debe ser mayor a 0")]
        //public double PrecioPromedio { get; set; }

        //[MinLength(0, ErrorMessage = "Debe ser mayor a 0")]
        public int Minimo { get; set; }

        //[MinLength(0, ErrorMessage = "Debe ser mayor a 0")]
        public int Maximo { get; set; }

        //[MinLength(0, ErrorMessage = "Debe ser mayor a 0")]
        [Display(Name ="Punto de reorden")]
        public int PuntoReorden { get; set; }

        public string UnidadId { get; set; }
        public UnidadModel Unidad { get; set; }

        [Display(Name ="Ubicación")]
        public string UbicacionId { get; set; }
        public UbicacionModel Ubicacion { get; set; }

        public string AlmacenId { get; set; }
        public AlmacenModel Almacen { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Minimo > Maximo)
            {
                yield return new ValidationResult(
                    $"El minimo debe de ser menor al maximo",
                    new[] { nameof(Minimo) });
            }
            if (Maximo < Minimo)
            {
                yield return new ValidationResult(
                    $"El maximo debe de ser mayor al minimo",
                    new[] { nameof(Maximo) });
            }
            if (Minimo == Maximo)
            {
                yield return new ValidationResult(
                    $"El minimo y el maximo deben de ser diferentes",
                    new[] { nameof(Maximo), nameof(Minimo) });
            }
            if (PuntoReorden > Maximo || PuntoReorden < Minimo)
            {
                yield return new ValidationResult(
                    $"El punto de reorden debe estar entre el minimo y el maximo",
                    new[] { nameof(PuntoReorden) });
            }
        }
    }
}
