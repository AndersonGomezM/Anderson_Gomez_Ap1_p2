using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anderson_Gomez_Ap1_p2.Entidades
{
    public class Productos
    {
        [Key]
        
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripción")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la existencia")]
        [Range(1, int.MaxValue, ErrorMessage = "La Id esta fuera del rango permitido")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el costo")]
        [Range(1.00, double.MaxValue, ErrorMessage = "El costo se sale del rango permitido")]
        public double Costo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar el precio.")]
        [Range(1, double.MaxValue, ErrorMessage = "Se debe indicar el precio del producto dentro de los rangos {1}/{2}.")]
        public double Precio { get; set; }
        
        public int Ganancia { get; set; }

        public double ValorInventario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar el peso.")]
        [Range(1, double.MaxValue, ErrorMessage = "Se debe indicar el peso del producto dentro de los rangos {1}/{2}.")]
        public double Gramos { get; set; }

        public DateTime FechaCaducidad { get; set; } = DateTime.Now;

        [ForeignKey("ProductoId")]
        public virtual List<ProductosDetalle> ProductosDetalle { get; set; } = new List<ProductosDetalle>();
    }
}