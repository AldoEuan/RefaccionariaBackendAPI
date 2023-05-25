using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refaccionaria.Data;
using Refaccionaria.Data.Maping;
using RefaccionariaBackendApi.Interface;
using RefaccionariaBackendApi.Models.Response;

namespace RefaccionariaBackendApi.Controllers
{
    [Route("api/venta")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IRepository<Sale> repVenta;
        private readonly IRepository<DetalleVenta> repDetalleVenta;
        private readonly IRepository<Producto> repProducto;
        private readonly RefaccionariaDBContext context;

        public VentaController(IRepository<Sale> repVenta, IRepository<DetalleVenta> repDetalleVenta, IRepository<Producto> repProducto, RefaccionariaDBContext context)
        {
            this.repVenta = repVenta;
            this.repDetalleVenta = repDetalleVenta;
            this.repProducto = repProducto;
            this.context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<Response<List<Sale>>>> GetAll()
        {
            Response<List<Sale>> response = new Response<List<Sale>>();

            response.success = true;

            var resSale = await repVenta.GetAll();
            
            if(resSale == null)
            {
                response.message = "Sin ninguna venta";
                response.data = null;
                return Ok(response);
            }

            response.message = "Exito";
            response.data = resSale;

            return Ok(response) ;

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<Response<Sale>>> Delete(int id)
        {
            Response<Sale> response = new();

            response.success = true;

            var sale = await repVenta.Get(id);
            var res = context.Detalleventa.Where(x => x.IdVenta == sale.Id).ToList();

            foreach(var item in res)
            {
                if (item != null)
                {
                    await repDetalleVenta.Delete(item);
                }
            }

            await repVenta.Delete(sale);

            response.message = "Venta eliminada";

            return Ok(response);
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<ActionResult<Response<Sale>>> Checkout(List<Producto> lstProductos)
        {
            Response<Sale> response = new Response<Sale>();
            response.success = true;
            response.data = null;


            foreach (var item in lstProductos)
            {
                var resProducto = await repProducto.Get(item.Id);
                if (resProducto == null)
                {
                    response.message = "No se encontraron Productos :(";
                    return BadRequest(response);
                }
                if(resProducto.Existencia <= 0)
                {
                    response.message = "El producto no tiene stock";
                    return BadRequest(response);
                }
            }

            Sale venta = new Sale
            {
                Total = 0
            };

            var resVenta = await repVenta.Create(venta);

            List<DetalleVenta> detalleVenta = new List<DetalleVenta>();

            foreach (var item in lstProductos)
            {
                detalleVenta.Add(new DetalleVenta
                {
                    IdVenta = resVenta.Id,
                    IdProducto = item.Id,
                    Precioventa = item.Precioventa,
                    Cantidad = 1,
                });
            }

            double total = 0;
            foreach (var item in detalleVenta) {
                var resDetalle = await repDetalleVenta.Create(item);

                total += resDetalle.Precioventa * resDetalle.Cantidad;
                if(resDetalle == null)
                {
                    response.message = "Error al crear detalle";
                    return BadRequest(response);
                }
            }

            venta.Id = resVenta.Id;
            venta.Total = total;

            var updateVenta = await repVenta.Update(venta);

            response.message = "Venta exitosa";
            response.data = updateVenta;

            return Ok(response);
        }
    }
}
