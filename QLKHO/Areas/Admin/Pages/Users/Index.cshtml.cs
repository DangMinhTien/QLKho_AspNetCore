using QLKHO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace QLKHO.Areas.Admin.Pages.Users
{
    //[Authorize(Roles = "Admin,Editor")]
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> userManager;
        [TempData]
        public string StatusMessage { get; set; }
        public List<AppUser> users { get; set; }


        //Tao phân trang
        public const int ITEM_PER_PAGE = 5;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPage { get; set; }
        //Tìm kiếm
        [BindProperty(SupportsGet = true)]
        public string search { get; set; }
        public IndexModel(UserManager<AppUser> _usermanage)
        {
            userManager = _usermanage;
        }
        public async Task OnGet()
        {
            if (String.IsNullOrEmpty(search))
                search = "";
            int total = await userManager.Users
                .Where(u => u.UserName.Contains(search))
                .CountAsync();

            countPage = (int)Math.Ceiling((double)total / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPage)
                currentPage = countPage;
            
            if (total > 0)
            {
                users = await userManager.Users
                            .Where(u => u.UserName.Contains(search))
                            .Skip((currentPage - 1) * ITEM_PER_PAGE)
                            .Take(ITEM_PER_PAGE).ToListAsync();
            }
            else
            {
                users = await userManager.Users
                    .Where(u => u.UserName.Contains(search))
                    .ToListAsync();
            }
        }
        public void OnPost()
        {

        }
    }
}