using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKHO.Models
{
    public class KhachHang
    {
        [Key]
        [DisplayName("Mã khách hàng")]
        public int MaKh { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(500, ErrorMessage = "{0} có độ dài nhỏ hơn {1} ký tự")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tên khách hàng")]
        public string TenKh { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(500, ErrorMessage = "{0} có độ dài nhỏ hơn {1} ký tự")]
        [EmailAddress(ErrorMessage = "{0} phài là địa chỉ Email")]
        [DisplayName("Email Khách Hàng")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(20, ErrorMessage = "{0} có độ dài nhỏ hơn {1} ký tự")]
        [Phone(ErrorMessage = "Phải nhập số điện thoại")]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
    }
}
