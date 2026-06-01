using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Abstractions;

public interface IUnitOfWork
{
    IAppointment Appointments { get; }
    IAudit Audits { get; }
    ICity Cities { get; }
    ICountry Countries { get; }
    ICustomer Customers { get; }
    ICustomerAddress CustomerAddresses { get; }
    ICustomerEmail CustomerEmails { get; }
    ICustomerPhone CustomerPhones { get; }
    IDepartment Departments { get; }
    IInventoryLog InventoryLogs { get; }
    IInvoice Invoices { get; }
    IInvoiceStatus InvoiceStatuses { get; }
    IMechanicTask MechanicTasks { get; }
    IMileageHistory MileageHistories { get; }
    IOrderDetail OrderDetails { get; }
    IOrderMechanic OrderMechanics { get; }
    IOrderNote OrderNotes { get; }
    IOrderService OrderServices { get; }
    IOrderServiceType OrderServiceTypes { get; }
    IOrderStatus OrderStatuses { get; }
    IOrderStatusHistory OrderStatusHistories { get; }
    IPayment Payments { get; }
    IPaymentMethod PaymentMethods { get; }
    IPurchase Purchases { get; }
    IPurchaseDetail PurchaseDetails { get; }
    IRole Roles { get; }
    IServiceType ServiceTypes { get; }
    ISpareCategory SpareCategories { get; }
    ISparePart SpareParts { get; }
    ISparePartSupplier SparePartSuppliers { get; }
    ISupplier Suppliers { get; }
    IUnitMeasure UnitMeasures { get; }
    IUser Users { get; }
    IVehicle Vehicles { get; }
    IVehicleMake VehicleMakes { get; }
    IVehicleModel VehicleModels { get; }
    IWarranty Warranties { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);
    Task ExecuteInTransactionAsync(Func<CancellationToken, Task> action, CancellationToken ct = default);
}