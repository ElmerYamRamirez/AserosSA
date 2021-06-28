using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UbicacionModel
    {
        [Required]
        public int Id { get; set; }

        public string Zona { get; set; }

        public string Estante { get; set; }
    }
}
