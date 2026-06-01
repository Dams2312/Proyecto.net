using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions;
using Infrastructure.Context;

namespace Infrastructure.UnitOfWork;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _contextdb;

    public EfUnitOfWork(
        AppDbContext db,
        IAppointment appointments,
        IAudit audits,
        ICity cities,
        ICountry countries,
        ICustomer customers,
        ICustomerAddress customerAddresses,
        ICustomerEmail customerEmails,
        ICustomerPhone customerPhones,
        IDepartment departments,
        IInventoryLog inventoryLogs,
        IInvoice invoices,
        IInvoiceStatus invoiceStatuses,
        IMechanicTask mechanicTasks,
        IMileageHistory mileageHistories,
        IOrderDetail orderDetails,
        IOrderMechanic orderMechanics,
        IOrderNote orderNotes,
        IOrderService orderServices,
        IOrderServiceType orderServiceTypes,
        IOrderStatus orderStatuses,
        IOrderStatusHistory orderStatusHistories,
        IPayment payments,
        IPaymentMethod paymentMethods,
        IPurchase purchases,
        IPurchaseDetail purchaseDetails,
        IRole roles,
        IServiceType serviceTypes,
        ISpareCategory spareCategories,
        ISparePart spareParts,
        ISparePartSupplier sparePartSuppliers,
        ISupplier suppliers,
        IUnitMeasure unitMeasures,
        IUser users,
        IVehicle vehicles,
        IVehicleMake vehicleMakes,
        IVehicleModel vehicleModels,
        IWarranty warranties)
    {
        _contextdb = db;

        Appointments = appointments;
        Audits = audits;
        Cities = cities;
        Countries = countries;
        Customers = customers;
        CustomerAddresses = customerAddresses;
        CustomerEmails = customerEmails;
        CustomerPhones = customerPhones;
        Departments = departments;
        InventoryLogs = inventoryLogs;
        Invoices = invoices;
        InvoiceStatuses = invoiceStatuses;
        MechanicTasks = mechanicTasks;
        MileageHistories = mileageHistories;
        OrderDetails = orderDetails;
        OrderMechanics = orderMechanics;
        OrderNotes = orderNotes;
        OrderServices = orderServices;
        OrderServiceTypes = orderServiceTypes;
        OrderStatuses = orderStatuses;
        OrderStatusHistories = orderStatusHistories;
        Payments = payments;
        PaymentMethods = paymentMethods;
        Purchases = purchases;
        PurchaseDetails = purchaseDetails;
        Roles = roles;
        ServiceTypes = serviceTypes;
        SpareCategories = spareCategories;
        SpareParts = spareParts;
        SparePartSuppliers = sparePartSuppliers;
        Suppliers = suppliers;
        UnitMeasures = unitMeasures;
        Users = users;
        Vehicles = vehicles;
        VehicleMakes = vehicleMakes;
        VehicleModels = vehicleModels;
        Warranties = warranties;
    }

    public IAppointment Appointments { get; }
    public IAudit Audits { get; }
    public ICity Cities { get; }
    public ICountry Countries { get; }
    public ICustomer Customers { get; }
    public ICustomerAddress CustomerAddresses { get; }
    public ICustomerEmail CustomerEmails { get; }
    public ICustomerPhone CustomerPhones { get; }
    public IDepartment Departments { get; }
    public IInventoryLog InventoryLogs { get; }
    public IInvoice Invoices { get; }
    public IInvoiceStatus InvoiceStatuses { get; }
    public IMechanicTask MechanicTasks { get; }
    public IMileageHistory MileageHistories { get; }
    public IOrderDetail OrderDetails { get; }
    public IOrderMechanic OrderMechanics { get; }
    public IOrderNote OrderNotes { get; }
    public IOrderService OrderServices { get; }
    public IOrderServiceType OrderServiceTypes { get; }
    public IOrderStatus OrderStatuses { get; }
    public IOrderStatusHistory OrderStatusHistories { get; }
    public IPayment Payments { get; }
    public IPaymentMethod PaymentMethods { get; }
    public IPurchase Purchases { get; }
    public IPurchaseDetail PurchaseDetails { get; }
    public IRole Roles { get; }
    public IServiceType ServiceTypes { get; }
    public ISpareCategory SpareCategories { get; }
    public ISparePart SpareParts { get; }
    public ISparePartSupplier SparePartSuppliers { get; }
    public ISupplier Suppliers { get; }
    public IUnitMeasure UnitMeasures { get; }
    public IUser Users { get; }
    public IVehicle Vehicles { get; }
    public IVehicleMake VehicleMakes { get; }
    public IVehicleModel VehicleModels { get; }
    public IWarranty Warranties { get; }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
        => _contextdb.SaveChangesAsync(ct);

    public async Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken ct = default)
    {
        await using var tx = await _contextdb.Database.BeginTransactionAsync(ct);
        try
        {
            await operation(ct);
            await _contextdb.SaveChangesAsync(ct);
            await tx.CommitAsync(ct);
        }
        catch
        {
            await tx.RollbackAsync(ct);
            throw;
        }
    }
}