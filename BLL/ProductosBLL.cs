using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Anderson_Gomez_Ap1_p2.DAL;
using Anderson_Gomez_Ap1_p2.Entidades;

namespace Anderson_Gomez_Ap1_p2.BLL
{
    public class ProductosBLL
    {
        private Contexto _contexto;

        public ProductosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Productos producto)
        {
            if(!Existe(producto.ProductoId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        private bool Modificar(Productos productos)
        {
            bool confirmar = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalle where ProductoId={productos.ProductoId}");

                foreach (var detalle in productos.ProductosDetalle)
                {
                    _contexto.Entry(detalle).State = EntityState.Added;
                }

                _contexto.Entry(productos).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

        private bool Insertar(Productos productos)
        {
            bool confirmar = false;


            try
            {
                _contexto.Productos.Add(productos);
                confirmar = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

        public bool Eliminar(int id)
        {
            bool confirmar = false;

            try
            {
                var productos = _contexto.Productos.Find(id);
                if(productos != null)
                {
                    _contexto.Productos.Remove(productos);
                    confirmar = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

        public Productos Buscar(int id)
        {
            Productos productos;

            try
            {
                productos = _contexto.Productos.Include(x => x.ProductosDetalle).Where(e => e.ProductoId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return productos;
        }

        private bool Existe(int id)
        {
            bool confirmar = false;

            try
            {
                confirmar = _contexto.Productos.Any(e => e.ProductoId == id);
            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

        public List<Productos> GetProductos()
        {
            List<Productos>? lista = new List<Productos>();

            try
            {
                lista = _contexto.Productos.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos>? lista = new List<Productos>();

            try
            {
                lista = _contexto.Productos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
    }
}