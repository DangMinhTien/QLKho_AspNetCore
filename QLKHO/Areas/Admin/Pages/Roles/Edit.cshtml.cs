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
    public class EditModel : RolePageModel
    {
        public EditModel(RoleManager<IdentityRole> _rolemanage, AppDbContext _dbcontext) : base(_rolemanage, _dbcontext)
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
        public IdentityRole role { get; set; }
        public async Task<IActionResult> OnGet(string roleid)
        {
            if(roleid == null)
            {
                return NotFound("Không tìm thấy role");
            }
            
            role = await rolemanage.FindByIdAsync(roleid);
            if(role != null)
            {
                Input = new InputModel()
                {
                    Name = role.Name,
                };
                return Page();
            }
            return NotFound("Không tìm thấy role");
        }
        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            if (roleid == null)
            {
                return NotFound();
            }
            role = await rolemanage.FindByIdAsync(roleid);
            if(role == null) 
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            role.Name = Input.Name;
            var result = await rolemanage.UpdateAsync(role);
            if(result.Succeeded)
            {
                StatusMessage = $"Bạn vừa sửa role {Input.Name}";
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
