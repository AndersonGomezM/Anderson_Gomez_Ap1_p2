using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anderson_Gomez_Ap1_p2.Entidades
{
    public class Empacados
    {
        [Key]

        public int EmpacadosId { get; set; }

        public string? Concepto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string? ProductoEmpacado { get; set;}

        public int Cantidad { get; set; }

        public double Peso { get; set; }

        [ForeignKey("EmpacadosId")]
        public virtual List<EmpacadosDetalle> EmpacadosDetalles { get; set; } = new List<EmpacadosDetalle>();
    }
}