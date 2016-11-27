using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurgiNeer.Data.Migrations
{
    public partial class StartDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Apply");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Apply",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Apply");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Apply",
                nullable: true);
        }
    }
}
