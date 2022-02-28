using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Microservicio.Model
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Contraseña { get; set; }

        public bool Estado { get; set; }

        public Persona Persona { get; set; }

        public List<Cuenta> Cuentas { get; set; }
    }
}
