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
    public class UserController : ControllerBase
    {
        private readonly Basecontext _mybasecontext;// creamos un obejto de solo lectura de tipo basecontex que es el engardo que hacer las operaciones en la base de datos
        public UserController(Basecontext contexto)
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
                var lista = _mybasecontext.Usersystems.ToList();// me devuelve todo lo que hay en la tabla
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

        public IActionResult Add(UsersysViewModel oUser)
        {
            respuesta res = new respuesta();// instanciamos un objeto de tipo respuesta
            // las siguientes lineas estan mejor explicadas en el discoController
            try
            {
                Usersystem user = new Usersystem();
                    user.descripcioncargo = oUser.descripcioncargo;
                    user.Nomuser = oUser.Nomuser;
                    user.Pass = oUser.Pass;
                user.Idcliente = oUser.Idcliente;
                    _mybasecontext.Usersystems.Add(user);
                    _mybasecontext.SaveChanges();
                    res.CodEx = 1;// al CodEx le vas a asignar el numero 1
                    res.mensaje = "Usuario Agregado satisfactoriamente";
            }
            catch (Exception e)
            {
                res.mensaje = "Ocurrio un problema por "+e.Message;
                
            }
            return Ok(res.mensaje + " " + res.CodEx);
        }
        [HttpPut]
        public IActionResult update(UsersysViewModel oUser) 
        {
            respuesta res = new respuesta();// instanciamos un objeto de tipo respuesta
            // las siguientes lineas estan mejor explicadas en el discoController
            try
            {
                var user = _mybasecontext.Usersystems.Find(oUser.Id);
                user.descripcioncargo = oUser.descripcioncargo;
                user.Nomuser = oUser.Nomuser;
                user.Pass = oUser.Pass;
                user.Idcliente = oUser.Idcliente;
                _mybasecontext.Usersystems.Update(user);
                _mybasecontext.SaveChanges();
                res.CodEx = 1;// al CodEx le vas a asignar el numero 1
                res.mensaje = "Usuario Actualizado satisfactoriamente";
            }
            catch (Exception e)
            {
                res.mensaje = "Ocurrio un problema por "+e.Message;
                
            }
            return Ok(res.mensaje + " " + res.CodEx);

        }

        [HttpDelete("{id}")]

        public IActionResult delete(int id)
        {
            respuesta res = new respuesta();
            try
            {
                var user = _mybasecontext.Usersystems.Find(id);
                _mybasecontext.Usersystems.Remove(user);
                _mybasecontext.SaveChanges();
                res.CodEx = 1;
                res.mensaje = "Usuario eliminado exitosament";

            }
            catch (Exception e)
            {

                res.mensaje = "Ocurrio un problema por " + e.Message;

            }

            return Ok(res.mensaje + " " + res.CodEx);
        }





    }

}
