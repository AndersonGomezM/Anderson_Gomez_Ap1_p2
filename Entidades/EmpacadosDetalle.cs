using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Anderson_Gomez_Ap1_p2.Entidades
{
    public class EmpacadosDetalle
    {
        [Key]

        public int DetallesId { get; set; }

        public string? Producto { get; set; }

        public int Cantidad { get; set; }

        public double Peso { get; set; }
    }
}