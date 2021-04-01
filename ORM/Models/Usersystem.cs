using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectodisctienda.Models
{
    public class Usersystem
    {
        public int Id { get; set; }
        public string descripcioncargo { get; set; }
        public string Nomuser { get; set; }
        public string Pass { get; set; }
        public int Idcliente { get; set; }
        public Clientes cliente { get; set; }
    }
}
