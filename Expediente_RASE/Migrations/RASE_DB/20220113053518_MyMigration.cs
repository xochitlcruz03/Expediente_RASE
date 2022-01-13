using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expediente_RASE.Migrations.RASE_DB
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C_ANT",
                columns: table => new
                {
                    ID_ANT = table.Column<int>(type: "int", nullable: false),
                    N_ANT = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__C_ANT__2A7D64511DB60CCE", x => x.ID_ANT);
                });

            migrationBuilder.CreateTable(
                name: "C_ESP",
                columns: table => new
                {
                    ID_ESP = table.Column<int>(type: "int", nullable: false),
                    N_ESP = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__C_ESP__2D4DED3728CEB3FB", x => x.ID_ESP);
                });

            migrationBuilder.CreateTable(
                name: "C_SUC",
                columns: table => new
                {
                    ID_SUC = table.Column<int>(type: "int", nullable: false),
                    NOM_SUC = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DIR_SUC = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__C_SUC__27F99A817495928B", x => x.ID_SUC);
                });

            migrationBuilder.CreateTable(
                name: "T_MEDICINA",
                columns: table => new
                {
                    ID_MED = table.Column<int>(type: "int", nullable: false),
                    NOM_MED = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DESC_MED = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_MEDICI__276D18CB4F407F07", x => x.ID_MED);
                });

            migrationBuilder.CreateTable(
                name: "T_PAC",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: false),
                    NOM_PAC = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    AP_PAT_PAC = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    AP_MAT_PAC = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    FEC_NAC_PAC = table.Column<DateTime>(type: "date", nullable: true),
                    SEXO_PAC = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    CURP_PAC = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: true),
                    TEL_PAC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CORREO_PAC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('')"),
                    T_SANGRE_PAC = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    EST_CIV_PAC = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    OCUPACION_PAC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NOTAS_PAC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, defaultValueSql: "('')"),
                    ARCH_PAC = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_PAC__20AF02C4A64BECF8", x => x.ID_PAC);
                });

            migrationBuilder.CreateTable(
                name: "T_USUARIOS",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    CORREO_U = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CONTRA_U = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    CARGO_U = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_USUARI__95F48440E94A473D", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "T_DOCTORES",
                columns: table => new
                {
                    ID_DOC = table.Column<int>(type: "int", nullable: false),
                    NOM_DOC = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    AP_PAT_DOC = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    AP_MAT_DOC = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    CURP_DOC = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: true),
                    REC_DIS = table.Column<int>(type: "int", nullable: true),
                    ID_ESP = table.Column<int>(type: "int", nullable: true),
                    CORREO_DOC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TEL_DOC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CED_P = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_DOCTOR__2BBF72881D2877F3", x => x.ID_DOC);
                    table.ForeignKey(
                        name: "FK_ID_ESP",
                        column: x => x.ID_ESP,
                        principalTable: "C_ESP",
                        principalColumn: "ID_ESP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANT_ALER",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    REG_ALER = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    DESC_ALER = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_PAC_ANT_ALER",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANT_HER",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    ID_ANT = table.Column<int>(type: "int", nullable: true),
                    REG_HER = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    AN_HER = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_ANT_HER",
                        column: x => x.ID_ANT,
                        principalTable: "C_ANT",
                        principalColumn: "ID_ANT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PAC_ANT_HER",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANT_NO_PAT",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    ID_ANT = table.Column<int>(type: "int", nullable: true),
                    REG_N_PAT = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    AN_N_PAT = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_ANT_N_PAT",
                        column: x => x.ID_ANT,
                        principalTable: "C_ANT",
                        principalColumn: "ID_ANT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PAC_ANT_N_PAT",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANT_OBS",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    ID_ANT = table.Column<int>(type: "int", nullable: true),
                    AN_PSI = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_ANT_OBS",
                        column: x => x.ID_ANT,
                        principalTable: "C_ANT",
                        principalColumn: "ID_ANT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PAC_ANT_OBS",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANT_PAT",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    ID_ANT = table.Column<int>(type: "int", nullable: true),
                    REG_PAT = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    AN_PAT = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_ANT_PAT",
                        column: x => x.ID_ANT,
                        principalTable: "C_ANT",
                        principalColumn: "ID_ANT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PAC_ANT_PAT",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANT_PSI",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    ID_ANT = table.Column<int>(type: "int", nullable: true),
                    REG_PSI = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    AN_PSI = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_ANT_PSI",
                        column: x => x.ID_ANT,
                        principalTable: "C_ANT",
                        principalColumn: "ID_ANT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PAC_ANT_PSI",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANT_QUI",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    REG_QUI = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    EDAD_Q = table.Column<int>(type: "int", nullable: true),
                    TIPO_Q = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_PAC_ANT_QUI",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRAT_ACTIVO",
                columns: table => new
                {
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    TIPO_TRAT = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    MEDIC = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_PAC_TRAT_ACT",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_CONSULTA",
                columns: table => new
                {
                    ID_CON = table.Column<int>(type: "int", nullable: false),
                    ID_PAC = table.Column<int>(type: "int", nullable: true),
                    ID_DOC = table.Column<int>(type: "int", nullable: true),
                    ID_SUC = table.Column<int>(type: "int", nullable: true),
                    FECHA_CON = table.Column<DateTime>(type: "date", nullable: true),
                    ESTATURA = table.Column<double>(type: "float", nullable: true),
                    PESO = table.Column<double>(type: "float", nullable: true),
                    MASA_CORP = table.Column<double>(type: "float", nullable: true),
                    TEMPERATURA = table.Column<double>(type: "float", nullable: true),
                    FREC_RESP = table.Column<int>(type: "int", nullable: true),
                    PRES_ART = table.Column<int>(type: "int", nullable: true),
                    FREC_CAR = table.Column<int>(type: "int", nullable: true),
                    GRASA_CORP = table.Column<int>(type: "int", nullable: true),
                    MASA_MUSC = table.Column<int>(type: "int", nullable: true),
                    SAT_OXIGENO = table.Column<int>(type: "int", nullable: true),
                    MOTIVO = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    DIAGNOSTICO = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__T_CONSUL__2BF968CCB382FC5C", x => x.ID_CON);
                    table.ForeignKey(
                        name: "FK_ID_DOC",
                        column: x => x.ID_DOC,
                        principalTable: "T_DOCTORES",
                        principalColumn: "ID_DOC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PAC",
                        column: x => x.ID_PAC,
                        principalTable: "T_PAC",
                        principalColumn: "ID_PAC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_SUC",
                        column: x => x.ID_SUC,
                        principalTable: "C_SUC",
                        principalColumn: "ID_SUC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_INS_MED",
                columns: table => new
                {
                    ID_CON = table.Column<int>(type: "int", nullable: true),
                    ID_MED = table.Column<int>(type: "int", nullable: true),
                    INDICACIONES = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    FRECUENCIA = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DURACION = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    NOTAS_INS = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ID_CON",
                        column: x => x.ID_CON,
                        principalTable: "T_CONSULTA",
                        principalColumn: "ID_CON",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_MED",
                        column: x => x.ID_MED,
                        principalTable: "T_MEDICINA",
                        principalColumn: "ID_MED",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ANT_ALER_ID_PAC",
                table: "ANT_ALER",
                column: "ID_PAC");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_HER_ID_ANT",
                table: "ANT_HER",
                column: "ID_ANT");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_HER_ID_PAC",
                table: "ANT_HER",
                column: "ID_PAC");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_NO_PAT_ID_ANT",
                table: "ANT_NO_PAT",
                column: "ID_ANT");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_NO_PAT_ID_PAC",
                table: "ANT_NO_PAT",
                column: "ID_PAC");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_OBS_ID_ANT",
                table: "ANT_OBS",
                column: "ID_ANT");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_OBS_ID_PAC",
                table: "ANT_OBS",
                column: "ID_PAC");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_PAT_ID_ANT",
                table: "ANT_PAT",
                column: "ID_ANT");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_PAT_ID_PAC",
                table: "ANT_PAT",
                column: "ID_PAC");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_PSI_ID_ANT",
                table: "ANT_PSI",
                column: "ID_ANT");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_PSI_ID_PAC",
                table: "ANT_PSI",
                column: "ID_PAC");

            migrationBuilder.CreateIndex(
                name: "IX_ANT_QUI_ID_PAC",
                table: "ANT_QUI",
                column: "ID_PAC");

            migrationBuilder.CreateIndex(
                name: "IX_T_CONSULTA_ID_DOC",
                table: "T_CONSULTA",
                column: "ID_DOC");

            migrationBuilder.CreateIndex(
                name: "IX_T_CONSULTA_ID_PAC",
                table: "T_CONSULTA",
                column: "ID_PAC");

            migrationBuilder.CreateIndex(
                name: "IX_T_CONSULTA_ID_SUC",
                table: "T_CONSULTA",
                column: "ID_SUC");

            migrationBuilder.CreateIndex(
                name: "IX_T_DOCTORES_ID_ESP",
                table: "T_DOCTORES",
                column: "ID_ESP");

            migrationBuilder.CreateIndex(
                name: "IX_T_INS_MED_ID_CON",
                table: "T_INS_MED",
                column: "ID_CON");

            migrationBuilder.CreateIndex(
                name: "IX_T_INS_MED_ID_MED",
                table: "T_INS_MED",
                column: "ID_MED");

            migrationBuilder.CreateIndex(
                name: "IX_TRAT_ACTIVO_ID_PAC",
                table: "TRAT_ACTIVO",
                column: "ID_PAC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANT_ALER");

            migrationBuilder.DropTable(
                name: "ANT_HER");

            migrationBuilder.DropTable(
                name: "ANT_NO_PAT");

            migrationBuilder.DropTable(
                name: "ANT_OBS");

            migrationBuilder.DropTable(
                name: "ANT_PAT");

            migrationBuilder.DropTable(
                name: "ANT_PSI");

            migrationBuilder.DropTable(
                name: "ANT_QUI");

            migrationBuilder.DropTable(
                name: "T_INS_MED");

            migrationBuilder.DropTable(
                name: "T_USUARIOS");

            migrationBuilder.DropTable(
                name: "TRAT_ACTIVO");

            migrationBuilder.DropTable(
                name: "C_ANT");

            migrationBuilder.DropTable(
                name: "T_CONSULTA");

            migrationBuilder.DropTable(
                name: "T_MEDICINA");

            migrationBuilder.DropTable(
                name: "T_DOCTORES");

            migrationBuilder.DropTable(
                name: "T_PAC");

            migrationBuilder.DropTable(
                name: "C_SUC");

            migrationBuilder.DropTable(
                name: "C_ESP");
        }
    }
}
