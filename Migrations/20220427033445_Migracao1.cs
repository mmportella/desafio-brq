using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBRQ.Migrations
{
    public partial class Migracao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Nascimento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.IdCandidato);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSkill = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.IdSkill);
                });

            migrationBuilder.CreateTable(
                name: "Certificacoes",
                columns: table => new
                {
                    IdCertificacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instituicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeCertificacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificacoes", x => x.IdCertificacao);
                    table.ForeignKey(
                        name: "FK_Certificacoes_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "IdSkill",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillCandidatos",
                columns: table => new
                {
                    IdSkillCandidato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCandidatos", x => x.IdSkillCandidato);
                    table.ForeignKey(
                        name: "FK_SkillCandidatos_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillCandidatos_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "IdSkill",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificacoesCandidatos",
                columns: table => new
                {
                    IdCertificacaoCandidato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    CertificacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificacoesCandidatos", x => x.IdCertificacaoCandidato);
                    table.ForeignKey(
                        name: "FK_CertificacoesCandidatos_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificacoesCandidatos_Certificacoes_CertificacaoId",
                        column: x => x.CertificacaoId,
                        principalTable: "Certificacoes",
                        principalColumn: "IdCertificacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificacoes_SkillId",
                table: "Certificacoes",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificacoesCandidatos_CandidatoId",
                table: "CertificacoesCandidatos",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificacoesCandidatos_CertificacaoId",
                table: "CertificacoesCandidatos",
                column: "CertificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCandidatos_CandidatoId",
                table: "SkillCandidatos",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCandidatos_SkillId",
                table: "SkillCandidatos",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificacoesCandidatos");

            migrationBuilder.DropTable(
                name: "SkillCandidatos");

            migrationBuilder.DropTable(
                name: "Certificacoes");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
