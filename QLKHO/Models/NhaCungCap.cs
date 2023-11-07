using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class NhaCungCap
    {
        [Key]
        [DisplayName("Mã Nhà cung cấp")]
        public int MaNcc { get; set; }
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tên Nhà cung cấp")]
        [StringLength(500, ErrorMessage = "{0} không được vượt quá {1} ký tự")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string TenNcc { get; set;}
        [Required(ErrorMessage = "{0} không được để trống")]
        [EmailAddress(ErrorMessage = "{0} phải là Email")]
        [StringLength(500, ErrorMessage = "{0} không được vượt quá {1} ký tự")]
        [DisplayName("Địa chỉ Email")]
        public string Email { get; set;}
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(20, ErrorMessage = "{0} không được vượt quá {1} ký tự")]
        [DisplayName("Số điện thoại")]
        [Phone(ErrorMessage = "Phải nhập vào số điện thoại")]
        public string Sdt { get; set;}
    }
}
