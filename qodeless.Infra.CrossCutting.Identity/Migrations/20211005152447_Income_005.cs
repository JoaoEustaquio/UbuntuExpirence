using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace qodeless.Infra.CrossCutting.Identity.Migrations
{
    public partial class Income_005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeTypes",
                table: "IncomeTypes");

            migrationBuilder.RenameTable(
                name: "IncomeTypes",
                newName: "IncomeType");

            migrationBuilder.AddColumn<Guid>(
                name: "IncomeTypeId",
                table: "Income",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Income",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Income",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Income",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IncomeType",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeType",
                table: "IncomeType",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeType",
                table: "IncomeType");

            migrationBuilder.DropColumn(
                name: "IncomeTypeId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Income");

            migrationBuilder.RenameTable(
                name: "IncomeType",
                newName: "IncomeTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IncomeTypes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeTypes",
                table: "IncomeTypes",
                column: "Id");
        }
    }
}
