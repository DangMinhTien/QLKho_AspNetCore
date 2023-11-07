using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLKHO.Models;

namespace QLKHO.Areas.NhaCungCaps.Controllers
{
    [Area("NhaCungCaps")]
    [Route("/[controller]/[action]")]
    [Authorize(Roles = "Admin,NhanVien")]
    public class NhaCungCapController : Controller
    {
        private readonly AppDbContext _context;

        public NhaCungCapController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NhaCungCaps/NhaCungCap
        // Các biến dùng cho phân trang
        public int ITEM_PER_PAGE = 10;
        public int currentPage { get; set; }
        public int countPage { get; set; }

        public async Task<IActionResult> Index(int? p, string search)
        {
            if (p != null)
            {
                currentPage = p.Value;
            }
            if(string.IsNullOrEmpty(search))
            {
                search = "";
            }
            int total = await _context.nhaCungCaps.Where(ncc => ncc.TenNcc.Contains(search)).CountAsync();

            countPage = (int)Math.Ceiling((double)total / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPage)
                currentPage = countPage;

            List<QLKHO.Models.NhaCungCap> nhaCungCaps;
            if(total > 0)
            {
                nhaCungCaps = await _context.nhaCungCaps
                            .Where(ncc => ncc.TenNcc.Contains(search))
                            .Skip((currentPage - 1) * ITEM_PER_PAGE)
                            .Take(ITEM_PER_PAGE).ToListAsync();

            }
            else
            {
                nhaCungCaps = await _context.nhaCungCaps
                                    .Where(ncc => ncc.TenNcc.Contains(search))
                                    .ToListAsync();
            }
            ViewData["current"] = currentPage;
            ViewData["countpage"] = countPage;
            ViewData["search"] = search;
            return View(nhaCungCaps);
        }

        // GET: NhaCungCaps/NhaCungCap/Details/5
        public class InputModel
        {
            public NhaCungCap nhacungcap { get; set; }
            public List<SanPham> sanPhams { get; set; }
            public int MaNcc { get; set; }
            public int MaSp { get; set; }
            [Required]
            [Range(0, double.MaxValue, ErrorMessage = "{0} phải nhập các giá trị từ {1} đến {2}")]
            [DisplayName("Giá Nhập")]
            public decimal GiaNhap { get; set; }
        };
        public async Task<IActionResult> Details(int? id, int? p)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nhaCungCap = await _context.nhaCungCaps
                .FirstOrDefaultAsync(m => m.MaNcc == id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }
            //start phân trang cho sản phẩm
            if (p != null)
            {
                currentPage = p.Value;
            }
            int total = await _context.chiTietNhaCungCaps
                                                .Where(c => c.MaNcc == id).CountAsync();

