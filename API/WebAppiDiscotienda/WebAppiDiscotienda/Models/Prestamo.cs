using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectodisctienda.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime Fechainiciopres { get; set; }
        public DateTime Fechafinalpres { get; set; }
        public int Idclientepres { get; set; }
        public Clientes Idclipres { get; set; }
        public int Codiodisco { get; set; }
        public Discos CodDisk { get; set; }
        public int Idusers { get; set; }
        public Usersystem iduserystem { get; set; }


    }
}
