using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestAPI.Models;

namespace WebTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHH == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa()
            {
                MaHH = Guid.NewGuid(),
                TenHH = hangHoaVM.TenHH,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new { Success = true, Data = hanghoa });
        }
        [HttpPut]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHH == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound();
                }    
                if(id != hangHoa.MaHH.ToString())
                {
                    return BadRequest();
                }
                hangHoa.TenHH = hangHoaEdit.TenHH;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHH == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(hangHoa); return Ok();
            }
            catch { return BadRequest(); }
        }
    }
}
