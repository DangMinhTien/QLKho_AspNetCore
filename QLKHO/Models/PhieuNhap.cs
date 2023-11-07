using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class PhieuNhap
    {
        [Key]
        public int MaPN { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; }
        public int TongSoLuong { get; set; }
        public decimal TongTien { get; set; }
        public int? MaNcc { get; set; }
        [ForeignKey("MaNcc")]
        public NhaCungCap NhaCungCap { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(1000)]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}