            countPage = (int)Math.Ceiling((double)total / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPage)
                currentPage = countPage;
            List<ChiTietNhaCungCap> chiTietNhaCungCaps;
            if (total > 0)
            {
                chiTietNhaCungCaps = await _context.chiTietNhaCungCaps
                                                    .Where(c => c.MaNcc == id).Skip((currentPage - 1) * ITEM_PER_PAGE)
                                                    .Take(ITEM_PER_PAGE).ToListAsync();
            }
            else
            {
               chiTietNhaCungCaps = await _context.chiTietNhaCungCaps
                                                    .Where(c => c.MaNcc == id).ToListAsync();
            }
            ViewData["current"] = currentPage;
            ViewData["countpage"] = countPage;
            //end phân trang cho sp
            List<SanPham> sanPhams = new List<SanPham>();
            foreach(var ct in chiTietNhaCungCaps)
            {
                var sanpham = _context.sanPhams.SingleOrDefault(sp => sp.MaSp== ct.MaSp);
                if (sanpham != null)
                    sanPhams.Add(sanpham);
            }
            InputModel inputModel = new InputModel()
            {
                nhacungcap = nhaCungCap,
                sanPhams= sanPhams
            };
            return View(inputModel);
        }
        public async Task<IActionResult> AddSanPham(int? id,[Bind] string? search)
        {
            if(id == null)
            {
                return NotFound("Không tồn tại mã nhà cung cấp");
            }
            NhaCungCap nhaCungCap = _context.nhaCungCaps.SingleOrDefault(ncc => ncc.MaNcc == id);
            if(nhaCungCap == null)
            {
                return NotFound("Không tồn tại nhà cung cấp");
            }
            InputModel inputModel = new InputModel()
            {
                MaNcc = nhaCungCap.MaNcc,
                nhacungcap = nhaCungCap,
                sanPhams = await _context.sanPhams.Include(s => s.DonViTinh).ToListAsync()
            };
            if(search != null)
            {
                inputModel.sanPhams = await _context.sanPhams
                    .Where(sp => sp.TenSp.Contains(search))
                    .Include(s => s.DonViTinh).ToListAsync();
            }
            ViewData["search"] = search;
            return View(inputModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSanPham([Bind("MaNcc,MaSp,GiaNhap")]InputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                ChiTietNhaCungCap chiTietNhaCungCap = _context.chiTietNhaCungCaps
                                    .SingleOrDefault(c => c.MaNcc == inputModel.MaNcc && c.MaSp == inputModel.MaSp);
                if(chiTietNhaCungCap != null)
                {
                    TempData["thongbao"] = $"Error Sản phẩm có mã {chiTietNhaCungCap.MaSp} đã có trong nhà cung cấp co mã" +
                        $"{chiTietNhaCungCap.MaNcc}";
                    return RedirectToAction(nameof(AddSanPham), new { id = inputModel.MaNcc });
                }
                ChiTietNhaCungCap ctncc = new ChiTietNhaCungCap()
                {
                    MaNcc= inputModel.MaNcc,
                    MaSp= inputModel.MaSp,
                    GiaNhap = inputModel.GiaNhap,
                };
                try
                {
                    _context.Add(ctncc);
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    TempData["thongbao"] = "Error Thêm sản phẩm vào nhà cung cấp bị thất bại";
                    return RedirectToAction(nameof(AddSanPham), new { id = inputModel.MaNcc });
                }
                TempData["thongbao"] = "Thêm sản phẩm vào nhà cung cấp thành công";
                return RedirectToAction(nameof(Details), new { id = inputModel.MaNcc });
            }
            TempData["thongbao"] = "Error Thêm sản phẩm vào nhà cung cấp bị thất bại";
            return RedirectToAction(nameof(AddSanPham), new {id = inputModel.MaNcc});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSanPhanInNCC([Bind("MaNcc,MaSp,GiaNhap")] InputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                ChiTietNhaCungCap ctncc = await _context.chiTietNhaCungCaps
                                                .SingleOrDefaultAsync(ct => ct.MaNcc == inputModel.MaNcc && ct.MaSp == inputModel.MaSp);
                if(ctncc == null)
                {
                    return NotFound("Không tồn tại chi tiết nhà cung cấp");
                }
                try
                {
                    ctncc.GiaNhap = inputModel.GiaNhap;
                    _context.chiTietNhaCungCaps.Update(ctncc);
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {

                    TempData["thongbao"] = "Error Sửa sản phẩm trong nhà cung cấp bị thất bại";
                    return RedirectToAction(nameof(Details), new { id = inputModel.MaNcc });
                }
                TempData["thongbao"] = $"Sửa sản phẩm có mã {inputModel.MaSp} trong nhà cung cấp thành công";
                return RedirectToAction(nameof(Details), new { id = inputModel.MaNcc });
            }
            TempData["thongbao"] = "Error Sửa sản phẩm trong nhà cung cấp bị thất bại";
            return RedirectToAction(nameof(Details), new { id = inputModel.MaNcc });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSanPhanInNCC([Bind("MaNcc,MaSp")] InputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                ChiTietNhaCungCap ctncc = await _context.chiTietNhaCungCaps
                                                .SingleOrDefaultAsync(ct => ct.MaNcc == inputModel.MaNcc && ct.MaSp == inputModel.MaSp);
                if (ctncc == null)
                {
                    return NotFound("Không tồn tại chi tiết nhà cung cấp");
                }
                try
                {
                    _context.chiTietNhaCungCaps.Remove(ctncc);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    TempData["thongbao"] = "Error Xóa sản phẩm trong nhà cung cấp bị thất bại";
                    return RedirectToAction(nameof(Details), new { id = inputModel.MaNcc });
                }
                TempData["thongbao"] = $"Xóa phẩm có mã {inputModel.MaSp} trong nhà cung cấp thành công";
                return RedirectToAction(nameof(Details), new { id = inputModel.MaNcc });
            }
            TempData["thongbao"] = "Error Xóa sản phẩm trong nhà cung cấp bị thất bại";
            return RedirectToAction(nameof(Details), new { id = inputModel.MaNcc });
        }
        // GET: NhaCungCaps/NhaCungCap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaCungCaps/NhaCungCap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNcc,TenNcc,Email,Sdt")] NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                if(await _context.nhaCungCaps.FirstOrDefaultAsync(ncc => ncc.Email == nhaCungCap.Email) != null)
                {
                    TempData["thongbao"] = $"Error Email trên đã thuộc về nhà cung cấp khác";
                    return View(nhaCungCap);
                }
                if (await _context.nhaCungCaps.FirstOrDefaultAsync(ncc => ncc.Sdt == nhaCungCap.Sdt) != null)
                {
                    TempData["thongbao"] = $"Error Số điện thoại trên đã thuộc về nhà cung cấp khác";
                    return View(nhaCungCap);
                }
                try
                {
                    _context.Add(nhaCungCap);
                    await _context.SaveChangesAsync();
                    TempData["thongbao"] = $"Bạn vừa tạo thành công nhà cung cấp có mã {nhaCungCap.MaNcc}";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["thongbao"] = $"Error tạo nhà cung cấp thất bại";
                    return View(nhaCungCap);
                }
               
            }
            TempData["thongbao"] = $"Error tạo nhà cung cấp thất bại";
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/NhaCungCap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCap = await _context.nhaCungCaps.FindAsync(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }
            return View(nhaCungCap);
        }

