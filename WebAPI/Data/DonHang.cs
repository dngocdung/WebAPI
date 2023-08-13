namespace WebAPI.Data
{
    public enum TinhTrangDonHang
    {
        New, Payment, Complete, Cancel
    }
    public class DonHang
    {
        public Guid MaDh {  get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TinhTrangDonHang TinhTrangDonHang { get; set; }
        public string NguoiNhan { get; set; }   
        public string DicChiGiao { get; set; }
        public string SDT { get; set; }
        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
