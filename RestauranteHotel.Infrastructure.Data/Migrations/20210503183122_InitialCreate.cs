using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteHotel.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductoCompuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCompuesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Existencia = table.Column<decimal>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductoCompuestoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_ProductoCompuesto_ProductoCompuestoId",
                        column: x => x.ProductoCompuestoId,
                        principalTable: "ProductoCompuesto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoSimple",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoSimple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoSimple_Producto_Id",
                        column: x => x.Id,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProductoCompuestoId",
                table: "Producto",
                column: "ProductoCompuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoCompuesto_Producto_Id",
                table: "ProductoCompuesto",
                column: "Id",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ProductoCompuesto_ProductoCompuestoId",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "ProductoSimple");

            migrationBuilder.DropTable(
                name: "ProductoCompuesto");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
