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
        public DbSet<usuario> usuario { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
    
}
