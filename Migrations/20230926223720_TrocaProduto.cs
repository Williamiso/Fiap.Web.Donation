using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Donation.Migrations
{
    /// <inheritdoc />
    public partial class TrocaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Troca",
                columns: table => new
                {
                    TrocaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProdutoId1 = table.Column<int>(type: "int", nullable: false),
                    ProdutoId2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troca", x => x.TrocaId);
                    table.ForeignKey(
                        name: "FK_Troca_Produto_ProdutoId1",
                        column: x => x.ProdutoId1,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Troca_Produto_ProdutoId2",
                        column: x => x.ProdutoId2,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Troca_ProdutoId1",
                table: "Troca",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Troca_ProdutoId2",
                table: "Troca",
                column: "ProdutoId2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Troca");
        }
    }
}
