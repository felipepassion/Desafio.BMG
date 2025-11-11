using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bmg.Desafio.Contratacao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2025_11_09_15_00_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContratacaoAggSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Deletado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratacaoAggSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropostaId = table.Column<int>(type: "integer", nullable: false),
                    NumeroContrato = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InicioVigencia = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FimVigencia = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ValorPremio = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorCobertura = table.Column<decimal>(type: "numeric", nullable: false),
                    SnapshotPropostaJson = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    MotivoCancelamento = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DataCancelamento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ExternalId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Deletado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratacaoAggSettings");

            migrationBuilder.DropTable(
                name: "Contrato");
        }
    }
}
