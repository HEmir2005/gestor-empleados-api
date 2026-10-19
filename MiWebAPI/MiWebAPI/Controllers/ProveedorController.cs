using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiWebAPI.Data;
using MiWebAPI.Models;

namespace MiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorData _proveedorData;
        public ProveedorController(ProveedorData proveedorData)
        {
            _proveedorData = proveedorData;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Proveedor objeto)
        {
            bool respuesta = await _proveedorData.Crear(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Proveedor> Lista = await _proveedorData.Lista();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Proveedor objeto)
        {
            bool respuesta = await _proveedorData.Actualizar(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(long id)
        {
            bool respuesta = await _proveedorData.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerId(long id)
        {
            Proveedor objeto = await _proveedorData.ObtenerId(id);
            return StatusCode(StatusCodes.Status200OK, objeto);
        }
    }
}
