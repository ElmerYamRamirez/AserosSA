﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UnidadModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string Simbolo { get; set; }
    }
}
