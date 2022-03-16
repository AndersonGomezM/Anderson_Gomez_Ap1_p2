using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Anderson_Gomez_Ap1_p2.Entidades
{
    public class ProductosDetalle
    {
        [Key]

        public int DetallesId { get; set; }

        public string? DescripcionDetalle { get; set; }

        public string? Presentacion { get; set; }

        public double Cantidad { get; set; }

        public double Precio { get; set; }

        public int Empaque { get; set; }
    }
}