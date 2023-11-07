using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QLKHO.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string FullName { get; set; }
        [StringLength(1000)]
        [Column(TypeName = "nvarchar")]
        public string PhotoAvatar { get; set; }
    }
}
