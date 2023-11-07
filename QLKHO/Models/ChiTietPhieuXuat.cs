using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class ChiTietPhieuXuat
    {

        [Key]
        public int MaPX { get; set; }
        [ForeignKey("MaPX")]
        public PhieuXuat PhieuXuat { get;set; }
        [Key]
        public int? MaSp { get; set; }
        [ForeignKey("MaSp")]
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
