using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QLKHO.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using SelectPdf;
using System.Globalization;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;

namespace QLKHO.Areas.PhieuNhaps.Controllers
{
    [Area("PhieuNhaps")]
    [Route("/[controller]/[action]/")]
    [Authorize(Roles = "Admin,NhanVien")]
    public class PhieuNhapController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;
        public PhieuNhapController(AppDbContext context, 
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public int ITEM_PER_PAGE = 10;
        public int currentPage { get; set; }
        public int countPage { get; set; }

        public async Task<IActionResult> Index(int? p, string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = "";
            }
            if (p != null)
            {
                currentPage = p.Value;
            }
            int total = await _context.phieuNhaps
                                        .Where(pn => pn.MaPN.ToString().Contains(search))
                                        .CountAsync();

            countPage = (int)Math.Ceiling((double)total / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPage)
                currentPage = countPage;

            List<QLKHO.Models.PhieuNhap> phieuNhaps;
            if(total > 0)
            {
                phieuNhaps = await _context.phieuNhaps
                            .Where(pn => pn.MaPN.ToString().Contains(search))
                            .Skip((currentPage - 1) * ITEM_PER_PAGE)
                            .Take(ITEM_PER_PAGE).ToListAsync();

            }
            else
            {
                phieuNhaps = await _context.phieuNhaps
                            .Where(pn => pn.MaPN.ToString().Contains(search))
                            .ToListAsync();
            }
            ViewData["current"] = currentPage;
            ViewData["countpage"] = countPage;
            ViewData["search"] = search;
            return View(phieuNhaps);
        }
        public class InputModel
        {
            public NhaCungCap nhaCungCap { get; set; }
            public List<SanPham> sanPhams { get; set; }
            public SelectList NhaCungCaps { get; set; }
            public decimal[] DonGia { get; set; }
            public int[] SoLuong { get; set; }
            public int[] MaSp { get; set; }
            [Required(ErrorMessage = "Bạn phải nhập ngày lập phiếu")]
            [DisplayName("Ngày lập phiếu")]
            [DataType(DataType.Date)]
            public DateTime NgayLap { get; set; } = DateTime.Now;
            [Required(ErrorMessage = "Nhà cung cấp không được để trống")]
            public int MaNcc { get; set; }

        }

