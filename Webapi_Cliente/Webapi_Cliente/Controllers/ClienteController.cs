using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi_Cliente.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webapi_Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ApplicationContext _context;

        public ClienteController(ApplicationContext context)
        {
            _context = context;

        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var dbCliente = await _context.Clientes.FindAsync(id);

            if (dbCliente == null)
            { 
                return NotFound();
            }

            return dbCliente;
        }


        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> AddCliente(Cliente dbCliente)
        {
            _context.Clientes.Add(dbCliente);
            await _context.SaveChangesAsync();
            return dbCliente;
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Cliente dbCliente)
        {
            if (id != dbCliente.ID)
            {
                dbCliente.ID = id;
            }

            _context.Entry(dbCliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var dbCliente = await _context.Clientes.FindAsync(id);
            if (dbCliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(dbCliente);
            await _context.SaveChangesAsync();
            return NoContent();  
        }


    }
}
