using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrialLoginAndRegistrationWeb.Migrations.Application
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rent_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone_Number = table.Column<int>(type: "int", nullable: false),
                    Comm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Clothes_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Clothes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Clothes_ID);
                    table.ForeignKey(
                        name: "FK_Clothes_Orders_Clothes",
                        column: x => x.Clothes,
                        principalTable: "Orders",
                        principalColumn: "Order_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_Clothes",
                table: "Clothes",
                column: "Clothes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
