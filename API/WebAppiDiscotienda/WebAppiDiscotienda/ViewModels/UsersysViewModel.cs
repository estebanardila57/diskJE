using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectodisctienda.Models;

namespace proyectodisctienda.Views
{
    public class UsersysViewModel
    {
        public int Id { get; set; }
        public string descripcioncargo { get; set; }
        public string Nomuser { get; set; }
        public string Pass { get; set; }
        public int Idcliente { get; set; }
        public Clientes cliente { get; set; }
    }
}
