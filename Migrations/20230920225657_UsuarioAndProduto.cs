using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Donation.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioAndProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoProduto",
                newName: "TipoProdutoId");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoProduto",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SugestaoTroca = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produto_TipoProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "TipoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TipoProdutoId",
                table: "Produto",
                column: "TipoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UsuarioId",
                table: "Produto",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.RenameColumn(
                name: "TipoProdutoId",
                table: "TipoProduto",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoProduto",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
