using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Microservicio.Model
{
    public class Cuenta
    {
        public int CuentaId { get; set; }

        public int NumeroCuenta { get; set; }

        public string TipoCuenta { get; set; }

        public double SaldoInicial { get; set; }

        public bool Estado { get; set; }

    }
}
