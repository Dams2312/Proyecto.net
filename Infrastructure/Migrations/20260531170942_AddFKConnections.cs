using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFKConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "condiciones",
                table: "garantia",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "mecanico_id",
                table: "garantia",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "orden_id",
                table: "garantia",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tipo_servicio_id",
                table: "garantia",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ciudad_id",
                table: "cliente_direccion",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "idx_garantia_orden",
                table: "garantia",
                column: "orden_id");

            migrationBuilder.CreateIndex(
                name: "IX_garantia_mecanico_id",
                table: "garantia",
                column: "mecanico_id");

            migrationBuilder.CreateIndex(
                name: "IX_garantia_tipo_servicio_id",
                table: "garantia",
                column: "tipo_servicio_id");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_direccion_ciudad_id",
                table: "cliente_direccion",
                column: "ciudad_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_direccion_ciudad_ciudad_id",
                table: "cliente_direccion",
                column: "ciudad_id",
                principalTable: "ciudad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_garantia_orden_servicio_orden_id",
                table: "garantia",
                column: "orden_id",
                principalTable: "orden_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_garantia_tipo_servicio_tipo_servicio_id",
                table: "garantia",
                column: "tipo_servicio_id",
                principalTable: "tipo_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_garantia_usuario_mecanico_id",
                table: "garantia",
                column: "mecanico_id",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliente_direccion_ciudad_ciudad_id",
                table: "cliente_direccion");

            migrationBuilder.DropForeignKey(
                name: "FK_garantia_orden_servicio_orden_id",
                table: "garantia");

            migrationBuilder.DropForeignKey(
                name: "FK_garantia_tipo_servicio_tipo_servicio_id",
                table: "garantia");

            migrationBuilder.DropForeignKey(
                name: "FK_garantia_usuario_mecanico_id",
                table: "garantia");

            migrationBuilder.DropIndex(
                name: "idx_garantia_orden",
                table: "garantia");

            migrationBuilder.DropIndex(
                name: "IX_garantia_mecanico_id",
                table: "garantia");

            migrationBuilder.DropIndex(
                name: "IX_garantia_tipo_servicio_id",
                table: "garantia");

            migrationBuilder.DropIndex(
                name: "IX_cliente_direccion_ciudad_id",
                table: "cliente_direccion");

            migrationBuilder.DropColumn(
                name: "mecanico_id",
                table: "garantia");

            migrationBuilder.DropColumn(
                name: "orden_id",
                table: "garantia");

            migrationBuilder.DropColumn(
                name: "tipo_servicio_id",
                table: "garantia");

            migrationBuilder.DropColumn(
                name: "ciudad_id",
                table: "cliente_direccion");

            migrationBuilder.AlterColumn<string>(
                name: "condiciones",
                table: "garantia",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
