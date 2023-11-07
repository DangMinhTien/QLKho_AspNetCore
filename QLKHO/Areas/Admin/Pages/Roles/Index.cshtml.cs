using QLKHO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace QLKHO.Areas.Admin.Pages.Roles
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class IndexModel : RolePageModel
    {
        public List<IdentityRole> roles { get; set; }
        public IdentityRole role { get; set; }
        public IndexModel(RoleManager<IdentityRole> _rolemanage, AppDbContext _dbcontext): base(_rolemanage, _dbcontext)
        {
            
        }
        public async Task OnGet()
        {
            roles = await rolemanage.Roles.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            if (roleid == null)
            {
                return NotFound();
            }
            role = await rolemanage.FindByIdAsync(roleid);
            if (role == null)
            {
                return NotFound();
            }
            var result = await rolemanage.DeleteAsync(role);
            if (result.Succeeded)
            {
                StatusMessage = $"Bạn vừa xóa role {role.Name}";
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
