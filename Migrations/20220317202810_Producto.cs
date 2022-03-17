using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anderson_Gomez_Ap1_p2.Migrations
{
    public partial class Producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frutos",
                columns: table => new
                {
                    FrutosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Peso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frutos", x => x.FrutosId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Ganancia = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorInventario = table.Column<double>(type: "REAL", nullable: false),
                    Gramos = table.Column<double>(type: "REAL", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "FrutosDetalle",
                columns: table => new
                {
                    DetallesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Producto = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    FrutosId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrutosDetalle", x => x.DetallesId);
                    table.ForeignKey(
                        name: "FK_FrutosDetalle_Frutos_FrutosId",
                        column: x => x.FrutosId,
                        principalTable: "Frutos",
                        principalColumn: "FrutosId");
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalles",
                columns: table => new
                {
                    DetallesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescripcionDetalle = table.Column<string>(type: "TEXT", nullable: true),
                    Presentacion = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Empaque = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDetalles", x => x.DetallesId);
                    table.ForeignKey(
                        name: "FK_ProductosDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrutosDetalle_FrutosId",
                table: "FrutosDetalle",
                column: "FrutosId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalles_ProductoId",
                table: "ProductosDetalles",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrutosDetalle");

            migrationBuilder.DropTable(
                name: "ProductosDetalles");

            migrationBuilder.DropTable(
                name: "Frutos");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
