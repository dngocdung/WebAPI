using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiModel loai);
        void Updater(LoaiVM loai);
        void Delete(LoaiVM id);
    }
}
