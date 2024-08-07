﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecMatheus.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Imcs",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Imcs");
        }
    }
}
