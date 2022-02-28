using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Microservicio.Model
{
    public class Movimiento
    {
        public int MovimientoId { get; set; }

        public DateTime FechaMovimiento { get; set; }

        public string TipoMovimiento { get; set; }

        public double Valor { get; set; }

        public double Saldo { get; set; }

        public Cuenta Cuenta { get; set; }
    }
}
