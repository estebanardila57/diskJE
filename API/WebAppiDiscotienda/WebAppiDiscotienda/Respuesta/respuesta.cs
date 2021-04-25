using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppiDiscotienda.Respuesta
{
    public class respuesta
    {
        public int CodEx { get; set; }
        public string mensaje { get; set; }
        public object Data { get; set; }
        public respuesta()
        {
            this.CodEx = 0;
        }
    }
}
