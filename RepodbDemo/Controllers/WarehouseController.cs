using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RepodbDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
       private readonly WarehouseRepository _warehouseRepository;

        public WarehouseController(WarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Warehouse warehouse)
        {
            return Ok(_warehouseRepository.Insert(warehouse));
        }
    }
}
