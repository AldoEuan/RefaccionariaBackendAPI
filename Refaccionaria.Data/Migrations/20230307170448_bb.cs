using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Refaccionaria.Data.Migrations
{
    /// <inheritdoc />
    public partial class bb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Descripcion = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Preciocosto = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    Precioventa = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    Existencia = table.Column<decimal>(type: "SMALLMONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMALLMONEY = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detalleventa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precioventa = table.Column<decimal>(type: "SMALLMONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalleventa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalleventa_Sale_IdVenta",
                        column: x => x.IdVenta,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalleventa_producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalleventa_IdProducto",
                table: "Detalleventa",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Detalleventa_IdVenta",
                table: "Detalleventa",
                column: "IdVenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalleventa");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "producto");
        }
    }
}
