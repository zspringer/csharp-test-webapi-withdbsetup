using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace csharptestwebapiwithdbsetup.Migrations
{
    public partial class RequireGetSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Headline",
                table: "Magazines",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Issue",
                table: "Magazines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Headline",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "Issue",
                table: "Magazines");
        }
    }
}
