using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectodisctienda.Respuesta;
using proyectodisctienda.Views;
using proyectodisctienda.Models;

namespace proyectodisctienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Basecontext _mybasecontext;
        public ClienteController(Basecontext contexto)
        {
            _mybasecontext = contexto;
        }
        [HttpGet]// Vergo que me permite leer o obtener datos (select

        public IActionResult Get()
        {
            respuesta res = new respuesta();
            try
            {
                //select *from Clientes y lo que me retorne asignimelo a la la varibale listaclientes(que en su caso tomara el contenido de lo que me retorne la lectura)
                var listaclientes = _mybasecontext.Clientes.ToList();
                return Ok(listaclientes);
            }
            catch (Exception e)
            {

                return Ok("Se ha producido un error por" + e.Message);
            }



        }

        [HttpPost]
        public IActionResult Add(ClienteViewModel oCLiente)
        {
            respuesta res = new respuesta();
            try
            {
                Clientes clien = new Clientes();
                clien.Nombrecli = oCLiente.Nombrecli;
                clien.Cedulacli = oCLiente.Cedulacli;
                clien.Telefonocli = oCLiente.Telefonocli;
                clien.Direccioncli = oCLiente.Direccioncli;
                _mybasecontext.Clientes.Add(clien);
                _mybasecontext.SaveChanges();// cuando lo agrege guarde los cambios en la base de daos
                res.CodEx = 1;
                res.mensaje = "Cliente agregado exitosament";
                return Ok(res.mensaje + " " + res.CodEx);
            }
            catch (Exception e)
            {
                
                res.mensaje = "Ocurrio un problema por";
                return Ok(res.CodEx + "" + res.mensaje + "" + e.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(ClienteViewModel oCLiente)
        {
            respuesta res = new respuesta();
            try
            {
                var clien = _mybasecontext.Clientes.Find(oCLiente.Id);// me vas a tomar un objeto de tipo Clientes y me los va a buscar , si lo encontraste ,ahora toma los nuevos campos y eemplazalos porla nueva informacion
                clien.Nombrecli = oCLiente.Nombrecli;
                clien.Cedulacli = oCLiente.Cedulacli;
                clien.Telefonocli = oCLiente.Telefonocli;
                clien.Direccioncli = oCLiente.Direccioncli;
                _mybasecontext.Clientes.Update(clien);
                _mybasecontext.SaveChanges();// cuando lo agrege guarde los cambios en la base de daos
                res.CodEx = 1;
                res.mensaje = "Cliente actualizado exitosament";
                return Ok(res.mensaje + " " + res.CodEx);
            }
            catch (Exception e)
            {
                
                res.mensaje = "Ocurrio un problema por";
                return Ok(res.CodEx + "" + res.mensaje + "" + e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            respuesta res = new respuesta();
            try
            {
                var clien = _mybasecontext.Clientes.Find(id);// me vas a tomar un objeto de tipo Clientes y me los va a buscar , si lo encontraste ,ahora toma los nuevos campos y eemplazalos porla nueva informacio
                _mybasecontext.Clientes.Remove(clien);
                _mybasecontext.SaveChanges();// cuando lo agrege guarde los cambios en la base de daos
                res.CodEx = 1;
                res.mensaje = "Cliente eliminado exitosament";
                return Ok(res.mensaje + " " + res.CodEx);
            }
            catch (Exception e)
            {
                
                res.mensaje = "Ocurrio un problema por";
                return Ok(res.CodEx + "" + res.mensaje + "" + e.Message);
            }
        }

    }
}
