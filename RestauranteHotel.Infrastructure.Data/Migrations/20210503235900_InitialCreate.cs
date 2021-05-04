using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteHotel.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Existencia = table.Column<decimal>(type: "Decimal", nullable: false),
                    Precio = table.Column<decimal>(type: "Decimal", nullable: false),
                    Costo = table.Column<decimal>(type: "Decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

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
                    table.ForeignKey(
                        name: "FK_ProductoCompuesto_Productos_Id",
                        column: x => x.Id,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoSimple",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoCompuestoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoSimple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoSimple_ProductoCompuesto_ProductoCompuestoId",
                        column: x => x.ProductoCompuestoId,
                        principalTable: "ProductoCompuesto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoSimple_Productos_Id",
                        column: x => x.Id,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Costo", "Existencia", "Nombre", "Precio" },
                values: new object[] { 1, 3.0000m, 10.0m, "perro sencillo", 5.000m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Costo", "Existencia", "Nombre", "Precio" },
                values: new object[] { 2, 1.000m, 10.0m, "salchicha", 0.0m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Costo", "Existencia", "Nombre", "Precio" },
                values: new object[] { 3, 1.000m, 10.0m, "pan de perro", 0.0m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Costo", "Existencia", "Nombre", "Precio" },
                values: new object[] { 4, 1.000m, 10.0m, "lamina de queso", 0.0m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Costo", "Existencia", "Nombre", "Precio" },
                values: new object[] { 5, 2.000m, 1.0m, "pan de perro extragrande", 0.0m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Costo", "Existencia", "Nombre", "Precio" },
                values: new object[] { 6, 2.000m, 10.0m, "salchicha ranchera", 0.0m });

            migrationBuilder.InsertData(
                table: "ProductoCompuesto",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "ProductoSimple",
                columns: new[] { "Id", "ProductoCompuestoId" },
                values: new object[] { 6, null });

            migrationBuilder.InsertData(
                table: "ProductoSimple",
                columns: new[] { "Id", "ProductoCompuestoId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "ProductoSimple",
                columns: new[] { "Id", "ProductoCompuestoId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "ProductoSimple",
                columns: new[] { "Id", "ProductoCompuestoId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "ProductoSimple",
                columns: new[] { "Id", "ProductoCompuestoId" },
                values: new object[] { 5, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoSimple_ProductoCompuestoId",
                table: "ProductoSimple",
                column: "ProductoCompuestoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoSimple");

            migrationBuilder.DropTable(
                name: "ProductoCompuesto");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
