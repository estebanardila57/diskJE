using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectodisctienda.Models
{
    public class Sancion
    {
        public string Id { get; set; }
        public string Descripcionretraso { get; set; }
        public DateTime fecharetrasouser { get; set; }
        public int Iduser { get; set; }
        public Usersystem user { get; set; }
        public int idprest { get; set; }
        public Prestamo idprestamos { get; set; }


    }
}
