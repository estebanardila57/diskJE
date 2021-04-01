using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyectodisctienda.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectodisctienda.Views;
using proyectodisctienda.Models;


namespace proyectodisctienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoController : ControllerBase
    {

        private readonly Basecontext _mybasecontext;// creamos un obejto de solo lectura de tipo basecontex que es el engardo que hacer las operaciones en la base de datos
        public DiscoController(Basecontext contexto) 
        {
            _mybasecontext = contexto;//le asignamos _mybasecontext el nuevo contexto que le pasa el parametro 
        
        }
        //para el leer
        [HttpGet]

        public IActionResult get()
        {
            respuesta res = new respuesta();
            try
            {
                var lista = _mybasecontext.Discos.ToList();// me devuelve todo lo que hay en la tabla
                res.CodEx = 1;// asignamos un uno a la propiedad CoEx
                res.Data = lista;// y al objeto le decimos qeu ahora su contenido e slo que me retorno de la consulta
            }
            catch (Exception e)// si hay un error capturemelo en la variable e
            {

                res.mensaje = "El error que surgió fue: " + e.Message;// almaceneme en la propiedad mensaje la excepcion
            }
            return Ok(res);// retorneme el metodo Ok que tiene como parametro la respuesta o los datos que se obtuvieron
        }

        //para insertar

        [HttpPost]

        public IActionResult Add(DiskViewModel oDisk) // este metodo me recibe como paraemtro un objeto de tipo DataView model
        {
            respuesta res = new respuesta();// instanciamos un objeto de tipo respuesta
            try// intente
            {
                Discos disk = new Discos();// instanciamos un objeto de tipo Discos 
                disk.Genero = oDisk.Genero; //al objeto discos de la base de datos especificamente en el campo genero se le va a asignar lo que me trae de la vista
                disk.Descripcioncd = oDisk.Descripcioncd;//...............en el campo descripcion se le va a asignar lo que me trae la vista 
                disk.Cantidad = oDisk.Cantidad;// ........................ en el campo cantidad se le va a asignar lo que me trae la vista
                _mybasecontext.Discos.Add(disk);// me vas a agregar en la base de datos lo que se almaceno en el objeto de tipo discos
                _mybasecontext.SaveChanges();// guardas los cambios y actualizas
                res.CodEx = 1;// al CodEx le vas a asignar el numero 1
                res.mensaje = "Cd Agregado satisfactoriamente";// Asignele a la propiedad mensaje lo sigueinte
            }
            catch (Exception e)//pero si hay una excepcion capturemela en la variable e
            {

                res.mensaje = "El error que surgió fue: " + e.Message;// almaceneme en la propiedad mensaje la excepcion
            }
            return Ok(res.mensaje+" "+res.CodEx);
        }

        [HttpPut]
        public IActionResult update(DiskViewModel oDisk)// este metodo me recibe como parametro un objeto de tipo DataView model
        {
            respuesta res = new respuesta();// instanciamos un objeto de tipo respuesta
            try
            {
                var disk = _mybasecontext.Discos.Find(oDisk.Id);// vas a ir a ala base de datos y vas a buscarme el id para poder saber cual es la fila que deseamos actualizarv
                disk.Genero = oDisk.Genero;//al objeto discos de la base de datos especificamente en el campo genero se le va a asignar lo que me trae de la vista
                disk.Descripcioncd = oDisk.Descripcioncd;//...........
                disk.Cantidad = oDisk.Cantidad;//....................
                _mybasecontext.Discos.Update(disk);// va a actualizar por favor en mi  base de datos el campo que te pase con toda esta nueva informacion
                _mybasecontext.SaveChanges();// guardas los cambios y actualizas
                res.CodEx = 1;// al CodEx le vas a asignar el numero 1
                res.mensaje = "Cd Actualizado satisfactoriamente";// Asignele a la propiedad mensaje lo sigueinte
            }
            catch (Exception e)//pero si hay una excepcion capturemela en la variable e
            {

                res.mensaje = "El error que surgió fue: " + e.Message;// almaceneme en la propiedad mensaje la excepcion
            }
            return Ok(res.mensaje + " " + res.CodEx);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            respuesta res = new respuesta();
            try
            {
                var disk = _mybasecontext.Discos.Find(id);// me vas a tomar un objeto de tipo Clientes y me los va a buscar , si lo encontraste ,ahora toma los nuevos campos y eemplazalos porla nueva informacio
                _mybasecontext.Discos.Remove(disk);
                _mybasecontext.SaveChanges();// cuando lo agrege guarde los cambios en la base de daos
                res.CodEx = 1;
                res.mensaje = "Disco eliminado exitosament";
               
            }
            catch (Exception e)
            {

                res.mensaje = "Ocurrio un problema por "+e.Message;
                
            }
            return Ok(res.mensaje + " " + res.CodEx);
        }

    }
}
