using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaty.Migrations
{
    public partial class AddNewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffetType",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "MessagesNumber",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MessagesNumber",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferNumber",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PayedOrNot",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessagesNumber",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MessagesNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OfferNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PayedOrNot",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "OffetType",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
