using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiWebAPI.Data;
using MiWebAPI.Models;

namespace MiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteData _clienteData;
        public ClienteController(ClienteData clienteData)
        {
            _clienteData = clienteData;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] Cliente objeto)
        {
            bool respuesta = await _clienteData.Registrar(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarTodos()
        {
            List<Cliente> Lista = await _clienteData.ConsultarTodos();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            Cliente objeto = await _clienteData.ConsultarPorId(id);
            return StatusCode(StatusCodes.Status200OK, objeto);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Cliente objeto)
        {
            bool respuesta = await _clienteData.Actualizar(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DarDeBajaLogica(int id)
        {
            bool respuesta = await _clienteData.DarDeBajaLogica(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }
    }
}
