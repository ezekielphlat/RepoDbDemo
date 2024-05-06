using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RepodbDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
       private readonly WarehouseRepository _warehouseRepository;
        private readonly IWarehouseObjectRepo _warehouseObjectRepo;
        private readonly IWarehouseInlineRepo _warehouseInlineRepo;

        public WarehouseController(WarehouseRepository warehouseRepository, IWarehouseObjectRepo warehouseObjectRepo, IWarehouseInlineRepo warehouseInlineRepo )
        {
            _warehouseRepository = warehouseRepository;
            _warehouseObjectRepo = warehouseObjectRepo;
            _warehouseInlineRepo = warehouseInlineRepo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Warehouse warehouse)
        {
            _warehouseInlineRepo.Add(warehouse);
            return Ok();
        }
    }
}
