using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectodisctienda.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombrecli { get; set; }
        public int Cedulacli { get; set; }
        public int Telefonocli { get; set; }
        public string Direccioncli { get; set; }

        public bool Estado { get; set; }

    }
}
