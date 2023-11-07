using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLKHO.Models;
using QLKHO.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace QLKHO.Areas.Identity.Pages.Account.Manage
{
    public class SetAvartarModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        public SetAvartarModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [BindProperty]
        [Required(ErrorMessage = "Chọn file upload")]
        [DataType(DataType.Upload)]
        [DisplayName("File UpLoad")]
        [ChkFileExtension(Extensions = "jpg,png,jpeg,gif")]
        public IFormFile FileUpLoader { get; set; }
        public async void OnGet()
        {
            
        }
        public async Task OnPost(string Id)
        {
            if(ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(Id))
                {
                    AppUser user = await _userManager.FindByIdAsync(Id);
                    if(user != null)
                    {
                        if(FileUpLoader != null)
                        {
                            var file1 = Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                                        + Path.GetExtension(FileUpLoader.FileName);

                            var file = Path.Combine("wwwroot", "Upload", "Avartar", file1);
                            using (var filestream = new FileStream(file, FileMode.Create))
                            {
                                await FileUpLoader.CopyToAsync(filestream);
                            }
                            user.PhotoAvatar = file1;
                            var result = await _userManager.UpdateAsync(user);
                            if (!result.Succeeded)
                            {
                                foreach (var error in result.Errors)
                                {
                                    ModelState.AddModelError(string.Empty, error.Description);
                                }
                            }

                            await _signInManager.RefreshSignInAsync(user);
                        }
                    }
                }
            }
        }
    }
}
