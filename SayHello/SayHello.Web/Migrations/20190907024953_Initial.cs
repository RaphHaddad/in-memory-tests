﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SayHello.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hellos",
                columns: table => new
                {
                    ISO639LanguageId = table.Column<string>(nullable: false),
                    LanguageName = table.Column<string>(nullable: true),
                    HelloText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hellos", x => x.ISO639LanguageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hellos");
        }
    }
}
