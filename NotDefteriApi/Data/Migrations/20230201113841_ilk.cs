using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotDefteriApi.Data.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegistirmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notlar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notlar",
                columns: new[] { "Id", "Baslik", "DegistirmeZamani", "Icerik", "OlusturmaZamani" },
                values: new object[] { 1, "Alınacaklar", new DateTime(2023, 2, 1, 14, 38, 41, 16, DateTimeKind.Local).AddTicks(445), "1. Bot\n2. Kot", new DateTime(2023, 2, 1, 14, 38, 41, 16, DateTimeKind.Local).AddTicks(433) });

            migrationBuilder.InsertData(
                table: "Notlar",
                columns: new[] { "Id", "Baslik", "DegistirmeZamani", "Icerik", "OlusturmaZamani" },
                values: new object[] { 2, "Görevler", new DateTime(2023, 2, 1, 14, 38, 41, 16, DateTimeKind.Local).AddTicks(449), "1. Ye\n2. Dua et\n3. Sev", new DateTime(2023, 2, 1, 14, 38, 41, 16, DateTimeKind.Local).AddTicks(448) });

            migrationBuilder.InsertData(
                table: "Notlar",
                columns: new[] { "Id", "Baslik", "DegistirmeZamani", "Icerik", "OlusturmaZamani" },
                values: new object[] { 3, "Gez & Gör", new DateTime(2023, 2, 1, 14, 38, 41, 16, DateTimeKind.Local).AddTicks(450), "1. Muş\n2. Van\n3. Of", new DateTime(2023, 2, 1, 14, 38, 41, 16, DateTimeKind.Local).AddTicks(450) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notlar");
        }
    }
}
