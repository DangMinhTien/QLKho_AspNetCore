using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLKHO.Models;
using QLKHO.Validation;
using System.IO;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using QLKHO.Helper;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace QLKHO.Areas.SanPhams.Controllers
{
    [Area("SanPhams")]
    [Route("/[controller]/[action]")]
    [Authorize(Roles = "Admin,NhanVien")]
    public class SanPhamController : Controller
    {
        private readonly AppDbContext _context;
        public SanPhamController(AppDbContext context)
        {
            _context = context;
        }
       
        public int ITEM_PER_PAGE = 10;
        public int currentPage { get; set; }
        public int countPage { get; set; }
        
        // GET: SanPhams/SanPham
        public async Task<IActionResult> Index(int? p, string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = "";
            }
            if(p != null)
            {
                currentPage = p.Value;
            }
            int total = await _context.sanPhams
                .Where(sp => sp.TenSp.Contains(search) || sp.MaSp.ToString().Contains(search))
                .CountAsync();
            
            countPage = (int)Math.Ceiling((double)total / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPage)
                currentPage = countPage;
            List<SanPham> sanphams;
            if (total > 0)
            {
                sanphams = await _context.sanPhams
                        .Where(sp => sp.TenSp.Contains(search) || sp.MaSp.ToString().Contains(search))
                        .Skip((currentPage - 1) * ITEM_PER_PAGE)
                        .Take(ITEM_PER_PAGE).Include(s => s.DonViTinh).ToListAsync();
            }
            else
            {
                sanphams = await _context.sanPhams
                                .Where(sp => sp.TenSp.Contains(search) || sp.MaSp.ToString().Contains(search))
                                .Include(s => s.DonViTinh).ToListAsync();
            }
            ViewData["current"] = currentPage;
            ViewData["countpage"] = countPage;
            ViewData["search"] = search;
            return View(sanphams);
        }

        
        // GET: SanPhams/SanPham/Create
        public async Task<IActionResult> Create()
        {
            InputModel inputModel = new InputModel()
            {
                donViTinhs = new SelectList(_context.donViTinhs, "MaDvt", "TenDvt")

            };
            return View(inputModel);
        }

        // POST: SanPhams/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public class InputModel
        {
            [Required(ErrorMessage = "{0} không được để trống")]
            [DisplayName("Tên sản phẩm")]
            [StringLength(500, ErrorMessage = "{0} phải có độ dài nhỏ hơn {1} kí tự")]
            public string TenSp { get; set; }
            [Required(ErrorMessage = "{0} không được để trống")]
            [DisplayName("Giá bán")]
            [Range(0, double.MaxValue, ErrorMessage = "{0} nên có giá có giá trị từ {1} đến {2}")]
            [DataType(DataType.Currency, ErrorMessage = "{0} phải là số")]
            public decimal GiaBan { get; set; }
            [Required(ErrorMessage = "{0} không được để trống")]
            [DisplayName("Số lượng có")]
            [Range(0, int.MaxValue, ErrorMessage = "{0} nên có giá có giá trị từ {1} đến {2}")]
            public int SoLuong { get; set; }

            [Required(ErrorMessage = "Chọn file upload")]
            [DataType(DataType.Upload)]
            [DisplayName("File UpLoad")]
            [ChkFileExtension(Extensions = "jpg,png,jpeg,gif")]
            public IFormFile FileUpLoader { get; set; }
            [Required(ErrorMessage = "{0} Đơn vị tính không được để trống")]
            [DisplayName("Đơn vị tính")]
            public int MaDvt { get; set; }
            public SelectList donViTinhs { get; set; }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenSp,GiaBan,SoLuong,FileUpLoader,MaDvt")]InputModel input)
        {
            if (ModelState.IsValid)
            {
               if(input.FileUpLoader == null)
               {
                    TempData["thongbao"] = $"Error Tạo sản phẩm thất bại do file upload rỗng";
                    return View(input);
               }
                var file1 = Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                                     + Path.GetExtension(input.FileUpLoader.FileName);

                var file = Path.Combine("wwwroot", "Upload", "PhotoSanPham", file1);
                using (var filestream = new FileStream(file, FileMode.Create))
                {
                    await input.FileUpLoader.CopyToAsync(filestream);
                }
                SanPham sanPham = new SanPham()
                {
                    TenSp = input.TenSp,
                    GiaBan = input.GiaBan,
                    SoLuongCo = input.SoLuong,
                    Photo = file1,
                    MaDvt = input.MaDvt,
                };
                
                try
                {
                    _context.Add(sanPham);
                    await _context.SaveChangesAsync();
                    TempData["thongbao"] = $"Bạn vừa tạo thành công sản phẩm có tên {sanPham.TenSp}";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.MaSp))
                    {
                        return NotFound("Tạo sản phẩm thất bại");
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            TempData["thongbao"] = $"Error Tạo sản phẩm thất bại";
            input.donViTinhs = new SelectList(_context.donViTinhs, "MaDvt", "TenDvt",input.MaDvt);
            return View(input);
        }

        // GET: SanPhams/SanPham/Edit/5
        public class InputEdit
        {
            public int MaSp { get; set; }
            [Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(500, ErrorMessage = "{0} có độ dài nhỏ hơn {1} kí tự")]
            [DisplayName("Tên sản phẩm")]
            public string TenSp { get; set; }
            [Required(ErrorMessage = "{0} không được để trống")]
            [Range(0, double.MaxValue,ErrorMessage = "{0} phải có giá trị lớn hơn {1}")]
            [DisplayName("Giá bán")]
            [DataType(DataType.Currency, ErrorMessage = "{0} phải là số")]
            public decimal GiaBan { get; set; }
            [Required(ErrorMessage = "{0} không được để trống")]
            [Range(0, int.MaxValue, ErrorMessage = "{0} phải có giá trị lớn hơn {1}")]
            [DisplayName("Số lượng")]
            public int SoLuong { get; set; }
            public string Photo { get; set; }

            [DataType(DataType.Upload)]
            [DisplayName("File UpLoad")]
            [ChkFileExtension(Extensions = "jpg,png,jpeg,gif")]
            public IFormFile FileUpLoader { get; set; }
            [DisplayName("Đơn vị tính")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public int MaDvt { get; set; }
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            InputEdit inputEdit = new InputEdit()
            {
                MaSp = sanPham.MaSp,
                TenSp= sanPham.TenSp,
                GiaBan= sanPham.GiaBan,
                SoLuong = sanPham.SoLuongCo,
                Photo= sanPham.Photo,
                MaDvt = (int)(sanPham.MaDvt)
            };
            ViewData["MaDvt"] = new SelectList(_context.donViTinhs, "MaDvt", "TenDvt",sanPham.MaDvt);
            return View(inputEdit);
        }

        // POST: SanPhams/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MaSp,TenSp,GiaBan,SoLuong,FileUpLoader,MaDvt,Photo")] InputEdit inputEdit)
        {
            SanPham sanpham = _context.sanPhams.SingleOrDefault(sp => sp.MaSp == inputEdit.MaSp);
            if (sanpham == null)
            {
                return NotFound("sửa thất bại dó hệ thống không tìm thấy sản phẩm");
            }
            if (ModelState.IsValid)
            {
                if(inputEdit.FileUpLoader != null)
                {
                    var file1 = Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                                    + Path.GetExtension(inputEdit.FileUpLoader.FileName);

                    var file = Path.Combine("wwwroot", "Upload", "PhotoSanPham", file1);
                    using (var filestream = new FileStream(file, FileMode.Create))
                    {
                        await inputEdit.FileUpLoader.CopyToAsync(filestream);
                    }
                    sanpham.Photo = file1;
                }
                sanpham.TenSp = inputEdit.TenSp;
                sanpham.GiaBan= inputEdit.GiaBan;
                sanpham.SoLuongCo = inputEdit.SoLuong;
                sanpham.MaDvt = inputEdit.MaDvt;
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                    TempData["thongbao"] = $"Bạn vừa sửa thành công sản phẩm có mã {sanpham.MaSp}";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanpham.MaSp))
                    {
                        return NotFound("Không sửa được");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDvt"] = new SelectList(_context.donViTinhs, "MaDvt", "TenDvt", sanpham.MaDvt);
            TempData["thongbao"] = $"Error Sửa sản phẩm thất bại";
            return View(inputEdit);
        }

        // GET: SanPhams/SanPham/Delete/5
        
        

        // POST: SanPhams/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {   if(id == null)
            {
                return NotFound();
            }
            var sanPham = await _context.sanPhams.FindAsync(id);
            if (sanPham == null)
            {
                TempData["thongbao"] = $"Error Xóa thất bại do không tìm thấy sản phẩm";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.sanPhams.Remove(sanPham);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                TempData["thongbao"] = $"Error Xóa thất bại do sản phẩm này đang tồn tại trong phiếu xuất hoặc phiếu nhập";
                return RedirectToAction(nameof(Index));
            }
            TempData["thongbao"] = $"Bạn vừa Xóa thành công sản phẩm có mã {id}";
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.sanPhams.Any(e => e.MaSp == id);
        }
    }
}
