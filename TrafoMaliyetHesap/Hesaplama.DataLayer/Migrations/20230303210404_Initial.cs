using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hesaplama.DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hesaplamalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Guc = table.Column<double>(type: "float", nullable: false),
                    AGgerilim = table.Column<double>(type: "float", nullable: false),
                    YGgerilim = table.Column<double>(type: "float", nullable: false),
                    KazanGenislik = table.Column<double>(type: "float", nullable: false),
                    KazanUzunluk = table.Column<double>(type: "float", nullable: false),
                    KazanYukseklik = table.Column<double>(type: "float", nullable: false),
                    Maliyet = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaplamalar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hesaplamalar");
        }
    }
}
