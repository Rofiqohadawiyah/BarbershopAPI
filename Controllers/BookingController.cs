using Microsoft.AspNetCore.Mvc;
using BarbershopAPI.Context;
using BarbershopAPI.Models;

namespace BarbershopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly string _connStr;

        public BookingController(IConfiguration config)
        {
            _connStr = config.GetConnectionString("WebApiDatabase");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ctx = new BookingContext(_connStr);
            var data = ctx.GetAll();

            return Ok(new { status = "success", data });
        }

        [HttpPost]
        public IActionResult Post(Booking b)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = "error", message = "Input tidak valid" });

            var ctx = new BookingContext(_connStr);

            if (!ctx.UserExists(b.user_id))
                return BadRequest(new { status = "error", message = "User tidak ditemukan" });

            if (!ctx.BarberExists(b.barber_id))
                return BadRequest(new { status = "error", message = "Barber tidak ditemukan" });

            ctx.Insert(b.user_id, b.barber_id, b.tanggal, b.jam);

            return Ok(new { status = "success", message = "Booking berhasil dibuat" });
        }
    }
}