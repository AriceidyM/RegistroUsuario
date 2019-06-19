using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios.Entidades
{
    public class Cargos
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Cargos()
        {
            Id = 0;
            Descripcion = string.Empty;
        }
    }
}
