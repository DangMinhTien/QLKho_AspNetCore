using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class SanPham
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        public int MaSp { get; set; }
        [Required]
        [StringLength(500)]
        [DisplayName("Tên sản phẩm")]
        [Column(TypeName = "nvarchar")]
        public string TenSp { get; set;}
        [DisplayName("Giá bán")]
        public decimal GiaBan { get; set; }
        [Range(0, int.MaxValue)]
        [DisplayName("Số lượng")]
        public int SoLuongCo { get; set; }
        [StringLength(1000)]
        [DisplayName("Hình ảnh")]
        public string Photo { get; set; }
        
        public int? MaDvt { get; set; }
        [ForeignKey("MaDvt")]
        [DisplayName("Đơn vị tính")]
        public DonViTinh DonViTinh { get; set; }
    }
}
