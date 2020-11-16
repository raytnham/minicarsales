using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniCarsales.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Engine = table.Column<string>(type: "TEXT", nullable: false),
                    Doors = table.Column<int>(type: "INTEGER", nullable: false),
                    Wheels = table.Column<int>(type: "INTEGER", nullable: false),
                    BodyType = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false)
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
