using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using QLKHO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace QLKHO.Areas.Admin.Pages.Users
{
    public class AddRoleModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }
        
        [BindProperty]
        [DisplayName("Các vai trò của user")]
        public string[] RoleNames { get; set; } // dùng để biding dữ liệu
        public SelectList allRole { get; set; } // list các role để đưa vào listbox
        public AppUser user { get; set; } // người dùng
        public async Task<IActionResult> OnGetAsync(string userid)
        {
            if(String.IsNullOrEmpty(userid))
                return NotFound("Không có user");

            user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return NotFound($"Không tìn thấy user có id = {userid}.");
            }
            List<string> _roleName = await _roleManager.Roles.Select(r => r.Name).ToListAsync<string>();
            allRole = new SelectList(_roleName);
            //Lấy các role cũ củ user
            RoleNames = (await _userManager.GetRolesAsync(user)).ToArray<string>();
            
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string userid)
        {
            if (String.IsNullOrEmpty(userid))
                return NotFound("Không có user");

            user = await _userManager.FindByIdAsync(userid);

            if (user == null)
            {
                return NotFound($"Không tìn thấy user có id = {userid}.");
            }
            if (!ModelState.IsValid)
            {
                List<string> _roleName = await _roleManager.Roles.Select(r => r.Name).ToListAsync<string>();
                allRole = new SelectList(_roleName);
                return Page();
            }
            var OldRoleNames = (await _userManager.GetRolesAsync(user)).ToArray<string>();
            var deleteRole = OldRoleNames.Where(r => !RoleNames.Contains(r)); // lấy những bản ghi không nằm trong RoleNames
            var addRoles = RoleNames.Where(r => !OldRoleNames.Contains(r)); // lấy những bản ghi không năm trong OldRoleNames
            var resultdelete = await _userManager.RemoveFromRolesAsync(user, deleteRole);
            if (!resultdelete.Succeeded)
            {
                resultdelete.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                });
                List<string> _roleName = await _roleManager.Roles.Select(r => r.Name).ToListAsync<string>();
                allRole = new SelectList(_roleName);
                return Page();
            }
            var resultAdd = await _userManager.AddToRolesAsync(user, addRoles);
            if (!resultAdd.Succeeded)
            {
                resultAdd.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                });
                List<string> _roleName = await _roleManager.Roles.Select(r => r.Name).ToListAsync<string>();
                allRole = new SelectList(_roleName);
                return Page();
            }
            StatusMessage = $"Đã cập nhật vai trò cho user {user.UserName}.";

            return RedirectToPage("./Index");
            /*
            if (!addPasswordResult.Succeeded)
            {
                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            StatusMessage = $"Mật khẩu của user {user.UserName} đã được đặt lại.";

            return RedirectToPage("./Index");
            */
        }
    }
}
