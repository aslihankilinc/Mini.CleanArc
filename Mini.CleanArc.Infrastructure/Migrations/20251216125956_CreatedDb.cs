using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mini.CleanArc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DueDate = table.Column<string>(type: "TEXT", nullable: false),
                    AssignedUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "ahmet.yilmaz@example.com", "Ahmet Yılmaz", "Admin" },
                    { 2, "ayse.demir@example.com", "Ayşe Demir", "User" },
                    { 3, "mehmet.kaya@example.com", "Mehmet Kaya", "User" },
                    { 4, "elif.sahin@example.com", "Elif Şahin", "User" },
                    { 5, "can.oz@example.com", "Can Öz", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssignedUserId", "Description", "DueDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Haftalık ekip toplantısı için sunum hazırla", "2025-12-20", "Pending", "Toplantı hazırlığı" },
                    { 2, 5, "Finans raporunu yöneticilere gönder", "2025-12-18", "InProgress", "Rapor gönderimi" },
                    { 3, 4, "Yeni arayüzü test et ve geri bildirim yaz", "2025-12-15", "Completed", "Kullanıcı testi" },
                    { 4, 1, "Günlük yedekleme işlemini kontrol et", "2025-12-17", "Pending", "Veritabanı yedeği" },
                    { 5, 3, "Yeni ürün tanıtımı için e-posta içeriği oluştur", "2025-12-22", "InProgress", "E-posta kampanyası" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedUserId",
                table: "Tasks",
                column: "AssignedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
