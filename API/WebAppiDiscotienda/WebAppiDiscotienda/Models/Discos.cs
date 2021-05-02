using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectodisctienda.Models
{
    public class Discos
    {
        public int Id { get; set; }
        public string Genero { get; set; }
        public string Descripcioncd { get; set; }
        public int Cantidad { get; set; }

        public bool Estado { get; set; }
    }
}
