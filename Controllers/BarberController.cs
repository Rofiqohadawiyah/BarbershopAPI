using Microsoft.AspNetCore.Mvc;
using BarbershopAPI.Context;

namespace BarbershopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarberController : ControllerBase
    {
        private readonly string _connStr;

        public BarberController(IConfiguration config)
        {
            _connStr = config.GetConnectionString("WebApiDatabase");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ctx = new BarberContext(_connStr);
            var data = ctx.GetAll();

            return Ok(new { status = "success", data });
        }
    }
}