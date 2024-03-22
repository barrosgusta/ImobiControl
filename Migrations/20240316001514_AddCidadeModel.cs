using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobiControl.Migrations
{
    /// <inheritdoc />
    public partial class AddCidadeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EstadoSigla = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstadoSigla",
                        column: x => x.EstadoSigla,
                        principalTable: "Estado",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoSigla",
                table: "Cidade",
                column: "EstadoSigla");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidade");
        }
    }
}
