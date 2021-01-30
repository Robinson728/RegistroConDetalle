using Microsoft.EntityFrameworkCore;
using RegistroUsuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = GestionPersona.Db");
        }
    }
}
