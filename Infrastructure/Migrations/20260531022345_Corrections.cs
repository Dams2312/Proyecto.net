using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Corrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria_repuesto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_repuesto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombres = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    num_documento = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    tipo_documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_registro = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estado_factura",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_factura", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estado_orden",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_orden", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "garantia",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    fecha_vencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    condiciones = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garantia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marca_vehiculo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca_vehiculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "metodo_pago",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metodo_pago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_servicio",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    dias_estimados = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_servicio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unidad_medida",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    abreviatura = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidad_medida", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente_correo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    principal = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_correo", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_correo_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente_direccion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    direccion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    principal = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_direccion", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_direccion_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente_telefono",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    tipo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_telefono", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_telefono_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modelo_vehiculo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    marca_id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    anio_desde = table.Column<short>(type: "smallint", nullable: true),
                    anio_hasta = table.Column<short>(type: "smallint", nullable: true),
                    marca_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelo_vehiculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_modelo_vehiculo_marca_vehiculo_marca_id1",
                        column: x => x.marca_id1,
                        principalTable: "marca_vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    pais_id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_pais_id",
                        column: x => x.pais_id,
                        principalTable: "pais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombres = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rol_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_rol_rol_id1",
                        column: x => x.rol_id1,
                        principalTable: "rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "repuesto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    precio_unitario = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    stock_actual = table.Column<int>(type: "integer", nullable: false),
                    stock_minimo = table.Column<int>(type: "integer", nullable: false),
                    categoria_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unidad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    categoria_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    unidad_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repuesto", x => x.id);
                    table.ForeignKey(
                        name: "FK_repuesto_categoria_repuesto_categoria_id1",
                        column: x => x.categoria_id1,
                        principalTable: "categoria_repuesto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_repuesto_unidad_medida_unidad_id1",
                        column: x => x.unidad_id1,
                        principalTable: "unidad_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehiculo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    modelo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vin = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    placa = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    anio = table.Column<int>(type: "integer", nullable: false),
                    color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehiculo_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vehiculo_modelo_vehiculo_modelo_id",
                        column: x => x.modelo_id,
                        principalTable: "modelo_vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    departamento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "auditoria",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entidad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entidad = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tipo_accion = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    datos_anteriores = table.Column<string>(type: "json", nullable: true),
                    datos_nuevos = table.Column<string>(type: "json", nullable: true),
                    ip_origen = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_auditoria_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cita",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehiculo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_servicio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    recepcionista_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_cita = table.Column<DateOnly>(type: "date", nullable: false),
                    hora_inicio = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    hora_fin = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    observaciones = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cita", x => x.id);
                    table.ForeignKey(
                        name: "FK_cita_tipo_servicio_tipo_servicio_id",
                        column: x => x.tipo_servicio_id,
                        principalTable: "tipo_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cita_usuario_recepcionista_id",
                        column: x => x.recepcionista_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cita_vehiculo_vehiculo_id",
                        column: x => x.vehiculo_id,
                        principalTable: "vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historial_kilometraje",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehiculo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kilometraje = table.Column<int>(type: "integer", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    fuente = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vehiculo_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_kilometraje", x => x.id);
                    table.ForeignKey(
                        name: "FK_historial_kilometraje_vehiculo_vehiculo_id1",
                        column: x => x.vehiculo_id1,
                        principalTable: "vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    nit = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ciudad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.id);
                    table.ForeignKey(
                        name: "fk_proveedor_ciudad",
                        column: x => x.ciudad_id,
                        principalTable: "ciudad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orden_servicio",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehiculo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    recepcionista_id = table.Column<Guid>(type: "uuid", nullable: false),
                    estado_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kilometraje_ingreso = table.Column<int>(type: "integer", nullable: false),
                    fecha_ingreso = table.Column<DateOnly>(type: "date", nullable: false),
                    fecha_estimada = table.Column<DateOnly>(type: "date", nullable: true),
                    fecha_entrega_real = table.Column<DateOnly>(type: "date", nullable: true),
                    cita_id = table.Column<Guid>(type: "uuid", nullable: true),
                    observaciones = table.Column<string>(type: "text", nullable: false),
                    estado_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    recepcionista_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    vehiculo_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_servicio", x => x.id);
                    table.ForeignKey(
                        name: "FK_orden_servicio_cita_cita_id",
                        column: x => x.cita_id,
                        principalTable: "cita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_estado_orden_estado_id1",
                        column: x => x.estado_id1,
                        principalTable: "estado_orden",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_usuario_recepcionista_id1",
                        column: x => x.recepcionista_id1,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_vehiculo_vehiculo_id1",
                        column: x => x.vehiculo_id1,
                        principalTable: "vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_compra = table.Column<DateOnly>(type: "date", nullable: false),
                    proveedor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    observaciones = table.Column<string>(type: "text", nullable: false),
                    total = table.Column<decimal>(type: "numeric(14,2)", nullable: false),
                    proveedor_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    usuario_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra", x => x.id);
                    table.ForeignKey(
                        name: "FK_compra_proveedor_proveedor_id1",
                        column: x => x.proveedor_id1,
                        principalTable: "proveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compra_usuario_usuario_id1",
                        column: x => x.usuario_id1,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "repuesto_proveedor",
                columns: table => new
                {
                    repuesto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    proveedor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    precio_compra = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    principal = table.Column<bool>(type: "boolean", nullable: false),
                    proveedor_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    repuesto_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repuesto_proveedor", x => new { x.repuesto_id, x.proveedor_id });
                    table.ForeignKey(
                        name: "FK_repuesto_proveedor_proveedor_proveedor_id1",
                        column: x => x.proveedor_id1,
                        principalTable: "proveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_repuesto_proveedor_repuesto_repuesto_id1",
                        column: x => x.repuesto_id1,
                        principalTable: "repuesto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalle_orden",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orden_id = table.Column<Guid>(type: "uuid", nullable: false),
                    repuesto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    precio_snapshot = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    orden_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    repuesto_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_orden", x => x.id);
                    table.ForeignKey(
                        name: "FK_detalle_orden_orden_servicio_orden_id1",
                        column: x => x.orden_id1,
                        principalTable: "orden_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_orden_repuesto_repuesto_id1",
                        column: x => x.repuesto_id1,
                        principalTable: "repuesto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orden_id = table.Column<Guid>(type: "uuid", nullable: false),
                    estado_fact_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    costo_repuestos = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    mano_de_obra = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    impuesto_pct = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    descuento = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    total = table.Column<decimal>(type: "numeric(14,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura", x => x.id);
                    table.ForeignKey(
                        name: "FK_factura_estado_factura_estado_fact_id",
                        column: x => x.estado_fact_id,
                        principalTable: "estado_factura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_factura_orden_servicio_orden_id",
                        column: x => x.orden_id,
                        principalTable: "orden_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_factura_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historial_estado_orden",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orden_id = table.Column<Guid>(type: "uuid", nullable: false),
                    estado_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_cambio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    estado_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    orden_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    usuario_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_estado_orden", x => x.id);
                    table.ForeignKey(
                        name: "FK_historial_estado_orden_estado_orden_estado_id1",
                        column: x => x.estado_id1,
                        principalTable: "estado_orden",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_historial_estado_orden_orden_servicio_orden_id1",
                        column: x => x.orden_id1,
                        principalTable: "orden_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_historial_estado_orden_usuario_usuario_id1",
                        column: x => x.usuario_id1,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nota_orden",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orden_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_nota = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    contenido = table.Column<string>(type: "text", nullable: false),
                    orden_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    usuario_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nota_orden", x => x.id);
                    table.ForeignKey(
                        name: "FK_nota_orden_orden_servicio_orden_id1",
                        column: x => x.orden_id1,
                        principalTable: "orden_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nota_orden_usuario_usuario_id1",
                        column: x => x.usuario_id1,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orden_mecanico",
                columns: table => new
                {
                    orden_id = table.Column<Guid>(type: "uuid", nullable: false),
                    mecanico_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_asignacion = table.Column<DateOnly>(type: "date", nullable: false),
                    mecanico_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    orden_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_mecanico", x => new { x.orden_id, x.mecanico_id });
                    table.ForeignKey(
                        name: "FK_orden_mecanico_orden_servicio_orden_id1",
                        column: x => x.orden_id1,
                        principalTable: "orden_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_mecanico_usuario_mecanico_id1",
                        column: x => x.mecanico_id1,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orden_tipo_servicio",
                columns: table => new
                {
                    orden_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_servicio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    orden_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    tipo_servicio_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_tipo_servicio", x => new { x.orden_id, x.tipo_servicio_id });
                    table.ForeignKey(
                        name: "FK_orden_tipo_servicio_orden_servicio_orden_id1",
                        column: x => x.orden_id1,
                        principalTable: "orden_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_tipo_servicio_tipo_servicio_tipo_servicio_id1",
                        column: x => x.tipo_servicio_id1,
                        principalTable: "tipo_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tarea_mecanico",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orden_id = table.Column<Guid>(type: "uuid", nullable: false),
                    mecanico_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_servicio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    horas_trabajadas = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    costo_hora = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    mecanico_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    orden_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    tipo_servicio_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarea_mecanico", x => x.id);
                    table.ForeignKey(
                        name: "FK_tarea_mecanico_orden_servicio_orden_id1",
                        column: x => x.orden_id1,
                        principalTable: "orden_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tarea_mecanico_tipo_servicio_tipo_servicio_id1",
                        column: x => x.tipo_servicio_id1,
                        principalTable: "tipo_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tarea_mecanico_usuario_mecanico_id1",
                        column: x => x.mecanico_id1,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalle_compra",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    compra_id = table.Column<Guid>(type: "uuid", nullable: false),
                    repuesto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    compra_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    repuesto_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_compra", x => x.id);
                    table.ForeignKey(
                        name: "FK_detalle_compra_compra_compra_id1",
                        column: x => x.compra_id1,
                        principalTable: "compra",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_compra_repuesto_repuesto_id1",
                        column: x => x.repuesto_id1,
                        principalTable: "repuesto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "log_inventario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    repuesto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    stock_resultante = table.Column<int>(type: "integer", nullable: false),
                    tipo_movimiento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    orden_id = table.Column<Guid>(type: "uuid", nullable: false),
                    compra_id = table.Column<Guid>(type: "uuid", nullable: false),
                    motivo = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log_inventario", x => x.id);
                    table.ForeignKey(
                        name: "FK_log_inventario_compra_compra_id",
                        column: x => x.compra_id,
                        principalTable: "compra",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_log_inventario_orden_servicio_orden_id",
                        column: x => x.orden_id,
                        principalTable: "orden_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_log_inventario_repuesto_repuesto_id",
                        column: x => x.repuesto_id,
                        principalTable: "repuesto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_log_inventario_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pago",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    factura_id = table.Column<Guid>(type: "uuid", nullable: false),
                    metodo_pago_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    monto = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    referencia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pago", x => x.id);
                    table.ForeignKey(
                        name: "FK_pago_factura_factura_id",
                        column: x => x.factura_id,
                        principalTable: "factura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pago_metodo_pago_metodo_pago_id",
                        column: x => x.metodo_pago_id,
                        principalTable: "metodo_pago",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "idx_audit_fecha",
                table: "auditoria",
                column: "fecha");

            migrationBuilder.CreateIndex(
                name: "idx_audit_usuario",
                table: "auditoria",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "uq_categoria_repuesto_nombre",
                table: "categoria_repuesto",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cita_fecha",
                table: "cita",
                column: "fecha_cita");

            migrationBuilder.CreateIndex(
                name: "idx_cita_vehiculo",
                table: "cita",
                column: "vehiculo_id");

            migrationBuilder.CreateIndex(
                name: "IX_cita_recepcionista_id",
                table: "cita",
                column: "recepcionista_id");

            migrationBuilder.CreateIndex(
                name: "IX_cita_tipo_servicio_id",
                table: "cita",
                column: "tipo_servicio_id");

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_departamento_id",
                table: "ciudad",
                column: "departamento_id");

            migrationBuilder.CreateIndex(
                name: "uq_cliente_num_documento",
                table: "cliente",
                column: "num_documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_correo_cliente_id",
                table: "cliente_correo",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_direccion_cliente_id",
                table: "cliente_direccion",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_telefono_cliente_id",
                table: "cliente_telefono",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_compra_proveedor_id1",
                table: "compra",
                column: "proveedor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_compra_usuario_id1",
                table: "compra",
                column: "usuario_id1");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_pais_id",
                table: "departamento",
                column: "pais_id");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_compra_compra_id1",
                table: "detalle_compra",
                column: "compra_id1");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_compra_repuesto_id1",
                table: "detalle_compra",
                column: "repuesto_id1");

            migrationBuilder.CreateIndex(
                name: "uq_dc_compra_repuesto",
                table: "detalle_compra",
                columns: new[] { "compra_id", "repuesto_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_do_orden",
                table: "detalle_orden",
                column: "orden_id");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_orden_id1",
                table: "detalle_orden",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_repuesto_id1",
                table: "detalle_orden",
                column: "repuesto_id1");

            migrationBuilder.CreateIndex(
                name: "uq_do_orden_repuesto",
                table: "detalle_orden",
                columns: new[] { "orden_id", "repuesto_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_estado_factura_nombre",
                table: "estado_factura",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_estado_orden_nombre",
                table: "estado_orden",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_factura_estado_fact_id",
                table: "factura",
                column: "estado_fact_id");

            migrationBuilder.CreateIndex(
                name: "IX_factura_usuario_id",
                table: "factura",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "uq_factura_orden",
                table: "factura",
                column: "orden_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_heo_orden",
                table: "historial_estado_orden",
                column: "orden_id");

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
                name: "idx_hkm_vehiculo",
                table: "historial_kilometraje",
                column: "vehiculo_id");

            migrationBuilder.CreateIndex(
                name: "IX_historial_kilometraje_vehiculo_id1",
                table: "historial_kilometraje",
                column: "vehiculo_id1");

            migrationBuilder.CreateIndex(
                name: "idx_log_fecha",
                table: "log_inventario",
                column: "fecha");

            migrationBuilder.CreateIndex(
                name: "idx_log_repuesto",
                table: "log_inventario",
                column: "repuesto_id");

            migrationBuilder.CreateIndex(
                name: "IX_log_inventario_compra_id",
                table: "log_inventario",
                column: "compra_id");

            migrationBuilder.CreateIndex(
                name: "IX_log_inventario_orden_id",
                table: "log_inventario",
                column: "orden_id");

            migrationBuilder.CreateIndex(
                name: "IX_log_inventario_usuario_id",
                table: "log_inventario",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "uq_marca_vehiculo_nombre",
                table: "marca_vehiculo",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_metodo_pago_nombre",
                table: "metodo_pago",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_modelo_vehiculo_marca_id1",
                table: "modelo_vehiculo",
                column: "marca_id1");

            migrationBuilder.CreateIndex(
                name: "IX_nota_orden_orden_id1",
                table: "nota_orden",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_nota_orden_usuario_id1",
                table: "nota_orden",
                column: "usuario_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_mecanico_mecanico_id1",
                table: "orden_mecanico",
                column: "mecanico_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_mecanico_orden_id1",
                table: "orden_mecanico",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "idx_orden_estado",
                table: "orden_servicio",
                column: "estado_id");

            migrationBuilder.CreateIndex(
                name: "idx_orden_vehiculo",
                table: "orden_servicio",
                column: "vehiculo_id");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_cita_id",
                table: "orden_servicio",
                column: "cita_id");

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
                name: "IX_orden_tipo_servicio_orden_id1",
                table: "orden_tipo_servicio",
                column: "orden_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orden_tipo_servicio_tipo_servicio_id1",
                table: "orden_tipo_servicio",
                column: "tipo_servicio_id1");

            migrationBuilder.CreateIndex(
                name: "idx_pago_factura",
                table: "pago",
                column: "factura_id");

            migrationBuilder.CreateIndex(
                name: "IX_pago_metodo_pago_id",
                table: "pago",
                column: "metodo_pago_id");

            migrationBuilder.CreateIndex(
                name: "uq_pais_codigo",
                table: "pais",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_ciudad_id",
                table: "proveedor",
                column: "ciudad_id");

            migrationBuilder.CreateIndex(
                name: "uq_proveedor_nit",
                table: "proveedor",
                column: "nit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_categoria_id",
                table: "repuesto",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_categoria_id1",
                table: "repuesto",
                column: "categoria_id1");

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_codigo",
                table: "repuesto",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_unidad_id1",
                table: "repuesto",
                column: "unidad_id1");

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_proveedor_proveedor_id1",
                table: "repuesto_proveedor",
                column: "proveedor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_repuesto_proveedor_repuesto_id1",
                table: "repuesto_proveedor",
                column: "repuesto_id1");

            migrationBuilder.CreateIndex(
                name: "uq_rol_nombre",
                table: "rol",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_tarea_mecanico",
                table: "tarea_mecanico",
                column: "mecanico_id");

            migrationBuilder.CreateIndex(
                name: "idx_tarea_orden",
                table: "tarea_mecanico",
                column: "orden_id");

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
                name: "uq_tipo_servicio_nombre",
                table: "tipo_servicio",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unidad_medida_abreviatura",
                table: "unidad_medida",
                column: "abreviatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unidad_medida_nombre",
                table: "unidad_medida",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_correo",
                table: "usuario",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_id1",
                table: "usuario",
                column: "rol_id1");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_cliente_id",
                table: "vehiculo",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_modelo_id",
                table: "vehiculo",
                column: "modelo_id");

            migrationBuilder.CreateIndex(
                name: "uq_vehiculo_placa",
                table: "vehiculo",
                column: "placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_vehiculo_vin",
                table: "vehiculo",
                column: "vin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auditoria");

            migrationBuilder.DropTable(
                name: "cliente_correo");

            migrationBuilder.DropTable(
                name: "cliente_direccion");

            migrationBuilder.DropTable(
                name: "cliente_telefono");

            migrationBuilder.DropTable(
                name: "detalle_compra");

            migrationBuilder.DropTable(
                name: "detalle_orden");

            migrationBuilder.DropTable(
                name: "garantia");

            migrationBuilder.DropTable(
                name: "historial_estado_orden");

            migrationBuilder.DropTable(
                name: "historial_kilometraje");

            migrationBuilder.DropTable(
                name: "log_inventario");

            migrationBuilder.DropTable(
                name: "nota_orden");

            migrationBuilder.DropTable(
                name: "orden_mecanico");

            migrationBuilder.DropTable(
                name: "orden_tipo_servicio");

            migrationBuilder.DropTable(
                name: "pago");

            migrationBuilder.DropTable(
                name: "repuesto_proveedor");

            migrationBuilder.DropTable(
                name: "tarea_mecanico");

            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "metodo_pago");

            migrationBuilder.DropTable(
                name: "repuesto");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "estado_factura");

            migrationBuilder.DropTable(
                name: "orden_servicio");

            migrationBuilder.DropTable(
                name: "categoria_repuesto");

            migrationBuilder.DropTable(
                name: "unidad_medida");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "cita");

            migrationBuilder.DropTable(
                name: "estado_orden");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "tipo_servicio");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "vehiculo");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "modelo_vehiculo");

            migrationBuilder.DropTable(
                name: "marca_vehiculo");
        }
    }
}
