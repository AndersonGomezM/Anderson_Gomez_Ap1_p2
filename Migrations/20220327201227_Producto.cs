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
                name: "Empacados",
                columns: table => new
                {
                    EmpacadosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductoEmpacado = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empacados", x => x.EmpacadosId);
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
                name: "EmpacadosDetalle",
                columns: table => new
                {
                    DetallesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Producto = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: false),
                    EmpacadosId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpacadosDetalle", x => x.DetallesId);
                    table.ForeignKey(
                        name: "FK_EmpacadosDetalle_Empacados_EmpacadosId",
                        column: x => x.EmpacadosId,
                        principalTable: "Empacados",
                        principalColumn: "EmpacadosId");
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalle",
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
                    table.PrimaryKey("PK_ProductosDetalle", x => x.DetallesId);
                    table.ForeignKey(
                        name: "FK_ProductosDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpacadosDetalle_EmpacadosId",
                table: "EmpacadosDetalle",
                column: "EmpacadosId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalle_ProductoId",
                table: "ProductosDetalle",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpacadosDetalle");

            migrationBuilder.DropTable(
                name: "ProductosDetalle");

            migrationBuilder.DropTable(
                name: "Empacados");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
