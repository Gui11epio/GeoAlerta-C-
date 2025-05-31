using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoAlerta_C_.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    User_name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ENDERECO_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALERTAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NivelRisco = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Probabilidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALERTAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ALERTAS_TB_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "TB_ENDERECO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ALERTAS_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTAS_EnderecoId",
                table: "TB_ALERTAS",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALERTAS_UsuarioId",
                table: "TB_ALERTAS",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_UsuarioId",
                table: "TB_ENDERECO",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALERTAS");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
