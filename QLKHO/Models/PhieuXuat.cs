using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class PhieuXuat
    {
        [Key]
        public int MaPX { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; }
        public int TongSoLuong { get; set; }
        public decimal TongTien { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(1000)]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public int? MaKh { get; set; }
        [ForeignKey("MaKh")]
        public KhachHang KhachHang { get; set; }
    }
}
