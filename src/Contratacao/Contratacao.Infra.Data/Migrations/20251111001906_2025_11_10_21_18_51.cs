using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmg.Desafio.Contratacao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2025_11_10_21_18_51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SnapshotPropostaJson",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "ValorCobertura",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "ValorPremio",
                table: "Contrato");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contrato",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_UserId",
                table: "Contrato",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_User_UserId",
                table: "Contrato",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_User_UserId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_UserId",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contrato");

            migrationBuilder.AddColumn<string>(
                name: "SnapshotPropostaJson",
                table: "Contrato",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorCobertura",
                table: "Contrato",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPremio",
                table: "Contrato",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
