using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _context;
        public LoaiRepository(MyDbContext context)
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai
            };
            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai

            };
        }

        public void Delete(LoaiVM id)
        {
            throw new NotImplementedException();
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(lo => new LoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai
            });
            return loais.ToList();
        }

        
        public LoaiVM GetById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(l=>l.MaLoai == id);
            if(loai != null)
            {
                return new LoaiVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai
                };
            }
            else
            {
                return null;
            }    
        }

        public void Updater(LoaiVM loai)
        {
            throw new NotImplementedException();
        }
    }
}
