using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using QLKHO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace QLKHO.Areas.Admin.Pages.Users
{
    public class SetPasswordModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SetPasswordModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(100, ErrorMessage = "{0} phải có từ {2} đến {1} kí tự.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu mới")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
            public string ConfirmPassword { get; set; }
        }
        public AppUser user { get; set; }
        public async Task<IActionResult> OnGetAsync(string userid)
        {
            if(String.IsNullOrEmpty(userid))
                return NotFound("Không có user");

            user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return NotFound($"Không tìn thấy user có id = {userid}.");
            }

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
                return Page();
            }
            await _userManager.RemovePasswordAsync(user);

            var addPasswordResult = await _userManager.AddPasswordAsync(user, Input.NewPassword);
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
        }
    }
}
