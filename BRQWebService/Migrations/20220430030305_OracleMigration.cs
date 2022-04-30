using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BRQWebService.Migrations
{
    public partial class OracleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CANDIDATO",
                columns: table => new
                {
                    nr_cpf = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    nr_telefone = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    genero = table.Column<string>(type: "NVARCHAR2(1)", nullable: false),
                    dt_aniversario = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CANDIDATO", x => x.nr_cpf);
                });

            migrationBuilder.CreateTable(
                name: "TB_CERTIFICADO",
                columns: table => new
                {
                    cd_certificado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_certificado = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    nr_cpf = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CERTIFICADO", x => x.cd_certificado);
                    table.ForeignKey(
                        name: "FK_TB_CERTIFICADO_TB_CANDIDATO_nr_cpf",
                        column: x => x.nr_cpf,
                        principalTable: "TB_CANDIDATO",
                        principalColumn: "nr_cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_SKILL",
                columns: table => new
                {
                    cd_skill = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_skill = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    nr_cpf = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SKILL", x => x.cd_skill);
                    table.ForeignKey(
                        name: "FK_TB_SKILL_TB_CANDIDATO_nr_cpf",
                        column: x => x.nr_cpf,
                        principalTable: "TB_CANDIDATO",
                        principalColumn: "nr_cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CERTIFICADO_nr_cpf",
                table: "TB_CERTIFICADO",
                column: "nr_cpf");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SKILL_nr_cpf",
                table: "TB_SKILL",
                column: "nr_cpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CERTIFICADO");

            migrationBuilder.DropTable(
                name: "TB_SKILL");

            migrationBuilder.DropTable(
                name: "TB_CANDIDATO");
        }
    }
}
