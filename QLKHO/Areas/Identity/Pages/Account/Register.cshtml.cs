using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using QLKHO.Models;
using QLKHO.Validation;

namespace QLKHO.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {

        
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Chọn file upload")]
        [DataType(DataType.Upload)]
        [DisplayName("File UpLoad")]
        [ChkFileExtension(Extensions = "jpg,png,jpeg,gif")]
        public IFormFile FileUpLoader { get; set; }
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Phải nhập {0}")]
            [EmailAddress(ErrorMessage = "Sai định dạng Email")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(100, ErrorMessage = "{0} phải dài ít nhất {2} và tối đa {1} ký tự.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
            public string ConfirmPassword { get; set; }
            [Required(ErrorMessage = "Phải nhập {0}")]
            [Display(Name = "Tên dăng nhập")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Phải nhập {0}")]
            public string FullName { get; set; }

        }
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var file1 = "";
                if(FileUpLoader!= null)
                {

                    file1 = Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                                    + Path.GetExtension(FileUpLoader.FileName);

                    var file = Path.Combine("wwwroot", "Upload", "Avartar", file1);
                    using(var filestream = new FileStream(file, FileMode.Create))
                    {
                        await FileUpLoader.CopyToAsync(filestream);
                    }
                }
                var user = new AppUser {PhotoAvatar = file1, FullName = Input.FullName, UserName = Input.UserName, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Đã tạo user mới");
                    // Phát sinh token để xác nhận Email
                    /*
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Xác nhận địa chỉ Email <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>bấm vào đây để kích hoạt tài khoản</a>.");
                    */
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        public async Task<IActionResult> OnPostSeed()
        {
            List<string> RoleNames = new List<string>()
            {
                "Admin",
                "NhanVien",
                "Editor"
            };
            foreach(var roleName in RoleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if(role == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            // admin - pw = admin123 - email = admin@gmail.com 
            var user1 = await _userManager.FindByEmailAsync("admin@example.com");
            
            if(user1 == null)
            {
                var user2 = await _userManager.FindByNameAsync("admin");
                if(user2 == null)
                {
                    var useradmin = new AppUser()
                    {
                        UserName = "admin",
                        Email = "admin@gmail.com",
                        EmailConfirmed = true,
                        PhotoAvatar = "admin",
                        FullName = "admin nhóm 9",
                    };
                    await _userManager.CreateAsync(useradmin,"admin123");
                    await _userManager.AddToRoleAsync(useradmin, "Admin");
                    TempData["thongbao"] = "tạo thành công user admin";
                    return RedirectToPage("./Login");
                }
                else
                {
                    TempData["thongbao"] = "Error User admin đã tồn tại";
                    return RedirectToPage("./Login");
                }
            }
            else
            {
                TempData["thongbao"] = "Error User admin đã tồn tại";
                return RedirectToPage("./Login");
            }
            
        }
    }
}
