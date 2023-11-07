using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int MaPN { get; set; }
        [Key]
        public int? MaSp { get; set; }
        [ForeignKey("MaPN")]
        public PhieuNhap PhieuNhap { get; set;}
        [ForeignKey("MaSp")]
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
