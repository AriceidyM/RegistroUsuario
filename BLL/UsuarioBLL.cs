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
   public  class UsuarioBLL
    {
        public static bool Guardar(usuario usuarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.usuario.Add(usuarios) != null)
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

        public static bool Modificar(usuario usuarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuarios).State = EntityState.Modified;
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
                usuario usuario = contexto.usuario.Find(id);

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

        public static usuario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            usuario usuarios = new usuario();
            try
            {
                usuarios = contexto.usuario.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }

        public static List<usuario> GetList(Expression<Func<usuario, bool>> expression)
        {
            List<usuario> Articulos = new List<usuario>();
            Contexto contexto = new Contexto();
            try
            {
                Articulos = contexto.usuario.Where(expression).ToList();
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

