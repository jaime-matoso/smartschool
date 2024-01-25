using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sobrenome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    datanascimento = table.Column<DateTime>(name: "data_nascimento", type: "datetime(6)", nullable: false),
                    datainicio = table.Column<DateTime>(name: "data_inicio", type: "datetime(6)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sobrenome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "disciplina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplina", x => x.id);
                    table.ForeignKey(
                        name: "FK_disciplina_professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "aluno",
                columns: new[] { "id", "data_inicio", "data_nascimento", "nome", "sobrenome", "status", "telefone" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marta", "Kent", true, "(31)99898-8787" },
                    { 2, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paula", "Isabela", true, "(31)99898-878 7" },
                    { 3, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Antonia", true, "(31)99898-8787" },
                    { 4, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luiza", "Maria", true, "(31)99898-8787" },
                    { 5, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", "Machado", true, "(31)99898-8787" },
                    { 6, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "Alvares", true, "(31)99898-8787" },
                    { 7, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paulo", "José", true, "(31)99898-8787" }
                });

            migrationBuilder.InsertData(
                table: "professor",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[,]
                {
                    { 1, "Lauro", "Professor", "(31)99898-8787" },
                    { 2, "Roberto", "Professor", "(31)99898-8787" },
                    { 3, "Ronaldo", "Professor", "(31)99898-8787" },
                    { 4, "Rodrigo", "Professor", "(31)99898-8787" },
                    { 5, "Alexandre", "Professor", "(31)99898-8787" }
                });

            migrationBuilder.InsertData(
                table: "disciplina",
                columns: new[] { "id", "nome", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "Matemática", 1 },
                    { 2, "Física", 2 },
                    { 3, "Português", 3 },
                    { 4, "Inglês", 4 },
                    { 5, "Programação", 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 4 },
                    { 5, 5 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_disciplina_ProfessorId",
                table: "disciplina",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "disciplina");

            migrationBuilder.DropTable(
                name: "professor");
        }
    }
}
