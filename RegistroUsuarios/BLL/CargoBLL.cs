using RegistroUsuarios.DAL;
using RegistroUsuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios.BLL
{
    public class CargoBLL
    {
        public static bool Guardar(Cargos cargos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.cargo.Add(cargos) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Modificar(Cargos cargos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(cargos).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Cargos usuario = contexto.cargo.Find(id);

                if (usuario != null)
                {
                    contexto.Entry(usuario).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    contexto.Dispose();
                    paso = true;
                }


            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Cargos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cargos cargos = new Cargos();
            try
            {
                cargos = contexto.cargo.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return cargos;
        }

        public static List<Cargos> GetList(Expression<Func<Cargos, bool>> expression)
        {
            List<Cargos> Articulos = new List<Cargos>();
            Contexto contexto = new Contexto();
            try
            {
                Articulos = contexto.cargo.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Articulos;
        }
    }
}
