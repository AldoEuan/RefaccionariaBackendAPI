using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refaccionaria.Data;
using Refaccionaria.Data.Maping;
using RefaccionariaBackendApi.Interface;
using RefaccionariaBackendApi.Models.Response;

namespace RefaccionariaBackendApi.Controllers
{
    [Route("api/detalleventa")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IRepository<DetalleVenta> repository;
        private readonly RefaccionariaDBContext context;

        public DetalleVentaController(IRepository<DetalleVenta> repository, RefaccionariaDBContext context)
        {
            this.repository = repository;
            this.context = context;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<Response<DetalleVenta>>> GetById(int id)
        {
            Response<DetalleVenta> response = new();

            response.success = true;

            response.message = "Exito";

            var resDetalleVenta = await repository.Get(id);

            response.data = resDetalleVenta;

            return Ok(response);
        }

        [HttpGet]
        [Route("getWithSale/{id}")]
        public async Task<ActionResult<Response<List<DetalleVenta>>>> GetByIdVenta(int id)
        {
            Response<List<DetalleVenta>> response = new();

            response.success = true;

            var res = context.Detalleventa.Where(x => x.IdVenta == id).ToList();

            response.data = res;
            
            return Ok(response);

        }
    }
}
