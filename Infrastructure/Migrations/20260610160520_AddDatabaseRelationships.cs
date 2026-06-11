using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex("IX_modelo_vehiculo_marca_id", "modelo_vehiculo", "marca_id");
            migrationBuilder.CreateIndex("IX_usuario_rol_id", "usuario", "rol_id");
            migrationBuilder.CreateIndex("IX_repuesto_unidad_id", "repuesto", "unidad_id");
            migrationBuilder.CreateIndex("IX_orden_servicio_recepcionista_id", "orden_servicio", "recepcionista_id");
            migrationBuilder.CreateIndex("IX_compra_proveedor_id", "compra", "proveedor_id");
            migrationBuilder.CreateIndex("IX_compra_usuario_id", "compra", "usuario_id");
            migrationBuilder.CreateIndex("IX_historial_estado_orden_estado_id", "historial_estado_orden", "estado_id");
            migrationBuilder.CreateIndex("IX_historial_estado_orden_usuario_id", "historial_estado_orden", "usuario_id");
            migrationBuilder.CreateIndex("IX_nota_orden_orden_id", "nota_orden", "orden_id");
            migrationBuilder.CreateIndex("IX_nota_orden_usuario_id", "nota_orden", "usuario_id");
            migrationBuilder.CreateIndex("IX_tarea_mecanico_tipo_servicio_id", "tarea_mecanico", "tipo_servicio_id");

            migrationBuilder.AddForeignKey("FK_modelo_vehiculo_marca_vehiculo_marca_id", "modelo_vehiculo", "marca_id", "marca_vehiculo", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_usuario_rol_rol_id", "usuario", "rol_id", "rol", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_repuesto_categoria_repuesto_categoria_id", "repuesto", "categoria_id", "categoria_repuesto", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_repuesto_unidad_medida_unidad_id", "repuesto", "unidad_id", "unidad_medida", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_historial_kilometraje_vehiculo_vehiculo_id", "historial_kilometraje", "vehiculo_id", "vehiculo", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_orden_servicio_estado_orden_estado_id", "orden_servicio", "estado_id", "estado_orden", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_orden_servicio_usuario_recepcionista_id", "orden_servicio", "recepcionista_id", "usuario", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_orden_servicio_vehiculo_vehiculo_id", "orden_servicio", "vehiculo_id", "vehiculo", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_compra_proveedor_proveedor_id", "compra", "proveedor_id", "proveedor", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_compra_usuario_usuario_id", "compra", "usuario_id", "usuario", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_repuesto_proveedor_proveedor_proveedor_id", "repuesto_proveedor", "proveedor_id", "proveedor", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_repuesto_proveedor_repuesto_repuesto_id", "repuesto_proveedor", "repuesto_id", "repuesto", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_detalle_orden_orden_servicio_orden_id", "detalle_orden", "orden_id", "orden_servicio", principalColumn: "id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey("FK_detalle_orden_repuesto_repuesto_id", "detalle_orden", "repuesto_id", "repuesto", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_historial_estado_orden_estado_orden_estado_id", "historial_estado_orden", "estado_id", "estado_orden", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_historial_estado_orden_orden_servicio_orden_id", "historial_estado_orden", "orden_id", "orden_servicio", principalColumn: "id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey("FK_historial_estado_orden_usuario_usuario_id", "historial_estado_orden", "usuario_id", "usuario", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_nota_orden_orden_servicio_orden_id", "nota_orden", "orden_id", "orden_servicio", principalColumn: "id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey("FK_nota_orden_usuario_usuario_id", "nota_orden", "usuario_id", "usuario", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_orden_mecanico_orden_servicio_orden_id", "orden_mecanico", "orden_id", "orden_servicio", principalColumn: "id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey("FK_orden_mecanico_usuario_mecanico_id", "orden_mecanico", "mecanico_id", "usuario", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_orden_tipo_servicio_orden_servicio_orden_id", "orden_tipo_servicio", "orden_id", "orden_servicio", principalColumn: "id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey("FK_orden_tipo_servicio_tipo_servicio_tipo_servicio_id", "orden_tipo_servicio", "tipo_servicio_id", "tipo_servicio", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_tarea_mecanico_orden_servicio_orden_id", "tarea_mecanico", "orden_id", "orden_servicio", principalColumn: "id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey("FK_tarea_mecanico_tipo_servicio_tipo_servicio_id", "tarea_mecanico", "tipo_servicio_id", "tipo_servicio", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_tarea_mecanico_usuario_mecanico_id", "tarea_mecanico", "mecanico_id", "usuario", principalColumn: "id", onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey("FK_detalle_compra_compra_compra_id", "detalle_compra", "compra_id", "compra", principalColumn: "id", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey("FK_detalle_compra_repuesto_repuesto_id", "detalle_compra", "repuesto_id", "repuesto", principalColumn: "id", onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_detalle_compra_repuesto_repuesto_id", "detalle_compra");
            migrationBuilder.DropForeignKey("FK_detalle_compra_compra_compra_id", "detalle_compra");
            migrationBuilder.DropForeignKey("FK_tarea_mecanico_usuario_mecanico_id", "tarea_mecanico");
            migrationBuilder.DropForeignKey("FK_tarea_mecanico_tipo_servicio_tipo_servicio_id", "tarea_mecanico");
            migrationBuilder.DropForeignKey("FK_tarea_mecanico_orden_servicio_orden_id", "tarea_mecanico");
            migrationBuilder.DropForeignKey("FK_orden_tipo_servicio_tipo_servicio_tipo_servicio_id", "orden_tipo_servicio");
            migrationBuilder.DropForeignKey("FK_orden_tipo_servicio_orden_servicio_orden_id", "orden_tipo_servicio");
            migrationBuilder.DropForeignKey("FK_orden_mecanico_usuario_mecanico_id", "orden_mecanico");
            migrationBuilder.DropForeignKey("FK_orden_mecanico_orden_servicio_orden_id", "orden_mecanico");
            migrationBuilder.DropForeignKey("FK_nota_orden_usuario_usuario_id", "nota_orden");
            migrationBuilder.DropForeignKey("FK_nota_orden_orden_servicio_orden_id", "nota_orden");
            migrationBuilder.DropForeignKey("FK_historial_estado_orden_usuario_usuario_id", "historial_estado_orden");
            migrationBuilder.DropForeignKey("FK_historial_estado_orden_orden_servicio_orden_id", "historial_estado_orden");
            migrationBuilder.DropForeignKey("FK_historial_estado_orden_estado_orden_estado_id", "historial_estado_orden");
            migrationBuilder.DropForeignKey("FK_detalle_orden_repuesto_repuesto_id", "detalle_orden");
            migrationBuilder.DropForeignKey("FK_detalle_orden_orden_servicio_orden_id", "detalle_orden");
            migrationBuilder.DropForeignKey("FK_repuesto_proveedor_repuesto_repuesto_id", "repuesto_proveedor");
            migrationBuilder.DropForeignKey("FK_repuesto_proveedor_proveedor_proveedor_id", "repuesto_proveedor");
            migrationBuilder.DropForeignKey("FK_compra_usuario_usuario_id", "compra");
            migrationBuilder.DropForeignKey("FK_compra_proveedor_proveedor_id", "compra");
            migrationBuilder.DropForeignKey("FK_orden_servicio_vehiculo_vehiculo_id", "orden_servicio");
            migrationBuilder.DropForeignKey("FK_orden_servicio_usuario_recepcionista_id", "orden_servicio");
            migrationBuilder.DropForeignKey("FK_orden_servicio_estado_orden_estado_id", "orden_servicio");
            migrationBuilder.DropForeignKey("FK_historial_kilometraje_vehiculo_vehiculo_id", "historial_kilometraje");
            migrationBuilder.DropForeignKey("FK_repuesto_unidad_medida_unidad_id", "repuesto");
            migrationBuilder.DropForeignKey("FK_repuesto_categoria_repuesto_categoria_id", "repuesto");
            migrationBuilder.DropForeignKey("FK_usuario_rol_rol_id", "usuario");
            migrationBuilder.DropForeignKey("FK_modelo_vehiculo_marca_vehiculo_marca_id", "modelo_vehiculo");

            migrationBuilder.DropIndex("IX_tarea_mecanico_tipo_servicio_id", "tarea_mecanico");
            migrationBuilder.DropIndex("IX_nota_orden_usuario_id", "nota_orden");
            migrationBuilder.DropIndex("IX_nota_orden_orden_id", "nota_orden");
            migrationBuilder.DropIndex("IX_historial_estado_orden_usuario_id", "historial_estado_orden");
            migrationBuilder.DropIndex("IX_historial_estado_orden_estado_id", "historial_estado_orden");
            migrationBuilder.DropIndex("IX_compra_usuario_id", "compra");
            migrationBuilder.DropIndex("IX_compra_proveedor_id", "compra");
            migrationBuilder.DropIndex("IX_orden_servicio_recepcionista_id", "orden_servicio");
            migrationBuilder.DropIndex("IX_repuesto_unidad_id", "repuesto");
            migrationBuilder.DropIndex("IX_usuario_rol_id", "usuario");
            migrationBuilder.DropIndex("IX_modelo_vehiculo_marca_id", "modelo_vehiculo");
        }
    }
}
