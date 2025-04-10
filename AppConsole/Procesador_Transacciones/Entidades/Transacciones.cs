using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesador_Transacciones.Entidades
{
    public class Transacciones
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("tipo")]
        public string Tipo { get; set; } = string.Empty;
        [Name("monto")]
        public decimal Monto { get; set; }

        public Transacciones()
        {

        }

        public Transacciones(int id, string tipo, decimal monto)
        {
            Id = id;
            Tipo = tipo;
            Monto = monto;
        }

    }
}
