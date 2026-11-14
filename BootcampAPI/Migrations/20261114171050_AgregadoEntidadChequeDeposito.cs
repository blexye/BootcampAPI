using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootcampAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoEntidadChequeDeposito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepositoCheques",
                columns: table => new
                {
                    IdDepositoCheque = table.Column<Guid>(type: "uuid", nullable: false),
                    IdAccount = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroCheque = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    BancoEmisor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MontoNumero = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    MontoLetra = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    EstadoDeposito = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    FechaSolicitudDepositoCheque = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaUltimaModificacionDepositoCheque = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaRevisionDepositoCheque = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MotivoRechazo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FotoFrontalRuta = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FotoDorsalRuta = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositoCheques", x => x.IdDepositoCheque);
                    table.ForeignKey(
                        name: "FK_DepositoCheques_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositoCheques_EstadoDeposito",
                table: "DepositoCheques",
                column: "EstadoDeposito");

            migrationBuilder.CreateIndex(
                name: "IX_DepositoCheques_IdAccount",
                table: "DepositoCheques",
                column: "IdAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositoCheques");
        }
    }
}
