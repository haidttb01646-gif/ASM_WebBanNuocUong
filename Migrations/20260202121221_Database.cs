using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_WebBanNuocUong.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    MaDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.MaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    MaCombo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenCombo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.MaCombo);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    MaNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Customer"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.MaNguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ChuDe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_Products_Categories_MaDanhMuc",
                        column: x => x.MaDanhMuc,
                        principalTable: "Categories",
                        principalColumn: "MaDanhMuc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    MaDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Chờ xác nhận"),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MaNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.MaDonHang);
                    table.ForeignKey(
                        name: "FK_Orders_Users_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "Users",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComboDetails",
                columns: table => new
                {
                    MaChiTietCombo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaCombo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboDetails", x => x.MaChiTietCombo);
                    table.ForeignKey(
                        name: "FK_ComboDetails_Combos_MaCombo",
                        column: x => x.MaCombo,
                        principalTable: "Combos",
                        principalColumn: "MaCombo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboDetails_Products_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "Products",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    MaChiTietDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaCombo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LoaiSanPham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.MaChiTietDonHang);
                    table.CheckConstraint("CK_ChiTietDonHang_LoaiSanPham", "(LoaiSanPham = 'SanPham' AND MaSanPham IS NOT NULL) OR (LoaiSanPham = 'Combo' AND MaCombo IS NOT NULL)");
                    table.CheckConstraint("CK_ChiTietDonHang_SanPhamOrCombo", "([MaSanPham] IS NOT NULL AND [MaCombo] IS NULL) OR ([MaSanPham] IS NULL AND [MaCombo] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Combos_MaCombo",
                        column: x => x.MaCombo,
                        principalTable: "Combos",
                        principalColumn: "MaCombo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_MaDonHang",
                        column: x => x.MaDonHang,
                        principalTable: "Orders",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "Products",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TenDanhMuc",
                table: "Categories",
                column: "TenDanhMuc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetails_MaCombo",
                table: "ComboDetails",
                column: "MaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetails_MaSanPham",
                table: "ComboDetails",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_TenCombo",
                table: "Combos",
                column: "TenCombo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MaCombo",
                table: "OrderDetails",
                column: "MaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MaDonHang",
                table: "OrderDetails",
                column: "MaDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MaSanPham",
                table: "OrderDetails",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MaNguoiDung",
                table: "Orders",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MaDanhMuc",
                table: "Products",
                column: "MaDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TenSanPham",
                table: "Products",
                column: "TenSanPham",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboDetails");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
