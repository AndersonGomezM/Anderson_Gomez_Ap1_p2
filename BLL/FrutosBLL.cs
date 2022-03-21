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
    public class FrutosBLL
    {
        private Contexto _contexto;

        public FrutosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Frutos frutos)
        {
            if(!Existe(frutos.FrutosId))
                return Insertar(frutos);
            else
                return Modificar(frutos);
        }

        private bool Modificar(Frutos frutos)
        {
            bool confirmar = false;

            try
            {
                /* var entradaAnterior = _contexto.Frutos
                    .Where(e => e.FrutosId == frutos.FrutosId)
                    .Include(x => x.FrutosDetalles)
                    .ThenInclude(x => x.Producto)
                    .AsNoTracking()
                    .SingleOrDefault();

                
                /* _contexto.Database.ExecuteSqlRaw($"Delete FROM FrutosDetalle where FrutosId={frutos.FrutosId}"); */
                
                foreach (var detalle in frutos.FrutosDetalles)
                {
                    _contexto.Entry(detalle).State = EntityState.Added;
                }
                _contexto.Entry(frutos).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                throw e;
            }

            return confirmar;
        }

        private bool Insertar(Frutos frutos)
        {
            bool confirmar = false;

            try
            {
                _contexto.Frutos.Add(frutos);

                /* foreach(var detalle in frutos.FrutosDetalles)
                {
                    _contexto.Entry(detalle).State = EntityState.Added;
                    _contexto.Entry(detalle.Cantidad).State = EntityState.Modified;
                } */


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
                var frutos = _contexto.Frutos.Find(id);
                if(frutos != null)
                {
                    _contexto.Frutos.Remove(frutos);
                    confirmar = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return confirmar;
        }

        public Frutos Buscar(int id)
        {
            Frutos? frutos;

            try
            {
                frutos = _contexto.Frutos
                    .Include(x => x.FrutosDetalles)
                    .Where(e => e.FrutosId == id)
                    .AsNoTracking()
                    .SingleOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }

            return frutos;
        }

        private bool Existe(int id)
        {
            bool confirmar = false;

            try
            {
                confirmar = _contexto.Frutos.Any(e => e.FrutosId == id);
            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

        public List<Frutos> GetProductos()
        {
            List<Frutos>? lista = new List<Frutos>();

            try
            {
                lista = _contexto.Frutos
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<Frutos> GetList(Expression<Func<Frutos, bool>> criterio)
        {
            List<Frutos>? lista = new List<Frutos>();

            try
            {
                lista = _contexto.Frutos
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