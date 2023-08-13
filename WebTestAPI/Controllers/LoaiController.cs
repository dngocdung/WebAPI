using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestAPI.Data;
using WebTestAPI.Models;

namespace WebTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(l => l.MaLoai == id);
            if (loai == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(loai);
            }
        }
        [HttpPost]
        //[Authorize]
        public IActionResult Create(LoaiModel model)
        {
            try
            {
                var loai = new Loai()
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLoai(LoaiModel model, int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok(loai);
            }
            else { return NotFound(); }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                _context.Loais.Remove(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            else
            { return NotFound(); }
        }
    }
}
