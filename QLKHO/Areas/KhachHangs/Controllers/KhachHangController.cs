using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLKHO.Models;

namespace QLKHO.Areas.KhachHangs.Controllers
{
    [Route("/[controller]/[action]")]
    [Area("KhachHangs")]
    [Authorize(Roles = "Admin,NhanVien")]
    public class KhachHangController : Controller
    {
        private readonly AppDbContext _context;

        public KhachHangController(AppDbContext context)
        {
            _context = context;
        }
        public int ITEM_PER_PAGE = 10;
        public int currentPage { get; set; }
        public int countPage { get; set; }
        // GET: KhachHangs/KhachHang
        public async Task<IActionResult> Index(int? p, string search)
        {
            if (p != null)
            {
                currentPage = p.Value;
            }
            if (string.IsNullOrEmpty(search))
            {
                search = "";
            }
            int total = await _context.khachHangs.Where(kh => kh.TenKh.Contains(search)).CountAsync();

            countPage = (int)Math.Ceiling((double)total / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPage)
                currentPage = countPage;
            List<KhachHang> khachHangs = new List<KhachHang>();
            if(total > 0)
            {
                khachHangs = await _context.khachHangs
                            .Where(kh => kh.TenKh.Contains(search))
                            .Skip((currentPage - 1) * ITEM_PER_PAGE)
                            .Take(ITEM_PER_PAGE).ToListAsync();
            }
            else
            {
                khachHangs = await _context.khachHangs
                            .Where(kh => kh.TenKh.Contains(search))
                            .ToListAsync();
            }
            ViewData["current"] = currentPage;
            ViewData["countpage"] = countPage;
            ViewData["search"] = search;
            return View(khachHangs);
        }

        

        // GET: KhachHangs/KhachHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhachHangs/KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenKh,Email,Phone")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                if(await _context.khachHangs.FirstOrDefaultAsync(kh => kh.Email == khachHang.Email) != null)
                {
                    TempData["thongbao"] = "Error Email bị trùng với khách hàng khác";
                    return View(khachHang);
                }
                if (await _context.khachHangs.FirstOrDefaultAsync(kh => kh.Phone == khachHang.Phone) != null)
                {
                    TempData["thongbao"] = "Error Số điện thoại bị trùng với khách hàng khác";
                    return View(khachHang);
                }
                try
                {
                    _context.Add(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    TempData["thongbao"] = "Error Tạo thất bại";
                    return View(khachHang);
                }
                TempData["thongbao"] = "Tạo Khách Hàng thành công";
                return RedirectToAction(nameof(Index));
            }
            TempData["thongbao"] = "Error Tạo thất bại do chưa nhập đúng dữ liệu";
            return View(khachHang);
        }

        // GET: KhachHangs/KhachHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.khachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MaKh,TenKh,Email,Phone")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                if (await _context.khachHangs
                    .FirstOrDefaultAsync(kh => kh.Email == khachHang.Email && kh.MaKh != khachHang.MaKh) != null)
                {
                    TempData["thongbao"] = "Error Email bị trùng với khách hàng khác";
                    return View(khachHang);
                }
                if (await _context.khachHangs
                    .FirstOrDefaultAsync(kh => kh.Phone == khachHang.Phone && kh.MaKh != khachHang.MaKh) != null)
                {
                    TempData["thongbao"] = "Error Số điện thoại bị trùng với khách hàng khác";
                    return View(khachHang);
                }
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.MaKh))
                    {
                        return NotFound("khách hàng này không tồn tại");
                    }
                    else
                    {
                        TempData["thongbao"] = $"Error khách hàng thất bại";
                        return View(khachHang) ;
                    }
                }
                TempData["thongbao"] = $"Bạn đã sửa thành công khách hàng có mã {khachHang.MaKh}";
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }

        // POST: KhachHangs/KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound("Không xóa được khách hàng");
            }
            KhachHang khachHang = await _context.khachHangs.SingleOrDefaultAsync(k => k.MaKh == id);
            if(khachHang == null)
            {
                return NotFound("Không xóa được do không tìm thấy khách hàng");
            }
            try
            {
                _context.khachHangs.Remove(khachHang);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                TempData["thongbao"] = $"Error không xóa được khách hàng có mã {khachHang.MaKh}";
                return RedirectToAction(nameof(Index));
            }
            TempData["thongbao"] = $"Xóa khách hàng thành công";
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(int id)
        {
            return _context.khachHangs.Any(e => e.MaKh == id);
        }
    }
}
