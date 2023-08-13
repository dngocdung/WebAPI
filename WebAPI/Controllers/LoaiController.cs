using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly ILoaiRepository _loaiReponsitory;
        public LoaiController(ILoaiRepository loaiReponsitory)
        {
            _loaiReponsitory = loaiReponsitory;
        }

        [HttpGet] 
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiReponsitory.GetAll());
            }
            catch
            {
                //return StatusCode(StatusCodes.Status500InternalServerError);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _loaiReponsitory.GetById(id);
            if(data != null)
            {
                return Ok(data);
            }
            else { return StatusCode(StatusCodes.Status500InternalServerError); }
        }

        [HttpPost]
        public IActionResult Add(LoaiModel loai)
        {
            try
            {
                return Ok(_loaiReponsitory.Add(loai));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
