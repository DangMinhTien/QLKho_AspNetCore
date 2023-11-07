using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using QLKHO.Validation;

namespace Validation_ModelBinder.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Chọn file upload")]
        [DataType(DataType.Upload)]
        [DisplayName("File UpLoad")]
        [ChkFileExtension(Extensions = "jpg,png,docx")]
        public IFormFile FileUpLoader { get; set; }
        [DisplayName("Chọn nhiều file")]
        public IFormFile[] FileUpLoads { get; set; }
        public string thongbao { get; set; }
        public ILogger<ContactModel> _logger { get; set; }
        
        private readonly IWebHostEnvironment _environment;
        public ContactModel(ILogger<ContactModel> logger, IWebHostEnvironment environment)
        {
            _logger= logger;
            _environment= environment;
        }
        public void OnGet()
        {
            thongbao = "Oke";
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                
                if(FileUpLoader != null)
                {
                    var filepath = Path.Combine(_environment.WebRootPath, "upload", FileUpLoader.FileName);
                    using var filestream = new FileStream(filepath, FileMode.Create);
                    FileUpLoader.CopyTo(filestream);
                }
                if(FileUpLoads != null)
                {
                    foreach(var f in FileUpLoads)
                    {
                        var filepath = Path.Combine(_environment.WebRootPath, "upload", f.FileName);
                        using var filestream = new FileStream(filepath, FileMode.Create);
                        f.CopyTo(filestream);
                    }
                }
            }
            
        }
    }
}
