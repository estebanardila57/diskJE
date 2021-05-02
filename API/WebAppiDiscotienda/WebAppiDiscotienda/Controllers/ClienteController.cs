using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyectodisctienda.Models;
using proyectodisctienda.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppiDiscotienda.Respuesta;

namespace WebAppiDiscotienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Context _mybasecontext;

        public ClienteController(Context miBD)
        {
            _mybasecontext = miBD;
        }

        [HttpGet]

        public IActionResult Get()
        {
            respuesta res = new respuesta();

            try
            {
                var listaclientes = _mybasecontext.Clientes.ToList();
                res.Data = listaclientes;
                return Ok(res);
            }
            catch (Exception e)
            {
                res.mensaje = "Ocurrio un problema por" + e.Message;
                return Ok(res);
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
                clien.Estado = true;
                _mybasecontext.Clientes.Add(clien);
                _mybasecontext.SaveChanges();// cuando lo agrege guarde los cambios en la base de daos
                res.CodEx = 1;
                res.mensaje = "Cliente agregado exitosament";
               
            }
            catch (Exception e)
            {

                res.mensaje = "Ocurrio un problema por" +e.Message;
                
            }
            return Ok(res);
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
               
            }
            catch (Exception e)
            {

                res.mensaje = "Ocurrio un problema por" +e.Message;
                
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            respuesta res = new respuesta();
            try
            {
                var clien = _mybasecontext.Clientes.Find(id);// me vas a tomar un objeto de tipo Clientes y me los va a buscar , si lo encontraste ,ahora toma los nuevos campos y eemplazalos porla nueva informacio
                if (clien.Estado)
                {
                    clien.Estado = false;
                }
                else
                {
                    clien.Estado = true;
                }
                _mybasecontext.Clientes.Update(clien);
                _mybasecontext.SaveChanges();// cuando lo agrege guarde los cambios en la base de daos
                res.CodEx = 1;
                res.mensaje = "Cliente eliminado exitosament";
                
            }
            catch (Exception e)
            {

                res.mensaje = "Ocurrio un problema por"+e.Message;
                
            }
            return Ok(res);
        }

    }
}
