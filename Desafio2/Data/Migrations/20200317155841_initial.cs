using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Plaque = table.Column<string>(type: "varchar(8)", nullable: false),
                    Owner = table.Column<string>(type: "varchar(100)", nullable: false),
                    Stolen = table.Column<bool>(nullable: false),
                    YearOfManufacture = table.Column<DateTime>(nullable: false),
                    YearModel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
