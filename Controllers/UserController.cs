using Microsoft.AspNetCore.Mvc;
using BarbershopAPI.Context;
using BarbershopAPI.Models;

namespace BarbershopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly string _connStr;

        public UserController(IConfiguration config)
        {
            _connStr = config.GetConnectionString("WebApiDatabase");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ctx = new UserContext(_connStr);
            return Ok(new { status = "success", data = ctx.GetAll() });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ctx = new UserContext(_connStr);
            var data = ctx.GetById(id);

            if (data == null)
                return NotFound(new { status = "error", message = "User tidak ditemukan" });

            return Ok(new { status = "success", data });
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = "error", message = "Input tidak valid" });

            var ctx = new UserContext(_connStr);

            if (ctx.EmailExists(user.email))
                return BadRequest(new { status = "error", message = "Email sudah digunakan" });

            ctx.Insert(user);

            return Ok(new { status = "success", message = "User berhasil ditambahkan" });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            var ctx = new UserContext(_connStr);

            if (!ctx.Update(id, user))
                return NotFound(new { status = "error", message = "User tidak ditemukan" });

            return Ok(new { status = "success", message = "User berhasil diupdate" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ctx = new UserContext(_connStr);

            if (!ctx.Delete(id))
                return NotFound(new { status = "error", message = "User tidak ditemukan / sudah dihapus" });

            return Ok(new { status = "success", message = "User berhasil dihapus" });
        }
    }
}