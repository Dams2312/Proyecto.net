using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJwtAuthenticationAndFixForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compra_proveedor_proveedor_id1",
                table: "compra");

            migrationBuilder.DropForeignKey(
                name: "FK_compra_usuario_usuario_id1",
                table: "compra");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_compra_compra_compra_id1",
                table: "detalle_compra");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_compra_repuesto_repuesto_id1",
                table: "detalle_compra");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_orden_orden_servicio_orden_id1",
                table: "detalle_orden");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_orden_repuesto_repuesto_id1",
                table: "detalle_orden");

            migrationBuilder.DropForeignKey(
                name: "FK_historial_estado_orden_estado_orden_estado_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropForeignKey(
                name: "FK_historial_estado_orden_orden_servicio_orden_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropForeignKey(
                name: "FK_historial_estado_orden_usuario_usuario_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropForeignKey(
                name: "FK_historial_kilometraje_vehiculo_vehiculo_id1",
                table: "historial_kilometraje");

            migrationBuilder.DropForeignKey(
                name: "FK_modelo_vehiculo_marca_vehiculo_marca_id1",
                table: "modelo_vehiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_nota_orden_orden_servicio_orden_id1",
                table: "nota_orden");

            migrationBuilder.DropForeignKey(
                name: "FK_nota_orden_usuario_usuario_id1",
                table: "nota_orden");

            migrationBuilder.DropForeignKey(
                name: "FK_orden_mecanico_orden_servicio_orden_id1",
                table: "orden_mecanico");

            migrationBuilder.DropForeignKey(
                name: "FK_orden_mecanico_usuario_mecanico_id1",
                table: "orden_mecanico");

            migrationBuilder.DropForeignKey(
                name: "FK_orden_servicio_estado_orden_estado_id1",
                table: "orden_servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_orden_servicio_usuario_recepcionista_id1",
                table: "orden_servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_orden_servicio_vehiculo_vehiculo_id1",
                table: "orden_servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_orden_tipo_servicio_orden_servicio_orden_id1",
                table: "orden_tipo_servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_orden_tipo_servicio_tipo_servicio_tipo_servicio_id1",
                table: "orden_tipo_servicio");

            migrationBuilder.DropForeignKey(
                name: "FK_repuesto_categoria_repuesto_categoria_id1",
                table: "repuesto");

            migrationBuilder.DropForeignKey(
                name: "FK_repuesto_unidad_medida_unidad_id1",
                table: "repuesto");

            migrationBuilder.DropForeignKey(
                name: "FK_repuesto_proveedor_proveedor_proveedor_id1",
                table: "repuesto_proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_repuesto_proveedor_repuesto_repuesto_id1",
                table: "repuesto_proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_tarea_mecanico_orden_servicio_orden_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropForeignKey(
                name: "FK_tarea_mecanico_tipo_servicio_tipo_servicio_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropForeignKey(
                name: "FK_tarea_mecanico_usuario_mecanico_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_rol_id1",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_rol_id1",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_tarea_mecanico_mecanico_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropIndex(
                name: "IX_tarea_mecanico_orden_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropIndex(
                name: "IX_tarea_mecanico_tipo_servicio_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropIndex(
                name: "IX_repuesto_proveedor_proveedor_id1",
                table: "repuesto_proveedor");

            migrationBuilder.DropIndex(
                name: "IX_repuesto_proveedor_repuesto_id1",
                table: "repuesto_proveedor");

            migrationBuilder.DropIndex(
                name: "IX_repuesto_categoria_id1",
                table: "repuesto");

            migrationBuilder.DropIndex(
                name: "IX_repuesto_unidad_id1",
                table: "repuesto");

            migrationBuilder.DropIndex(
                name: "IX_orden_tipo_servicio_orden_id1",
                table: "orden_tipo_servicio");

            migrationBuilder.DropIndex(
                name: "IX_orden_tipo_servicio_tipo_servicio_id1",
                table: "orden_tipo_servicio");

            migrationBuilder.DropIndex(
                name: "IX_orden_servicio_estado_id1",
                table: "orden_servicio");

            migrationBuilder.DropIndex(
                name: "IX_orden_servicio_recepcionista_id1",
                table: "orden_servicio");

            migrationBuilder.DropIndex(
                name: "IX_orden_servicio_vehiculo_id1",
                table: "orden_servicio");

            migrationBuilder.DropIndex(
                name: "IX_orden_mecanico_mecanico_id1",
                table: "orden_mecanico");

            migrationBuilder.DropIndex(
                name: "IX_orden_mecanico_orden_id1",
                table: "orden_mecanico");

            migrationBuilder.DropIndex(
                name: "IX_nota_orden_orden_id1",
                table: "nota_orden");

            migrationBuilder.DropIndex(
                name: "IX_nota_orden_usuario_id1",
                table: "nota_orden");

            migrationBuilder.DropIndex(
                name: "IX_modelo_vehiculo_marca_id1",
                table: "modelo_vehiculo");

            migrationBuilder.DropIndex(
                name: "IX_historial_kilometraje_vehiculo_id1",
                table: "historial_kilometraje");

            migrationBuilder.DropIndex(
                name: "IX_historial_estado_orden_estado_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropIndex(
                name: "IX_historial_estado_orden_orden_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropIndex(
                name: "IX_historial_estado_orden_usuario_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropIndex(
                name: "IX_detalle_orden_orden_id1",
                table: "detalle_orden");

            migrationBuilder.DropIndex(
                name: "IX_detalle_orden_repuesto_id1",
                table: "detalle_orden");

            migrationBuilder.DropIndex(
                name: "IX_detalle_compra_compra_id1",
                table: "detalle_compra");

            migrationBuilder.DropIndex(
                name: "IX_detalle_compra_repuesto_id1",
                table: "detalle_compra");

            migrationBuilder.DropIndex(
                name: "IX_compra_proveedor_id1",
                table: "compra");

            migrationBuilder.DropIndex(
                name: "IX_compra_usuario_id1",
                table: "compra");

            migrationBuilder.DropColumn(
                name: "rol_id1",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "mecanico_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropColumn(
                name: "orden_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropColumn(
                name: "tipo_servicio_id1",
                table: "tarea_mecanico");

            migrationBuilder.DropColumn(
                name: "proveedor_id1",
                table: "repuesto_proveedor");

            migrationBuilder.DropColumn(
                name: "repuesto_id1",
                table: "repuesto_proveedor");

            migrationBuilder.DropColumn(
                name: "categoria_id1",
                table: "repuesto");

            migrationBuilder.DropColumn(
                name: "unidad_id1",
                table: "repuesto");

            migrationBuilder.DropColumn(
                name: "orden_id1",
                table: "orden_tipo_servicio");

            migrationBuilder.DropColumn(
                name: "tipo_servicio_id1",
                table: "orden_tipo_servicio");

            migrationBuilder.DropColumn(
                name: "estado_id1",
                table: "orden_servicio");

            migrationBuilder.DropColumn(
                name: "recepcionista_id1",
                table: "orden_servicio");

            migrationBuilder.DropColumn(
                name: "vehiculo_id1",
                table: "orden_servicio");

            migrationBuilder.DropColumn(
                name: "mecanico_id1",
                table: "orden_mecanico");

            migrationBuilder.DropColumn(
                name: "orden_id1",
                table: "orden_mecanico");

            migrationBuilder.DropColumn(
                name: "orden_id1",
                table: "nota_orden");

            migrationBuilder.DropColumn(
                name: "usuario_id1",
                table: "nota_orden");

            migrationBuilder.DropColumn(
                name: "marca_id1",
                table: "modelo_vehiculo");

            migrationBuilder.DropColumn(
                name: "vehiculo_id1",
                table: "historial_kilometraje");

            migrationBuilder.DropColumn(
                name: "estado_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropColumn(
                name: "orden_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropColumn(
                name: "usuario_id1",
                table: "historial_estado_orden");

            migrationBuilder.DropColumn(
                name: "orden_id1",
                table: "detalle_orden");

            migrationBuilder.DropColumn(
                name: "repuesto_id1",
                table: "detalle_orden");

            migrationBuilder.DropColumn(
                name: "compra_id1",
                table: "detalle_compra");

            migrationBuilder.DropColumn(
                name: "repuesto_id1",
                table: "detalle_compra");

            migrationBuilder.DropColumn(
                name: "proveedor_id1",
                table: "compra");

            migrationBuilder.DropColumn(
                name: "usuario_id1",
                table: "compra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "rol_id1",
                table: "usuario",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "mecanico_id1",
                table: "tarea_mecanico",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "orden_id1",
                table: "tarea_mecanico",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "tipo_servicio_id1",
                table: "tarea_mecanico",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "proveedor_id1",
                table: "repuesto_proveedor",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "repuesto_id1",
                table: "repuesto_proveedor",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "categoria_id1",
                table: "repuesto",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "unidad_id1",
                table: "repuesto",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "orden_id1",
                table: "orden_tipo_servicio",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "tipo_servicio_id1",
                table: "orden_tipo_servicio",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "estado_id1",
                table: "orden_servicio",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "recepcionista_id1",
                table: "orden_servicio",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "vehiculo_id1",
                table: "orden_servicio",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "mecanico_id1",
                table: "orden_mecanico",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "orden_id1",
                table: "orden_mecanico",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "orden_id1",
                table: "nota_orden",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "usuario_id1",
                table: "nota_orden",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "marca_id1",
                table: "modelo_vehiculo",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "vehiculo_id1",
                table: "historial_kilometraje",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "estado_id1",
                table: "historial_estado_orden",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "orden_id1",
                table: "historial_estado_orden",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "usuario_id1",
                table: "historial_estado_orden",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "orden_id1",
                table: "detalle_orden",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "repuesto_id1",
                table: "detalle_orden",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "compra_id1",
                table: "detalle_compra",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "repuesto_id1",
                table: "detalle_compra",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "proveedor_id1",
                table: "compra",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "usuario_id1",
                table: "compra",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_id1",
                table: "usuario",
                column: "rol_id1");

            migrationBuilder.CreateIndex(
                name: "IX_tarea_mecanico_mecanico_id1",
                table: "tarea_mecanico",
                column: "mecanico_id1");

            migrationBuilder.CreateIndex(
                name: "IX_tarea_mecanico_orden_id1",
                table: "tarea_mecanico",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_tarea_mecanico_tipo_servicio_id1",
                table: "tarea_mecanico",
                column: "tipo_servicio_id1");

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_proveedor_proveedor_id1",
                table: "repuesto_proveedor",
                column: "proveedor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_proveedor_repuesto_id1",
                table: "repuesto_proveedor",
                column: "repuesto_id1");

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_categoria_id1",
                table: "repuesto",
                column: "categoria_id1");

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_unidad_id1",
                table: "repuesto",
                column: "unidad_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_tipo_servicio_orden_id1",
                table: "orden_tipo_servicio",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_tipo_servicio_tipo_servicio_id1",
                table: "orden_tipo_servicio",
                column: "tipo_servicio_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_estado_id1",
                table: "orden_servicio",
                column: "estado_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_recepcionista_id1",
                table: "orden_servicio",
                column: "recepcionista_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_vehiculo_id1",
                table: "orden_servicio",
                column: "vehiculo_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_mecanico_mecanico_id1",
                table: "orden_mecanico",
                column: "mecanico_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_mecanico_orden_id1",
                table: "orden_mecanico",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_nota_orden_orden_id1",
                table: "nota_orden",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_nota_orden_usuario_id1",
                table: "nota_orden",
                column: "usuario_id1");

            migrationBuilder.CreateIndex(
                name: "IX_modelo_vehiculo_marca_id1",
                table: "modelo_vehiculo",
                column: "marca_id1");

            migrationBuilder.CreateIndex(
                name: "IX_historial_kilometraje_vehiculo_id1",
                table: "historial_kilometraje",
                column: "vehiculo_id1");

            migrationBuilder.CreateIndex(
                name: "IX_historial_estado_orden_estado_id1",
                table: "historial_estado_orden",
                column: "estado_id1");

            migrationBuilder.CreateIndex(
                name: "IX_historial_estado_orden_orden_id1",
                table: "historial_estado_orden",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_historial_estado_orden_usuario_id1",
                table: "historial_estado_orden",
                column: "usuario_id1");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_orden_id1",
                table: "detalle_orden",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_repuesto_id1",
                table: "detalle_orden",
                column: "repuesto_id1");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_compra_compra_id1",
                table: "detalle_compra",
                column: "compra_id1");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_compra_repuesto_id1",
                table: "detalle_compra",
                column: "repuesto_id1");

            migrationBuilder.CreateIndex(
                name: "IX_compra_proveedor_id1",
                table: "compra",
                column: "proveedor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_compra_usuario_id1",
                table: "compra",
                column: "usuario_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_compra_proveedor_proveedor_id1",
                table: "compra",
                column: "proveedor_id1",
                principalTable: "proveedor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_compra_usuario_usuario_id1",
                table: "compra",
                column: "usuario_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_compra_compra_compra_id1",
                table: "detalle_compra",
                column: "compra_id1",
                principalTable: "compra",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_compra_repuesto_repuesto_id1",
                table: "detalle_compra",
                column: "repuesto_id1",
                principalTable: "repuesto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_orden_orden_servicio_orden_id1",
                table: "detalle_orden",
                column: "orden_id1",
                principalTable: "orden_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_orden_repuesto_repuesto_id1",
                table: "detalle_orden",
                column: "repuesto_id1",
                principalTable: "repuesto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_historial_estado_orden_estado_orden_estado_id1",
                table: "historial_estado_orden",
                column: "estado_id1",
                principalTable: "estado_orden",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_historial_estado_orden_orden_servicio_orden_id1",
                table: "historial_estado_orden",
                column: "orden_id1",
                principalTable: "orden_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_historial_estado_orden_usuario_usuario_id1",
                table: "historial_estado_orden",
                column: "usuario_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_historial_kilometraje_vehiculo_vehiculo_id1",
                table: "historial_kilometraje",
                column: "vehiculo_id1",
                principalTable: "vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_modelo_vehiculo_marca_vehiculo_marca_id1",
                table: "modelo_vehiculo",
                column: "marca_id1",
                principalTable: "marca_vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_nota_orden_orden_servicio_orden_id1",
                table: "nota_orden",
                column: "orden_id1",
                principalTable: "orden_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nota_orden_usuario_usuario_id1",
                table: "nota_orden",
                column: "usuario_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orden_mecanico_orden_servicio_orden_id1",
                table: "orden_mecanico",
                column: "orden_id1",
                principalTable: "orden_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orden_mecanico_usuario_mecanico_id1",
                table: "orden_mecanico",
                column: "mecanico_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orden_servicio_estado_orden_estado_id1",
                table: "orden_servicio",
                column: "estado_id1",
                principalTable: "estado_orden",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orden_servicio_usuario_recepcionista_id1",
                table: "orden_servicio",
                column: "recepcionista_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orden_servicio_vehiculo_vehiculo_id1",
                table: "orden_servicio",
                column: "vehiculo_id1",
                principalTable: "vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orden_tipo_servicio_orden_servicio_orden_id1",
                table: "orden_tipo_servicio",
                column: "orden_id1",
                principalTable: "orden_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orden_tipo_servicio_tipo_servicio_tipo_servicio_id1",
                table: "orden_tipo_servicio",
                column: "tipo_servicio_id1",
                principalTable: "tipo_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_repuesto_categoria_repuesto_categoria_id1",
                table: "repuesto",
                column: "categoria_id1",
                principalTable: "categoria_repuesto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_repuesto_unidad_medida_unidad_id1",
                table: "repuesto",
                column: "unidad_id1",
                principalTable: "unidad_medida",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_repuesto_proveedor_proveedor_proveedor_id1",
                table: "repuesto_proveedor",
                column: "proveedor_id1",
                principalTable: "proveedor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_repuesto_proveedor_repuesto_repuesto_id1",
                table: "repuesto_proveedor",
                column: "repuesto_id1",
                principalTable: "repuesto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tarea_mecanico_orden_servicio_orden_id1",
                table: "tarea_mecanico",
                column: "orden_id1",
                principalTable: "orden_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tarea_mecanico_tipo_servicio_tipo_servicio_id1",
                table: "tarea_mecanico",
                column: "tipo_servicio_id1",
                principalTable: "tipo_servicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tarea_mecanico_usuario_mecanico_id1",
                table: "tarea_mecanico",
                column: "mecanico_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_rol_id1",
                table: "usuario",
                column: "rol_id1",
                principalTable: "rol",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
