﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicacion.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitud = table.Column<float>(type: "real", nullable: false),
                    Longitud = table.Column<float>(type: "real", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaMontaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReporteId = table.Column<int>(type: "int", nullable: true),
                    TecnicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estaciones_Personas_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estaciones_Reporte_ReporteId",
                        column: x => x.ReporteId,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Datometeorologico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    TipoDato = table.Column<int>(type: "int", nullable: false),
                    EstacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datometeorologico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Datometeorologico_Estaciones_EstacionId",
                        column: x => x.EstacionId,
                        principalTable: "Estaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datometeorologico_EstacionId",
                table: "Datometeorologico",
                column: "EstacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Estaciones_ReporteId",
                table: "Estaciones",
                column: "ReporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Estaciones_TecnicoId",
                table: "Estaciones",
                column: "TecnicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datometeorologico");

            migrationBuilder.DropTable(
                name: "Estaciones");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Reporte");
        }
    }
}
