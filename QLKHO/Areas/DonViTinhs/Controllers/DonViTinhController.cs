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

namespace QLKHO.Areas.DonViTinhs.Controllers
{
    [Area("DonViTinhs")]
    [Route("/[controller]/[action]")]
    [Authorize(Roles = "Admin,NhanVien")]
    public class DonViTinhController : Controller
    {
        private readonly AppDbContext _context;

        public DonViTinhController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DonViTinhs/DonViTinh
        public async Task<IActionResult> Index()
        {
            return View(await _context.donViTinhs.ToListAsync());
        }

        

        // GET: DonViTinhs/DonViTinh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonViTinhs/DonViTinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenDvt")] DonViTinh donViTinh)
        {
            if (ModelState.IsValid)
            {
                if(await _context.donViTinhs.FirstOrDefaultAsync(dvt => dvt.TenDvt == donViTinh.TenDvt) != null)
                {
                    TempData["thongbao"] = "Error Tên đơn vị tính bị trùng";
                    return View(donViTinh);
                }
                _context.Add(donViTinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            TempData["thongbao"] = "Error Chưa nhập đủ dữ liệu";
            return View(donViTinh);
        }

        // GET: DonViTinhs/DonViTinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donViTinh = await _context.donViTinhs.FindAsync(id);
            if (donViTinh == null)
            {
                return NotFound();
            }
            return View(donViTinh);
        }

        // POST: DonViTinhs/DonViTinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MaDvt,TenDvt")] DonViTinh donViTinh)
        {

            if (ModelState.IsValid)
            {
                if(await _context.donViTinhs
                    .FirstOrDefaultAsync(dvt => dvt.TenDvt == donViTinh.TenDvt && dvt.MaDvt != donViTinh.MaDvt) != null)
                {
                    TempData["Thongbao"] = $"Error Tên đơn vị tính bị trùng";
                    return View(donViTinh);
                }
                try
                {
                    _context.Update(donViTinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonViTinhExists(donViTinh.MaDvt))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Thongbao"] = $"Bạn vừa sửa thành công đơn vị tính có mã {donViTinh.MaDvt} thành công";
                return RedirectToAction(nameof(Index));
            }
            TempData["Thongbao"] = $"Error Chưa nhập đủ dữ liệu";
            return View(donViTinh);
        }

       

        // POST: DonViTinhs/DonViTinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var donViTinh = await _context.donViTinhs.FindAsync(id);
            if (donViTinh == null)
            {
                return NotFound();
            }
            try
            {
                _context.donViTinhs.Remove(donViTinh);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                TempData["thongbao"] = $"Error Xóa đơn vị tính thất bại";
                return RedirectToAction(nameof(Index));
            }
            TempData["thongbao"] = $"Xóa đơn vị tính thành công";
            return RedirectToAction(nameof(Index));
        }

        private bool DonViTinhExists(int id)
        {
            return _context.donViTinhs.Any(e => e.MaDvt == id);
        }
    }
}
