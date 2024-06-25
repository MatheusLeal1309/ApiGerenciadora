using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "TB_USURARIO",
                newName: "Username");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAcesso",
                table: "TB_USURARIO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "TB_USURARIO",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "TB_USURARIO",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "TB_USURARIO",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "TB_USURARIO",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "TB_USURARIO",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "TB_USURARIO",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAcesso",
                table: "TB_USURARIO");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "TB_USURARIO");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TB_USURARIO");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TB_USURARIO");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "TB_USURARIO");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "TB_USURARIO");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "TB_USURARIO");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "TB_USURARIO",
                newName: "Senha");
        }
    }
}
