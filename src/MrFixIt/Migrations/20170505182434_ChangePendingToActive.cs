using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrFixIt.Migrations
{
    public partial class ChangePendingToActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pending",
                table: "Jobs");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Jobs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Jobs");

            migrationBuilder.AddColumn<bool>(
                name: "Pending",
                table: "Jobs",
                nullable: false,
                defaultValue: false);
        }
    }
}
