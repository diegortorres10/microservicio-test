using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microservicio.Core.IConfiguration;
using Microservicio.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteController(
            ILogger<ClienteController> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ActionName(nameof(CreateCliente))]
        public async Task<IActionResult> CreateCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                
                await _unitOfWork.Clientes.Add(cliente);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new { cliente.ClienteId }, cliente);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _unitOfWork.Clientes.All();

            return Ok(clientes);
        }
    }
}
