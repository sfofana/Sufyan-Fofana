using Microsoft.EntityFrameworkCore.Migrations;

namespace JS.Fofana_Bank_V2._3_Backend.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    amount = table.Column<double>(nullable: false),
                    user = table.Column<int>(nullable: false),
                    Userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.id);
                    table.ForeignKey(
                        name: "FK_Account_User_Userid",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "id", "Userid", "amount", "name", "user" },
                values: new object[,]
                {
                    { 1001, null, 16654.119999999999, "checking", 1 },
                    { 1002, null, 67852.119999999995, "saving", 1 },
                    { 1003, null, 3537.25, "checking", 1 },
                    { 1004, null, 7165.1199999999999, "saving", 1 },
                    { 1005, null, 101010.00999999999, "checking", 2 },
                    { 1006, null, 1111.0999999999999, "saving", 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "email", "firstname", "lastname", "password" },
                values: new object[,]
                {
                    { 1, "master@gmail.com", "Amir", "Kamara", "demo" },
                    { 2, "system@gmail.com", "System", "Admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Userid",
                table: "Account",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
