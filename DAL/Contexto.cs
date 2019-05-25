using RegistroUsuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegistroUsuarios.DAL
{
    public class Contexto : DbContext {
        public DbSet<Usuarios> usuario { get; set; }

        public DbSet<Cargos> cargo { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
    
}
