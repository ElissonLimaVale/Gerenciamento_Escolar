using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGIEscolar.Data.Migrations
{
    public partial class Alteracao_Turmas_Professores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professores_ProfessorId1",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_ProfessorId1",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "ProfessorId1",
                table: "Turmas");

            migrationBuilder.CreateTable(
                name: "TurmasProfessores",
                columns: table => new
                {
                    ProfessoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmasProfessores", x => new { x.ProfessoresId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_TurmasProfessores_Professores_ProfessoresId",
                        column: x => x.ProfessoresId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmasProfessores_Turmas_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TurmasProfessores_TurmasId",
                table: "TurmasProfessores",
                column: "TurmasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurmasProfessores");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId1",
                table: "Turmas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ProfessorId1",
                table: "Turmas",
                column: "ProfessorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professores_ProfessorId1",
                table: "Turmas",
                column: "ProfessorId1",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
