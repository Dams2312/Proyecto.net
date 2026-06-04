

---

## 📋 Resumen Ejecutivo

**AutoTallerManager** nació para resolver un problema real en la operación de talleres automotrices: la dispersión de información crítica entre registros en papel, hojas de cálculo y sistemas desconectados, lo que genera pérdida de trazabilidad, errores en inventario, facturación tardía y una experiencia deficiente para el cliente.

El proyecto consiste en un **backend RESTful de nivel producción** desarrollado sobre **.NET 10 / ASP.NET Core**, que centraliza y automatiza todos los procesos operativos del taller: desde la recepción del vehículo hasta la entrega con factura, pasando por la gestión de mecánicos, repuestos, garantías y auditoría. Está diseñado para integrarse con cualquier frontend web o aplicación móvil a través de su API bien documentada.

### ¿Qué problema resuelve?

| Problema actual | Solución implementada |
|---|---|
| Sin trazabilidad de qué mecánico hizo qué trabajo | Registro de tareas por mecánico con horas y costo por hora |
| Inventario de repuestos sin control | Stock con mínimos, log de movimientos y validación en tiempo real |
| Facturas calculadas manualmente | Cálculo automático: repuestos + mano de obra + impuesto − descuento |
| Sin historial del vehículo | Historial de kilometraje vinculado a cada orden |
| Acceso sin restricciones al sistema | Roles diferenciados con JWT: Admin, Mecánico, Recepcionista |
| Sin registro de cambios o responsables | Auditoría completa con IP, usuario, datos anteriores y nuevos |
| Procesos duplicados entre áreas | Un solo sistema para recepción, taller, inventario y finanzas |

---

## 📑 Tabla de Contenidos

