using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.Migrations
{
    public partial class PointHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Action = table.Column<int>(nullable: false),
                    ChangedOn = table.Column<DateTime>(nullable: false),
                    NewDate = table.Column<DateTime>(nullable: false),
                    NewLatitude = table.Column<double>(nullable: false),
                    NewLongitude = table.Column<double>(nullable: false),
                    NewNotes = table.Column<string>(nullable: true),
                    OldDate = table.Column<DateTime>(nullable: false),
                    OldLatitude = table.Column<double>(nullable: false),
                    OldLongitude = table.Column<double>(nullable: false),
                    OldNotes = table.Column<string>(nullable: true),
                    PointId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointsHistory");
        }
    }
}
