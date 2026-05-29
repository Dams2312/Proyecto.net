using Domain.Entities.Appointment;
using Domain.Entities.Audit;
using Domain.Entities.Citys;
using Domain.Entities.Countries;
using Domain.Entities.CustomerAddresses;
using Domain.Entities.CustomerEmails;
using Domain.Entities.CustomerPhones;
using Domain.Entities.Customers;
using Domain.Entities.Departments;
using Domain.Entities.InventoryLog;
using Domain.Entities.Invoice;
using Domain.Entities.InvoiceStatus;
using Domain.Entities.MechanicTask;
using Domain.Entities.MileageHistory;
using Domain.Entities.OrderDetail;
using Domain.Entities.OrderMechanic;
using Domain.Entities.OrderNote;
using Domain.Entities.OrderService;
using Domain.Entities.OrderServiceType;
using Domain.Entities.OrderStatus;
using Domain.Entities.OrderStatusHistory;
using Domain.Entities.Payment;
using Domain.Entities.PaymentMethod;
using Domain.Entities.Purchase;
using Domain.Entities.PurchaseDetail;
using Domain.Entities.Roles;
using Domain.Entities.ServiceType;
using Domain.Entities.SpareCategory;
using Domain.Entities.SparePart;
using Domain.Entities.SparePartSupplier;
using Domain.Entities.Supplier;
using Domain.Entities.UnitMeasure;
using Domain.Entities.Users;
using Domain.Entities.Vehicle;
using Domain.Entities.VehicleMake;
using Domain.Entities.Vehiclemodel;
using Domain.Entities.Warranty;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Geografía
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<City> Cities => Set<City>();

    // // Usuarios y roles
    // public DbSet<Role> Roles => Set<Role>();
    // public DbSet<User> Users => Set<User>();

    // // Clientes
    // public DbSet<Customer> Customers => Set<Customer>();
    // public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
    // public DbSet<CustomerEmail> CustomerEmails => Set<CustomerEmail>();
    // public DbSet<CustomerPhone> CustomerPhones => Set<CustomerPhone>();

    // // Vehículos
    // public DbSet<VehicleMake> VehicleMakes => Set<VehicleMake>();
    // public DbSet<VehicleModel> VehicleModels => Set<VehicleModel>();
    // public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    // public DbSet<MileageHistory> MileageHistories => Set<MileageHistory>();

    // // Inventario
    // public DbSet<UnitMeasure> UnitMeasures => Set<UnitMeasure>();
    // public DbSet<SpareCategory> SpareCategories => Set<SpareCategory>();
    // public DbSet<SparePart> SpareParts => Set<SparePart>();
    // public DbSet<SparePartSupplier> SparePartSuppliers => Set<SparePartSupplier>();
    // public DbSet<InventoryLog> InventoryLogs => Set<InventoryLog>();

    // // Proveedores y compras
    // public DbSet<Supplier> Suppliers => Set<Supplier>();
    // public DbSet<Purchase> Purchases => Set<Purchase>();
    // public DbSet<PurchaseDetail> PurchaseDetails => Set<PurchaseDetail>();

    // // Servicios y órdenes
    // public DbSet<ServiceType> ServiceTypes => Set<ServiceType>();
    // public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
    // public DbSet<Appointment> Appointments => Set<Appointment>();
    // public DbSet<OrderService> OrderServices => Set<OrderService>();
    // public DbSet<OrderServiceType> OrderServiceTypes => Set<OrderServiceType>();
    // public DbSet<OrderStatusHistory> OrderStatusHistories => Set<OrderStatusHistory>();
    // public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    // public DbSet<OrderMechanic> OrderMechanics => Set<OrderMechanic>();
    // public DbSet<OrderNote> OrderNotes => Set<OrderNote>();
    // public DbSet<MechanicTask> MechanicTasks => Set<MechanicTask>();

    // // Facturación y pagos
    // public DbSet<InvoiceStatus> InvoiceStatuses => Set<InvoiceStatus>();
    // public DbSet<Invoice> Invoices => Set<Invoice>();
    // public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    // public DbSet<Payment> Payments => Set<Payment>();

    // // Garantías y auditoría
    // public DbSet<Warranty> Warranties => Set<Warranty>();
    // public DbSet<Audit> Audits => Set<Audit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}