        // POST: NhaCungCaps/NhaCungCap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MaNcc,TenNcc,Email,Sdt")] NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                if (await _context.nhaCungCaps
                    .FirstOrDefaultAsync(ncc => ncc.Email == nhaCungCap.Email && ncc.MaNcc != nhaCungCap.MaNcc) != null)
                {
                    TempData["thongbao"] = $"Error Email trên đã thuộc về nhà cung cấp khác";
                    return View(nhaCungCap);
                }
                if (await _context.nhaCungCaps
                    .FirstOrDefaultAsync(ncc => ncc.Sdt == nhaCungCap.Sdt && ncc.MaNcc != nhaCungCap.MaNcc) != null)
                {
                    TempData["thongbao"] = $"Error Số điện thoại trên đã thuộc về nhà cung cấp khác";
                    return View(nhaCungCap);
                }
                try
                {
                    _context.Update(nhaCungCap);
                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapExists(nhaCungCap.MaNcc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["thongbao"] = "Sửa nhà cung cấp thất bại";
                        return View(nhaCungCap);
                    }
                } 
                TempData["thongbao"] = "Bạn vừa sửa thành công nhà cung cấp";
                return RedirectToAction(nameof(Index));
            }
            TempData["thongbao"] = "Sửa nhà cung cấp thất bại";
            return View(nhaCungCap);
        }

        

        // POST: NhaCungCaps/NhaCungCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaCungCap = await _context.nhaCungCaps.FindAsync(id);
            if(nhaCungCap == null)
            {
                return NotFound("Không tồn tại nhà cung cấp");
            }
            try
            {
                _context.nhaCungCaps.Remove(nhaCungCap);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                TempData["thongbao"] = "Error Xóa nhà cung cấp thất bại";
                return View(nhaCungCap);
            }
            TempData["thongbao"] = "Bạn vừa xóa thành công nhà cung cấp";
            return RedirectToAction(nameof(Index));
        }

        private bool NhaCungCapExists(int id)
        {
            return _context.nhaCungCaps.Any(e => e.MaNcc == id);
        }
    }
}