        [BindProperty(SupportsGet = true,Name = "MaNcc")]
        public int? id { get; set; }
        public async Task<IActionResult> Create()
        {
            InputModel inputModel;
            if (id == null)
            {
                inputModel = new InputModel()
                {
                    NhaCungCaps = new SelectList(_context.nhaCungCaps, "MaNcc","TenNcc")
                };
            }
            else
            {
                NhaCungCap ncc = await _context.nhaCungCaps.SingleOrDefaultAsync(cc => cc.MaNcc == id);
                if(ncc == null)
                {
                    return NotFound("Không tồn tạo nhà cung cấp này");
                }
                List<ChiTietNhaCungCap> chiTietNhaCungCaps = await _context.chiTietNhaCungCaps
                                                .Where(c => c.MaNcc == id).ToListAsync();
                List<SanPham> sanPhams = new List<SanPham>();
                foreach (var ct in chiTietNhaCungCaps)
                {
                    var sanpham = _context.sanPhams.SingleOrDefault(sp => sp.MaSp == ct.MaSp);
                    sanPhams.Add(sanpham);
                }
                inputModel = new InputModel()
                {
                    nhaCungCap = ncc,
                    NhaCungCaps = new SelectList(_context.nhaCungCaps, "MaNcc", "TenNcc", id),
                    sanPhams = sanPhams.OrderBy(sp => sp.TenSp).ToList()
                };
            }
            return View(inputModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNcc,DonGia,MaSp,SoLuong,NgayLap")]InputModel inputModel)
        {
            if(inputModel.MaSp == null || inputModel.SoLuong == null || inputModel.DonGia == null)
            {
                TempData["thongbao"] = $"Error Tạo phiếu thất bại do chưa nhập đủ dữ liệu";
                return RedirectToAction(nameof(Create), new { MaNcc = inputModel.MaNcc });
            }
            if(inputModel.MaSp.Count() != inputModel.SoLuong.Count() || inputModel.MaSp.Count() != inputModel.DonGia.Count())
            {
                TempData["thongbao"] = $"Error Tạo phiếu thất bại do chưa nhật đủ dữ liệu";
                return RedirectToAction(nameof(Create), new {MaNcc = inputModel.MaNcc});
            }
            int dem = 0;
            for(int i = 0; i < inputModel.MaSp.Count(); i++)
            {
                if (inputModel.DonGia[i] < 0 || inputModel.SoLuong[i] < 1)
                    dem++;
            }
            if(dem > 0)
            {
                TempData["thongbao"] = $"Error Tạo phiếu thất bại do nhập sai dữ liệu";
                return RedirectToAction(nameof(Create), new { MaNcc = inputModel.MaNcc });
            }
            int soluong = 0;
            decimal tongtien = 0;
            for (int i = 0; i < inputModel.MaSp.Count(); i++)
            {
                soluong += inputModel.SoLuong[i];
                tongtien += inputModel.SoLuong[i] * inputModel.DonGia[i];
            }
            PhieuNhap phieunhap;
            try
            {
                phieunhap = new PhieuNhap()
                {
                    NgayLap = inputModel.NgayLap,
                    TongSoLuong = soluong,
                    TongTien= tongtien,
                    UserId = _userManager.GetUserId(User),
                    MaNcc = inputModel.MaNcc
                };
                _context.Add(phieunhap);
                await _context.SaveChangesAsync();
                int MaPN = phieunhap.MaPN;
                for (int i = 0; i < inputModel.MaSp.Count(); i++)
                {
                    ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap()
                    {
                        MaPN = MaPN,
                        MaSp = inputModel.MaSp[i],
                        SoLuong = inputModel.SoLuong[i],
                        DonGia = inputModel.DonGia[i],
                    };
                    _context.Add(ctpn);
                    SanPham sanpham = _context.sanPhams.SingleOrDefault(sp => sp.MaSp == inputModel.MaSp[i]);
                    if(sanpham != null)
                    {
                        sanpham.SoLuongCo += inputModel.SoLuong[i];
                        _context.Update(sanpham);
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                TempData["thongbao"] = $"Error Tạo phiếu thất bại";
                return RedirectToAction(nameof(Create), new {MaNcc = inputModel.MaNcc});
            }
            TempData["thongbao"] = $"Tạo phiếu nhập có mã {phieunhap.MaPN} thành công";
            return RedirectToAction(nameof(Index));
        }
        public class InputDetails
        {
            public PhieuNhap phieuNhap { get; set; }
            public AppUser user { get; set; }
            public NhaCungCap nhaCungCap { get; set; }
            public int MaPN { get; set; }
            public List<SP_CTPN> sp_ctpn { get; set; }
            [DisplayName("Địa chỉ Email")]
            [Required(ErrorMessage = "{0} không được để trống")]
            [EmailAddress(ErrorMessage = "{0} phải là Email")]
            public string Email { get; set; }
        }
        public class SP_CTPN
        {
            public int MaSp { get; set; }
            public string TenSp { get; set; }
            public string Photo { get; set; }
            public int Soluong { get; set; }
            public decimal DonGia { get; set; }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
            { 
                return NotFound();
            }
            PhieuNhap pn = await _context.phieuNhaps.SingleOrDefaultAsync(p => p.MaPN == id);
            if (pn == null)
            {
                return NotFound("Phiếu Nhập không tồn tại");
            }
            var sanpham_phieunhap = from sp in _context.sanPhams
                                    join ct in _context.chiTietPhieuNhaps
                                    on sp.MaSp equals ct.MaSp
                                    where ct.MaPN == id
                                    select new SP_CTPN
                                    {
                                        MaSp = sp.MaSp,
                                        TenSp = sp.TenSp,
                                        Photo = sp.Photo,
                                        Soluong = ct.SoLuong,
                                        DonGia = ct.DonGia
                                    };
            
            InputDetails inputDetails = new InputDetails()
            {
                phieuNhap = pn,
                MaPN = pn.MaPN,
                user = await _userManager.FindByIdAsync(pn.UserId),
                nhaCungCap = await _context.nhaCungCaps.SingleOrDefaultAsync(nc => nc.MaNcc == pn.MaNcc),
                sp_ctpn = sanpham_phieunhap.ToList()
            };
            return View(inputDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound("Không xóa được do không tìm thấy mã phiếu");
            }
            PhieuNhap phieunhap = _context.phieuNhaps.SingleOrDefault(pn => pn.MaPN == id);
            if(phieunhap == null)
            {
                return NotFound($"Không tìm thấy phiếu nhập có mã {id}");
            }
            try
            {
                List<ChiTietPhieuNhap> ctpn = await _context.chiTietPhieuNhaps.Where(ct => ct.MaPN == phieunhap.MaPN)
                                                                                .ToListAsync();
                foreach(var item in ctpn)
                {
                    SanPham sp = _context.sanPhams.SingleOrDefault(s => s.MaSp == item.MaSp);
                    if(sp != null)
                    {
                        sp.SoLuongCo = sp.SoLuongCo - item.SoLuong;
                        _context.sanPhams.Update(sp);
                    }
                }
                await _context.SaveChangesAsync();
                _context.phieuNhaps.Remove(phieunhap);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                TempData["thongbao"] = "Error Xóa thất bại";
                return RedirectToAction(nameof(Details), new {id = id});
            }
            TempData["thongbao"] = $"Xóa Phiếu nhập có mã {phieunhap.MaPN} thành công";
            return RedirectToAction(nameof(Index));
        }
        public async Task<string> generateHtml(int id)
        {
            
            PhieuNhap pn = await _context.phieuNhaps.SingleOrDefaultAsync(p => p.MaPN == id);
            var sanpham_phieunhap = from sp in _context.sanPhams
                                    join ct in _context.chiTietPhieuNhaps
                                    on sp.MaSp equals ct.MaSp
                                    where ct.MaPN == id
                                    select new SP_CTPN
                                    {
                                        MaSp = sp.MaSp,
                                        TenSp = sp.TenSp,
                                        Photo = sp.Photo,
                                        Soluong = ct.SoLuong,
                                        DonGia = ct.DonGia
                                    };

            InputDetails inputDetails = new InputDetails()
            {
                phieuNhap = pn,
                MaPN = pn.MaPN,
                user = await _userManager.FindByIdAsync(pn.UserId),
                nhaCungCap = await _context.nhaCungCaps.SingleOrDefaultAsync(nc => nc.MaNcc == pn.MaNcc),
                sp_ctpn = sanpham_phieunhap.ToList()
            };
            string tbody = "";
            int i = 1;
            foreach(var item in inputDetails.sp_ctpn)
            {
                tbody += 
                    "<tr>" +
                        $"<td>{i++}</td> " +
                        $"<td>{item.MaSp}</td> " +
                        $"<td>{item.TenSp}</td> " +
                        $"<td>{item.Soluong}</td>" +
                        $"<td>{item.DonGia.ToString("C", new CultureInfo("vi-VN"))}</td>" +
                    "</tr>";
            }
            string html = "" +
                "<h2 style=\"text-align: center;\">Phiếu Nhập</h2>" +
                "<div>" +
                    "<div style=\"display: flex; width: 80%; margin: auto;\">" +
                        $"<p style=\"width: 33%;\">Mã Phiếu: {inputDetails.MaPN}.</p>" +
                        $"<p style=\"width: 33%;\">Ngày Lập: {String.Format("{0:dd/MM/yyyy}",inputDetails.phieuNhap.NgayLap)}.</p>" +
                        $"<p style=\"width: 33%;\">Tổng số lượng: {inputDetails.phieuNhap.TongSoLuong}.</p>" +
                    "</div>" +
                    "<div style=\"display: flex; width: 80%; margin: auto;\">" +
                        $"<p style=\"width: 33%;\">Người Lập: {inputDetails.user.FullName}-{inputDetails.user.UserName}.</p>" +
                        $"<p style=\"width: 33%;\">Nhà cung cấp: {inputDetails.nhaCungCap.TenNcc}.</p>" +
                        $"<p style=\"width: 33%;\">Tổng Tiền:{inputDetails.phieuNhap.TongTien.ToString("C", new CultureInfo("vi-VN"))}.</p> " +
                    "</div>" +
                "</div>" +
                "<table style=\"width: 80%; margin: auto;\" border=\"1\"" +
                "<thead>" +
                    "<tr>" +
                        "<th>STT</th>" +
                        "<th>Mã Sản Phẩm</th> " +
                        "<th>Tên Sản Phẩm</th>" +
                        "<th>Số Lượng</th> " +
                        "<th>Đơn Giá</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>" +
                    $"{tbody}" +
                "</tbody>" +
                "</table>" +
                "<div style=\"width: 80%; margin: auto; display: flex;\">" +
                    "<div style=\"text-align: center; width: 33%;\">" +
                        "<p style=\"font-weight: bold; font-size: 16px; margin-bottom: 0px;\">Kế Toán Trưởng</p>" +
                        "<p style=\"margin-top: 5px;\">(Ký và ghi rõ họ tên)</p>" +
                    "</div>" +
                    "<div style=\"text-align: center; width: 33%;\">" +
                        "<p style=\"font-weight: bold; font-size: 16px; margin-bottom: 0px;\">Người Lập Đơn</p>" +
                        "<p style=\"margin-top: 5px;\">(Ký tên)</p>" +
                        $"<p style=\"margin-top: 70px;\">{inputDetails.user.FullName}</p>" +
                    "</div>" +
                    "<div style=\"text-align: center; width: 33%;\">" +
                        "<p style=\"font-weight: bold; font-size: 16px; margin-bottom: 0px;\">Giám Đốc Kho</p>" +
                        "<p style=\"margin-top: 5px;\">(Ký và ghi rõ họ tên)</p>" +
                    "</div>" +
                "</div>";
            return html;
        }
        public async Task<IActionResult> GeneratePdf(int id)
        {
            string html = await generateHtml(id);
            HtmlToPdf oHtmlToPdf = new HtmlToPdf();
            PdfDocument oPdfDocument = oHtmlToPdf.ConvertHtmlString(html);
            byte[] pdf = oPdfDocument.Save();
            oPdfDocument.Close();
            return File(
                pdf,
                "application/pdf",
                $"PhieuNhap{id}.pdf"
                );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendPhieu(int id,[Bind("Email")]InputDetails inputDetails)
        {
            string html = await generateHtml(id);
            try
            {
                await _emailSender.SendEmailAsync(inputDetails.Email, $"Phiếu Nhập mã {id}",html);
            }
            catch (Exception ex)
            {
                TempData["thongbao"] = "Error Gửi không thành công";
                return RedirectToAction(nameof(Details), new {id = id});
            }
            TempData["thongbao"] = "Gửi phiếu nhập thành công";
            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
