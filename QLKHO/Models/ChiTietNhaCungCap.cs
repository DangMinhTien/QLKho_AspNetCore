using MailKit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class ChiTietNhaCungCap
    {
        [Key]
        public int MaSp { get; set; }
        [Key]
        public int MaNcc { get; set; }
        public decimal GiaNhap { get; set; }
        [ForeignKey("MaNcc")]
        public NhaCungCap NhaCungCap { get; set;}
        [ForeignKey("MaSp")]
        public SanPham SanPham { get; set; }
    }
}
