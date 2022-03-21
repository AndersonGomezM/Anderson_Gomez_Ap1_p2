using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Anderson_Gomez_Ap1_p2.Entidades;

namespace Anderson_Gomez_Ap1_p2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos { get; set; }

        public DbSet<Frutos> Frutos { get; set;}

        public Contexto(DbContextOptions<Contexto> options) : base(options){}
    }
}