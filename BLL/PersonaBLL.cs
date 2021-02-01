using RegistroUsuarios.DAL;
using RegistroUsuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios.BLL
{
    public class PersonaBLL
    {
        public static bool Guardar(Persona personas)
        {
            if (!Existe(personas.UsuarioId))
                return Insertar(personas);
            else
                return Modificar(personas);
        }

        private static bool Insertar(Persona personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Persona.Add(personas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Persona personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(personas).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var personas = contexto.Persona.Find(id);

                if (personas != null)
                {
                    contexto.Persona.Remove(personas);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Persona Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Persona personas;

            try
            {
                personas = contexto.Persona.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return personas;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Persona.Any(e => e.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        private static List<Persona> GetList(Expression<Func<Persona, bool>> criterio)
        {
            List<Persona> lista = new List<Persona>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Persona.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
