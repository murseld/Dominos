using Microsoft.EntityFrameworkCore.Migrations;

namespace Dominos.Services.DbWrite.Data.Migrations
{
    public partial class initialmigration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    src_long = table.Column<double>(type: "float", nullable: false),
                    src_lat = table.Column<double>(type: "float", nullable: false),
                    des_long = table.Column<double>(type: "float", nullable: false),
                    des_lat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_id",
                table: "Locations",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