- [Resumen Ejecutivo](#-resumen-ejecutivo)
- [Objetivos del Proyecto](#-objetivos-del-proyecto)
- [Lo que se construyó](#-lo-que-se-construyó)
- [Arquitectura](#-arquitectura)
- [Tecnologías](#-tecnologías)
- [Modelo de Dominio](#-modelo-de-dominio)
- [Reglas de Negocio Implementadas](#-reglas-de-negocio-implementadas)
- [Endpoints de la API](#-endpoints-de-la-api)
- [Seguridad](#-seguridad)
- [Configuración y Despliegue](#%EF%B8%8F-configuración-y-despliegue)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Estado del Proyecto y Próximos Pasos](#-estado-del-proyecto-y-próximos-pasos)

---

## 🎯 Objetivos del Proyecto

### Objetivo General
Desarrollar un sistema backend robusto, seguro y escalable que sirva como núcleo tecnológico para la operación de un taller automotriz moderno, eliminando procesos manuales y garantizando la trazabilidad completa de cada servicio.

### Objetivos Específicos

1. **Centralizar la gestión de clientes y vehículos**, con soporte para múltiples datos de contacto (teléfonos, correos, direcciones) y el historial completo de cada vehículo identificado por VIN y placa.

2. **Automatizar el flujo de órdenes de servicio**, desde la cita previa hasta el cierre con factura, incluyendo asignación de mecánicos, tipos de servicio, notas internas y cambios de estado con historial.

3. **Controlar el inventario de repuestos en tiempo real**, validando stock antes de cada asignación, registrando cada movimiento y alertando cuando se alcanza el stock mínimo.

4. **Generar facturación automática y precisa**, calculando el total como la suma de costo de repuestos más mano de obra, aplicando porcentaje de impuesto y descuentos, vinculada a la orden correspondiente.

5. **Garantizar la seguridad y el control de acceso** mediante autenticación JWT y autorización basada en roles, asegurando que cada usuario solo pueda realizar las acciones correspondientes a su función.

6. **Mantener trazabilidad completa** de todas las operaciones del sistema a través de un módulo de auditoría que registra quién hizo qué, cuándo y desde qué IP.

7. **Construir sobre una arquitectura limpia y mantenible** que facilite la incorporación de nuevas funcionalidades y la integración con aplicaciones frontend o móviles.

---

## 🏗 Lo que se construyó

### Módulos implementados

#### 1. Gestión Geográfica
Catálogos de países, departamentos y ciudades que soportan el registro de direcciones de clientes y proveedores, permitiendo futuros análisis de cobertura geográfica.

#### 2. Usuarios y Roles
Sistema completo de gestión de usuarios del sistema con código interno, nombre, correo, contraseña hasheada, fechas de alta/baja y rol asignado. Soporte para desactivación de cuentas sin eliminación (baja lógica).

#### 3. Clientes
Entidad `Customer` con tipo y número de documento (cédula, NIT, pasaporte), estado activo/inactivo y fecha de registro. Cada cliente puede tener múltiples direcciones, correos electrónicos y números de teléfono como entidades independientes, lo que permite una gestión de contactos flexible y escalable.

#### 4. Vehículos
Entidad `Vehicle` vinculada al cliente con VIN único, placa, año, color y estado. La marca y el modelo son catálogos independientes (`VehicleMake` → `VehicleModel`) para evitar datos inconsistentes. El sistema registra automáticamente el historial de kilometraje (`MileageHistory`) en cada ingreso al taller.

#### 5. Citas
Módulo de agendamiento previo (`Appointment`) que puede vincularse opcionalmente a una orden de servicio, permitiendo al taller planificar la carga de trabajo con antelación.

#### 6. Órdenes de Servicio
Módulo central del sistema. Cada `OrderService` registra:
- El vehículo y el recepcionista que recibe
- El kilometraje de ingreso
- Fechas de ingreso, estimada de entrega y entrega real (con validación de consistencia entre fechas)
- Observaciones generales
- La cita previa vinculada (si existe)

Cada orden puede tener:
- **Tipos de servicio** (`OrderServiceType`): mantenimiento preventivo, reparación, diagnóstico, etc.
- **Mecánicos asignados** (`OrderMechanic`): múltiples mecánicos por orden
- **Tareas del mecánico** (`MechanicTask`): descripción, horas trabajadas, costo por hora, tipo de servicio, fechas de inicio y fin
- **Repuestos utilizados** (`OrderDetail`): piezas con cantidades y precios unitarios
- **Historial de estados** (`OrderStatusHistory`): cada cambio de estado queda registrado
- **Notas internas** (`OrderNote`): comentarios del equipo visibles solo en el sistema

#### 7. Inventario de Repuestos
Entidad `SparePart` con código único, descripción, precio unitario, stock actual, stock mínimo, categoría y unidad de medida. El sistema valida en el constructor que el stock actual nunca sea menor al stock mínimo, y en cada actualización se reaplica esta regla de negocio. Cada movimiento de inventario queda registrado en `InventoryLog`.

#### 8. Proveedores y Compras
Gestión de proveedores con soporte para múltiples repuestos por proveedor (`SparePartSupplier`). Las compras se registran con su detalle por ítem (`Purchase` → `PurchaseDetail`), actualizando el inventario.

#### 9. Facturación
La entidad `Invoice` calcula el total a partir de cuatro campos independientes: `CostoRepuestos`, `ManoDeObra`, `ImpuestoPct` (porcentaje de impuesto) y `Descuento`. Vinculada a la orden de servicio y al usuario que la genera. Soporta múltiples estados de factura (`InvoiceStatus`).

#### 10. Pagos
Registro de pagos por factura con soporte para múltiples métodos de pago (`PaymentMethod`), lo que permite pagos parciales o en combinación de métodos.

#### 11. Garantías
El módulo `Warranty` vincula una garantía a una orden, tipo de servicio y mecánico responsable, con fecha de inicio, fecha de vencimiento (validada contra la fecha de inicio), estado y condiciones. Permite al taller ofrecer garantías formales sobre sus servicios.

#### 12. Auditoría
Cada operación importante genera un registro en `Audit` con: ID del usuario responsable, ID de la entidad afectada, nombre de la entidad, tipo de acción (crear/modificar/eliminar), fecha/hora, datos anteriores (JSON), datos nuevos (JSON) e IP de origen. Esto garantiza un rastro completo e inmutable de toda la actividad del sistema.

---

## 🏛 Arquitectura

El sistema implementa **Arquitectura Hexagonal (Ports & Adapters)** con cuatro capas perfectamente delimitadas:

```
┌──────────────────────────────────────────────────────────┐
│                       API Layer                         │
│  Controllers · DTOs · Swagger · JWT Middleware          │
│                   ASP.NET Core 10                        │
├──────────────────────────────────────────────────────────┤
│                  Application Layer                      │
│  Use Case Interfaces · IUnitOfWork · IRepository<T>     │
│                       MediatR                           │
├──────────────────────────────────────────────────────────┤
│                Infrastructure Layer                     │
│  EF Core · Repositories · Unit of Work · Mapster        │
│         AppDbContext · Fluent API Configurations        │
├──────────────────────────────────────────────────────────┤
│                    Domain Layer                         │
│   Entities (sealed) · Value Objects · Business Rules   │
│               No external dependencies                  │
└──────────────────────────────────────────────────────────┘
```

### Decisiones de diseño destacadas

**Entidades selladas (`sealed`)**: todas las entidades del dominio son `sealed`, lo que previene herencia no controlada y hace explícita la intención de que el dominio no se extienda arbitrariamente.

**Value Objects**: cada campo de cada entidad está encapsulado en un Value Object propio (por ejemplo `CustomerNames`, `VehicleVin`, `SparePartStockActual`). Esto garantiza que las validaciones estén en el lugar correcto —el dominio— y no dispersas en validaciones de controlador o de base de datos.

**Constructores con validación**: ninguna entidad puede crearse en estado inválido. Los constructores lanzan excepciones descriptivas (`ArgumentNullException`, `ArgumentException`) ante datos inconsistentes, como fechas estimadas anteriores al ingreso, o stock actual menor al mínimo.

**Unit of Work**: el `EfUnitOfWork` agrupa los 38 repositorios del sistema y garantiza que múltiples operaciones relacionadas (por ejemplo, crear una orden, asignar mecánicos y descontar repuestos) se ejecuten en una sola transacción atómica mediante `CommitAsync()`.

**Repository Pattern**: cada entidad tiene su propio repositorio con métodos especializados para los filtros y búsquedas más frecuentes, evitando queries genéricas ineficientes.

---

## 🛠 Tecnologías

| Tecnología | Versión | Rol en el sistema |
|---|---|---|
| .NET / ASP.NET Core | 10.0 | Framework base de la API |
| Entity Framework Core | 10.0 | ORM para persistencia |
| Npgsql (PostgreSQL) | 10.0 | Proveedor de base de datos principal |
| Pomelo (MySQL) | 9.0 | Proveedor alternativo de base de datos |
| Mapster | 10.0 | Mapeo automático entre entidades y DTOs |
| MediatR | 14.0 | Implementación del patrón Mediator para casos de uso |
| Swashbuckle / OpenAPI | 10.0 | Documentación interactiva de la API |
| AspNetCoreRateLimit | — | Control de tasa de peticiones por endpoint |
| JWT Bearer | — | Autenticación y autorización basada en tokens |

---

## 🗂 Modelo de Dominio

El dominio está organizado en **38 entidades** agrupadas en módulos funcionales:

```
Geografía
  Country ──► Department ──► City

Usuarios
  Role ──► User

Clientes
  Customer ──► CustomerAddress
           ──► CustomerEmail
           └──► CustomerPhone

Vehículos
  VehicleMake ──► VehicleModel ──► Vehicle ──► MileageHistory

Inventario
  SpareCategory ──► SparePart ◄── UnitMeasure
  SparePart ◄──── SparePartSupplier ────► Supplier
  InventoryLog (movimientos de stock)

Compras
  Supplier ──► Purchase ──► PurchaseDetail ──► SparePart

Servicios y Órdenes
  Appointment
  ServiceType ──► OrderServiceType
  OrderStatus ──► OrderStatusHistory
  OrderService ──► OrderServiceType
              ──► OrderStatusHistory
              ──► OrderDetail ──► SparePart
              ──► OrderMechanic ──► User
              ──► OrderNote
              └──► MechanicTask ──► User · ServiceType

Facturación y Pagos
  OrderService ──► Invoice ◄── InvoiceStatus
  Invoice ──► Payment ◄── PaymentMethod

Garantías
  Warranty ──► OrderService · ServiceType · User(Mecánico)

Auditoría
  Audit (registro inmutable de todas las operaciones)
```

---

## ✅ Reglas de Negocio Implementadas

Estas reglas están codificadas directamente en las entidades del dominio, garantizando que se apliquen independientemente de cómo se llame al sistema:

| Entidad | Regla |
|---|---|
| `OrderService` | La fecha estimada de entrega no puede ser anterior a la fecha de ingreso |
| `OrderService` | La fecha de entrega real no puede ser anterior a la fecha de ingreso ni a la fecha estimada |
| `SparePart` | El stock actual no puede ser menor al stock mínimo (al crear y al actualizar) |
| `MechanicTask` | La fecha de fin de la tarea no puede ser anterior a la fecha de inicio |
| `Warranty` | La fecha de vencimiento de garantía no puede ser anterior a la fecha de inicio |
| `Invoice` | Requiere una orden, un estado y un usuario responsable (no permite GUIDs vacíos) |
| `Vehicle` | Requiere un cliente y un modelo válidos (no permite GUIDs vacíos) |
| `Audit` | Requiere usuario, entidad, tipo de acción y fecha (sin excepciones) |
| `User` | Tiene fecha de alta y fecha de baja; soporta desactivación sin eliminación |
| `Customer` | Soporta baja lógica mediante el campo `Active` |

---

## 🔌 Endpoints de la API

La API expone **43 controladores** con métodos `GET`, `POST`, `PUT` y `DELETE`. Todos los listados soportan paginación mediante `?pageNumber=1&pageSize=10`, retornando el total en el encabezado `X-Total-Count`.

### Autenticación
| Método | Ruta | Descripción |
|---|---|---|
| `POST` | `/api/auth/login` | Obtener token JWT con email y contraseña |

### Módulos principales
| Módulo | Ruta Base |
|---|---|
| Clientes | `/api/customers` |
| Direcciones de cliente | `/api/customeraddresses` |
| Correos de cliente | `/api/customeremails` |
| Teléfonos de cliente | `/api/customerphones` |
| Vehículos | `/api/vehicles` |
| Marcas | `/api/vehiclemakes` |
| Modelos | `/api/vehiclemodels` |
| Historial de kilometraje | `/api/mileagehistories` |
| Citas | `/api/appointments` |
| Órdenes de servicio | `/api/orderservices` |
| Tipos de servicio en orden | `/api/orderservicetypes` |
| Historial de estados de orden | `/api/orderstatushistories` |
| Mecánicos en orden | `/api/ordermechanics` |
| Tareas del mecánico | `/api/mechanictasks` |
| Detalle de repuestos en orden | `/api/orderdetails` |
| Notas de orden | `/api/ordernotes` |
| Repuestos | `/api/spareparts` |
| Categorías de repuestos | `/api/sparecategories` |
| Unidades de medida | `/api/unitmeasures` |
| Log de inventario | `/api/inventorylogs` |
| Proveedores | `/api/suppliers` |
| Relación repuesto-proveedor | `/api/sparepartsuppliers` |
| Compras | `/api/purchases` |
| Detalle de compras | `/api/purchasedetails` |
| Facturas | `/api/invoices` |
| Estados de factura | `/api/invoicestatuses` |
| Pagos | `/api/payments` |
| Métodos de pago | `/api/paymentmethods` |
| Garantías | `/api/warranties` |
| Auditoría | `/api/audits` |
| Usuarios | `/api/users` |
| Roles | `/api/roles` |
| Países | `/api/countries` |
| Departamentos | `/api/departments` |
| Ciudades | `/api/cities` |
| Tipos de servicio | `/api/servicetypes` |
| Estados de orden | `/api/orderstatuses` |

---

## 🔐 Seguridad

### Autenticación JWT

El sistema usa **JSON Web Tokens (JWT)** firmados. Al hacer login exitoso, el servidor emite un token con vigencia de 60 minutos que incluye los claims `sub` (UserId), `email` y `role`. Cada petición a un endpoint protegido debe incluir el token en el encabezado:

```
Authorization: Bearer <token>
```

### Autorización por Roles

| Rol | Capacidades |
|---|---|
| **Admin** | Gestión completa: usuarios, roles, repuestos, reportes, toda la configuración |
| **Mecánico** | Consultar órdenes asignadas, registrar tareas, actualizar estados, generar facturas |
| **Recepcionista** | Crear y gestionar citas, abrir órdenes, consultar clientes y vehículos |

### Rate Limiting

Protección contra abuso mediante límites por endpoint:

| Ruta | Método | Límite |
|---|---|---|
| `/api/ordenesservicio*` | `POST` | 60 peticiones / minuto |
| `/api/repuestos*` | `GET` | 30 peticiones / minuto |

Al superar el límite, el servidor responde con `HTTP 429 Too Many Requests` y un mensaje explicativo.

---

## ⚙️ Configuración y Despliegue

### Variables de configuración (`appsettings.json`)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=AutoTallerManager;Username=postgres;Password=<PASSWORD>"
  },
  "Jwt": {
    "Key": "<CLAVE_SECRETA_MINIMO_32_CARACTERES>",
    "Issuer": "AutoTallerManager",
    "Audience": "AutoTallerManagerUsers",
    "ExpiresInMinutes": 60
  }
}
```

> ⚠️ En producción, las credenciales deben gestionarse mediante variables de entorno o un gestor de secretos (Azure Key Vault, AWS Secrets Manager, etc.), nunca hardcodeadas en el repositorio.

### Requisitos previos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- PostgreSQL 14+ **o** MySQL 8+
- CLI de EF Core: `dotnet tool install --global dotnet-ef`

### Pasos de instalación

```bash
# 1. Clonar el repositorio
git clone https://github.com/tu-usuario/AutoTallerManager.git
cd AutoTallerManager

# 2. Configurar la cadena de conexión en Api/appsettings.json

# 3. Aplicar migraciones y crear la base de datos
dotnet ef database update --project Infrastructure --startup-project Api

# 4. Ejecutar la API
cd Api
dotnet run

# 5. Abrir la documentación interactiva
# https://localhost:<puerto>/swagger
```

### Gestión de migraciones

```bash
# Crear una nueva migración
dotnet ef migrations add <NombreDeLaMigracion> --project Infrastructure --startup-project Api

# Revertir a una migración anterior
dotnet ef database update <MigracionAnterior> --project Infrastructure --startup-project Api
```

---

## 📁 Estructura del Proyecto

```
Proyecto.net/
├── Api/                          # Capa de presentación
│   ├── Controllers/              # 43 controladores REST
│   ├── Dtos/                     # DTOs de request/response por módulo
│   ├── appsettings.json          # Configuración (conexión, JWT, RateLimit)
│   └── Api.csproj                # .NET 10, Mapster, MediatR, Swagger
│
├── Application/                  # Capa de aplicación
│   ├── Abstractions/             # Interfaces de repositorios (IUnitOfWork, IRepository<T>)
│   └── Application.csproj
│
├── Domain/                       # Capa de dominio (sin dependencias externas)
│   └── Entities/                 # 38 entidades sealed con Value Objects y reglas de negocio
│       ├── Customers/            # Customer, CustomerAddress, CustomerEmail, CustomerPhone
│       ├── Vehicle/              # Vehicle, VehicleMake, VehicleModel, MileageHistory
│       ├── OrderService/         # OrderService, OrderDetail, OrderMechanic, MechanicTask...
│       ├── SparePart/            # SparePart, SpareCategory, InventoryLog
│       ├── Invoice/              # Invoice, InvoiceStatus, Payment, PaymentMethod
│       ├── Warranty/             # Warranty
│       ├── Audit/                # Audit
│       └── ...                   # Resto de entidades
│
├── Infrastructure/               # Capa de infraestructura
│   ├── Configuration/            # Fluent API (IEntityTypeConfiguration) por entidad
│   ├── Context/
│   │   └── AppDbContext.cs       # DbContext con 38 DbSets organizados por módulo
│   ├── Repositories/             # Implementación de repositorios por entidad
│   ├── UnitOfWork/
│   │   └── EfUnitOfWork.cs       # Agrupa los 38 repositorios en una transacción
│   ├── DependencyInjection.cs    # Registro de servicios en el contenedor DI
│   └── Infrastructure.csproj     # EF Core, Npgsql, Pomelo, Mapster
│
└── TheProyectNet.slnx            # Solución Visual Studio
```

---

## 🚀 Estado del Proyecto y Próximos Pasos

### Lo que está completamente implementado

- ✅ Las 38 entidades de dominio con Value Objects y validaciones de negocio
- ✅ 43 controladores REST con operaciones CRUD completas
- ✅ Autenticación JWT y autorización por roles
- ✅ Rate Limiting por endpoint
- ✅ Paginación y filtrado en todos los listados
- ✅ Auditoría de operaciones con datos anteriores/nuevos e IP de origen
- ✅ Unit of Work con transacciones atómicas
- ✅ Configuración de base de datos con Fluent API
- ✅ Documentación Swagger / OpenAPI interactiva
- ✅ Compatibilidad con PostgreSQL y MySQL

### Posibles extensiones futuras

- 📊 Panel de métricas y reportes (órdenes por mecánico, rotación de repuestos, ingresos por periodo)
- 📱 Aplicación móvil o web conectada a esta API
- 📧 Notificaciones por correo al cliente (cita confirmada, vehículo listo)
- 🔔 Alertas automáticas de stock mínimo
- 📄 Generación de PDF para facturas y órdenes de servicio
- 🌐 Multitenancy para gestionar múltiples sucursales desde una misma instancia

---

## 👥 Roles del Sistema — Referencia Rápida

```
┌─────────────────────────────────────────────────────┐
│                    ADMIN                            │
│  • Gestión de usuarios y roles                      │
│  • Configuración de catálogos                       │
│  • Acceso total a todos los módulos                 │
│  • Consulta de auditoría                            │
├─────────────────────────────────────────────────────┤
│                  RECEPCIONISTA                      │
│  • Registro de clientes y vehículos                 │
│  • Gestión de citas                                 │
│  • Apertura de órdenes de servicio                  │
│  • Consulta de estado de órdenes                    │
├─────────────────────────────────────────────────────┤
│                   MECÁNICO                          │
│  • Consulta de órdenes asignadas                    │
│  • Registro de tareas y horas trabajadas            │
│  • Actualización de estado de la orden              │
│  • Generación de facturas al cerrar la orden        │
└─────────────────────────────────────────────────────┘
```

---

<p align="center">
  <em>AutoTallerManager — Desarrollado con ASP.NET Core 10 · Arquitectura Hexagonal · Entity Framework Core</em>
</p>