using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refaccionaria.Data.Maping;
using RefaccionariaBackendApi.Interface;
using RefaccionariaBackendApi.Models.Response;

namespace RefaccionariaBackendApi.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IRepository<Producto> repository;

        public ProductoController(IRepository<Producto> repository) {
            this.repository = repository;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<Response<List<Producto>>>> getAll()
        {
            Response<List<Producto>> response = new Response<List<Producto>>();

            response.success = true;
            response.data = await repository.GetAll();
            response.message = "Exito";

            return Ok(response);
        }

        [HttpGet]
        [Route("getItem/{id}")]
        public async Task<ActionResult<Response<Producto>>> get(int Id)
        {
            Response<Producto> response = new Response<Producto>();

            response.success = true;
            response.data = await repository.Get(Id);
            response.message = "Exito";

            return Ok(response);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Response<Producto>>> Create(Producto producto)
        {
            Response<Producto> response = new Response<Producto>();

            if (!ModelState.IsValid)
            {
                response.success = false;
                response.message = "Error al crear producto";
                return BadRequest(response);
            }

            response.success = true;
            response.message = "Producto creado";
            response.data = await repository.Create(producto);

            return Ok(response);

             
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Response<Producto>>> Edit(int Id,Producto producto)
        {
            Response<Producto> response = new Response<Producto>();
            if (Id != producto.Id)
            {
                response.success = false;
                response.message = "Error al actualizar producto";
                return BadRequest(response);
            }

            response.success = true;
            response.message = "Producto actualizado";
            response.data = await repository.Update(producto);

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<Response<Producto>>> delete(int Id)
        {
            Response<Producto> response = new Response<Producto>();

            var producto = await repository.Get(Id);

            if(producto == null) { 
                response.success = false;
                response.message = "Nose encontro el producto";
                return NotFound(response);
            }

            await repository.Delete(producto);

            response.success = true;
            response.message = "Producto Eliminado con Exito";

            return Ok(response);
        }
    }
}
