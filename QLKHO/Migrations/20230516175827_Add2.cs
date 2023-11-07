using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLKHO.Migrations
{
    public partial class Add2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "donViTinhs",
                columns: table => new
                {
                    MaDvt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDvt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donViTinhs", x => x.MaDvt);
                });

            migrationBuilder.CreateTable(
                name: "khachHangs",
                columns: table => new
                {
                    MaKh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachHangs", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "nhaCungCaps",
                columns: table => new
                {
                    MaNcc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNcc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaCungCaps", x => x.MaNcc);
                });

            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    MaSp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSp = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuongCo = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MaDvt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.MaSp);
                    table.ForeignKey(
                        name: "FK_sanPhams_donViTinhs_MaDvt",
                        column: x => x.MaDvt,
                        principalTable: "donViTinhs",
                        principalColumn: "MaDvt",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phieuXuats",
                columns: table => new
                {
                    MaPX = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongSoLuong = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    MaKh = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuXuats", x => x.MaPX);
                    table.ForeignKey(
                        name: "FK_phieuXuats_khachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "khachHangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_phieuXuats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phieuNhaps",
                columns: table => new
                {
                    MaPN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongSoLuong = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaNcc = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuNhaps", x => x.MaPN);
                    table.ForeignKey(
                        name: "FK_phieuNhaps_nhaCungCaps_MaNcc",
                        column: x => x.MaNcc,
                        principalTable: "nhaCungCaps",
                        principalColumn: "MaNcc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_phieuNhaps_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chiTietNhaCungCaps",
                columns: table => new
                {
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    MaNcc = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietNhaCungCaps", x => new { x.MaNcc, x.MaSp });
                    table.ForeignKey(
                        name: "FK_chiTietNhaCungCaps_nhaCungCaps_MaNcc",
                        column: x => x.MaNcc,
                        principalTable: "nhaCungCaps",
                        principalColumn: "MaNcc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietNhaCungCaps_sanPhams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "sanPhams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietPhieuXuats",
                columns: table => new
                {
                    MaPX = table.Column<int>(type: "int", nullable: false),
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietPhieuXuats", x => new { x.MaPX, x.MaSp });
                    table.ForeignKey(
                        name: "FK_chiTietPhieuXuats_phieuXuats_MaPX",
                        column: x => x.MaPX,
                        principalTable: "phieuXuats",
                        principalColumn: "MaPX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietPhieuXuats_sanPhams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "sanPhams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chiTietPhieuNhaps",
                columns: table => new
                {
                    MaPN = table.Column<int>(type: "int", nullable: false),
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietPhieuNhaps", x => new { x.MaPN, x.MaSp });
                    table.ForeignKey(
                        name: "FK_chiTietPhieuNhaps_phieuNhaps_MaPN",
                        column: x => x.MaPN,
                        principalTable: "phieuNhaps",
                        principalColumn: "MaPN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietPhieuNhaps_sanPhams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "sanPhams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietNhaCungCaps_MaSp",
                table: "chiTietNhaCungCaps",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietPhieuNhaps_MaSp",
                table: "chiTietPhieuNhaps",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietPhieuXuats_MaSp",
                table: "chiTietPhieuXuats",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_phieuNhaps_MaNcc",
                table: "phieuNhaps",
                column: "MaNcc");

            migrationBuilder.CreateIndex(
                name: "IX_phieuNhaps_UserId",
                table: "phieuNhaps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuXuats_MaKh",
                table: "phieuXuats",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_phieuXuats_UserId",
                table: "phieuXuats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhams_MaDvt",
                table: "sanPhams",
                column: "MaDvt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietNhaCungCaps");

            migrationBuilder.DropTable(
                name: "chiTietPhieuNhaps");

            migrationBuilder.DropTable(
                name: "chiTietPhieuXuats");

            migrationBuilder.DropTable(
                name: "phieuNhaps");

            migrationBuilder.DropTable(
                name: "phieuXuats");

            migrationBuilder.DropTable(
                name: "sanPhams");

            migrationBuilder.DropTable(
                name: "nhaCungCaps");

            migrationBuilder.DropTable(
                name: "khachHangs");

            migrationBuilder.DropTable(
                name: "donViTinhs");
        }
    }
}
