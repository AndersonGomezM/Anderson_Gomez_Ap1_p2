using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Anderson_Gomez_Ap1_p2.DAL;
using Anderson_Gomez_Ap1_p2.Entidades;

namespace Anderson_Gomez_Ap1_p2.BLL
{
    public class EmpacadosBLL
    {
        private Contexto _contexto;

        private ProductosBLL productosBLL;

        public EmpacadosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Empacados empacados)
        {
            if(!Existe(empacados.EmpacadosId))
                return Insertar(empacados);
            else
                return Modificar(empacados);
        }

        private bool Insertar(Empacados empacados)
        {
            bool confirmar = false;

            try
            {
                _contexto.Empacados.Add(empacados);

                foreach(var detalle in empacados.EmpacadosDetalles)
                {
                    _contexto.Entry(detalle).State = EntityState.Added;
                    /* _contexto.Entry(detalle.Cantidad).State = EntityState.Modified; */
                    _contexto.Productos.Find(detalle.DetallesId).Existencia -= detalle.Cantidad;
                }

                confirmar = _contexto.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }

            return confirmar;
        }

        private bool Modificar(Empacados empacados)
        {
            bool confirmar = false;

            try
            {
                var entradaAnterior = _contexto.Empacados
                    .Where(e => e.EmpacadosId == empacados.EmpacadosId)
                    .Include(x => x.EmpacadosDetalles)
                    .ThenInclude(x => x.Producto)
                    .AsNoTracking()
                    .SingleOrDefault();
                
                foreach (var detalle in empacados.EmpacadosDetalles)
                    /* _contexto.Productos.Find(detalle.DetallesId).Existencia += detalle.Cantidad; */

                _contexto.Database.ExecuteSqlRaw($"Delete FROM EmpacadosDetalle where EmpacadosId={empacados.EmpacadosId}");
                
                foreach (var detalle in empacados.EmpacadosDetalles)
                {
                    _contexto.Entry(detalle).State = EntityState.Added;
                    _contexto.Entry(productosBLL.Buscar(detalle.DetallesId)).State = EntityState.Modified;
                    /* _contexto.Productos.Find(detalle.DetallesId).Existencia -= detalle.Cantidad; */
                }

                _contexto.Entry(empacados).State = EntityState.Modified;

                confirmar = _contexto.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }

            return confirmar;
        }

        public bool Eliminar(int id)
        {
            bool confirmar = false;

            try
            {
                var empacados = _contexto.Empacados.Find(id);
                if(empacados != null)
                {
                    _contexto.Empacados.Remove(empacados);
                    confirmar = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return confirmar;
        }

        public Empacados Buscar(int id)
        {
            Empacados? empacados;

            try
            {
                empacados = _contexto.Empacados
                    .Include(x => x.EmpacadosDetalles)
                    .Where(e => e.EmpacadosId == id)
                    .AsNoTracking()
                    .SingleOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }

            return empacados;
        }

        private bool Existe(int id)
        {
            bool confirmar = false;

            try
            {
                confirmar = _contexto.Empacados.Any(e => e.EmpacadosId == id);
            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

        public List<Empacados> GetProductos()
        {
            List<Empacados>? lista = new List<Empacados>();

            try
            {
                lista = _contexto.Empacados
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<Empacados> GetList(Expression<Func<Empacados, bool>> criterio)
        {
            List<Empacados>? lista = new List<Empacados>();

            try
            {
                lista = _contexto.Empacados
                    .Where(criterio)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
    }
}