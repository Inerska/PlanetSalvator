using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetSalvator.Web.Server.Migrations
{
    public partial class AddGuidToDailyTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "DailyTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "DailyTasks");
        }
    }
}
