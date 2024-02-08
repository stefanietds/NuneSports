using Microsoft.EntityFrameworkCore.Migrations;
using NuneSports.Model;

#nullable disable

namespace NuneSports.Migrations
{
    public partial class SegundaMigracaoAlteracaoPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco_Produto",
                table: "Produtos",
                type: "decimal(6,2)", 
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoProduto",
                table: "Produtos");
        }
    }
}
