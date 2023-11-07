using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class DonViTinh
    {
        [Key]
        [DisplayName("Mã đơn vị tính")]
        public int MaDvt { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(500, ErrorMessage = "{0} có độ dài nhỏ hơn {1} ký tự")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tên đơn vị tính")]
        public string TenDvt { get; set;}
    }
}
