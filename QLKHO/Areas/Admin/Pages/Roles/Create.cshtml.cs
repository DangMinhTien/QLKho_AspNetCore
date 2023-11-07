using QLKHO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLKHO.Areas.Admin.Pages.Roles
{
    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> _rolemanage, AppDbContext _dbcontext) : base(_rolemanage, _dbcontext)
        {

        }
        
        public class InputModel
        {
            [Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải có độ dài từ {2} đến {1}")]
            [DisplayName("Tên của Role")]
            public string Name { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet()
        {
            Input = new InputModel();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var newRole = new IdentityRole(Input.Name);
            var result = await rolemanage.CreateAsync(newRole);
            if(result.Succeeded)
            {
                StatusMessage = $"Bạn vừa tạo role mới {Input.Name}";
                return RedirectToPage("./Index");
            }
            else
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }
            return Page();
        }
    }
}
