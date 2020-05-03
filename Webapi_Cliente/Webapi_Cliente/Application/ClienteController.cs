using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webapi_Cliente.Domain.Entities;
using Webapi_Cliente.Domain.Interface;
using Webapi_Cliente.Service.Validators;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webapi_Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private IService<Cliente> service;

        public ClienteController(IService<Cliente> _service)
        {
            service = _service;

        }

        // GET: api/Cliente
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return new ObjectResult(service.Get());
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // POST: api/Cliente
        [HttpPost]
        public ActionResult<Cliente> AddCliente(Cliente dbCliente)
        {
            try
            {
                service.Post<ClienteValidator>(dbCliente);

                return new ObjectResult(dbCliente);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, Cliente dbCliente)
        {
            try
            {
                dbCliente.Id = id;
                service.Put<ClienteValidator>(dbCliente);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public ActionResult<Cliente> DeleteCliente(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
  
        }

    }
}
