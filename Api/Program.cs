using Api.Extensions;
using Application;
using Application.Abstractions;
using Infrastructure;
using Infrastructure.Repositories.Appointment;
using Infrastructure.Repositories.Audit;
using Infrastructure.Repositories.City;
using Infrastructure.Repositories.Countries;
using Infrastructure.Repositories.Customer;
using Infrastructure.Repositories.CustomerAddress;
using Infrastructure.Repositories.CustomerEmail;
using Infrastructure.Repositories.CustomerPhone;
using Infrastructure.Repositories.Department;
using Infrastructure.Repositories.InventoryLog;
using Infrastructure.Repositories.Invoice;
using Infrastructure.Repositories.InvoiceStatus;
using Infrastructure.Repositories.MechanicTask;
using Infrastructure.Repositories.MileageHistory;
using Infrastructure.Repositories.OrderDetail;
using Infrastructure.Repositories.OrderMechanic;
using Infrastructure.Repositories.OrderNote;
using Infrastructure.Repositories.OrderService;
using Infrastructure.Repositories.OrderServiceType;
using Infrastructure.Repositories.OrderStatus;
using Infrastructure.Repositories.OrderStatusHistory;
using Infrastructure.Repositories.Payment;
using Infrastructure.Repositories.PaymentMethod;
using Infrastructure.Repositories.Purchase;
using Infrastructure.Repositories.PurchaseDetail;
using Infrastructure.Repositories.Role;
using Infrastructure.Repositories.ServiceType;
using Infrastructure.Repositories.SpareCategory;
using Infrastructure.Repositories.SparePart;
using Infrastructure.Repositories.SparePartSupplier;
using Infrastructure.Repositories.Supplier;
using Infrastructure.Repositories.UnitMeasure;
using Infrastructure.Repositories.User;
using Infrastructure.Repositories.Vehicle;
using Infrastructure.Repositories.VehicleMake;
using Infrastructure.Repositories.VehicleModel;
using Infrastructure.Repositories.Warranty;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();

builder.Services.AddScoped<IAppointment, AppointmentRepository>();
builder.Services.AddScoped<IAudit, AuditRepository>();
builder.Services.AddScoped<ICity, CityRepository>();
builder.Services.AddScoped<ICountry, CountryRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<ICustomerAddress, CustomerAddressRepository>();
builder.Services.AddScoped<ICustomerEmail, CustomerEmailRepository>();
builder.Services.AddScoped<ICustomerPhone, CustomerPhoneRepository>();
builder.Services.AddScoped<IDepartment, DepartmentRepository>();
builder.Services.AddScoped<IInventoryLog, InventoryLogRepository>();
builder.Services.AddScoped<IInvoice, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceStatus, InvoiceStatusRepository>();
builder.Services.AddScoped<IMechanicTask, MechanicTaskRepository>();
builder.Services.AddScoped<IMileageHistory, MileageHistoryRepository>();
builder.Services.AddScoped<IOrderDetail, OrderDetailRepository>();
builder.Services.AddScoped<IOrderMechanic, OrderMechanicRepository>();
builder.Services.AddScoped<IOrderNote, OrderNoteRepository>();
builder.Services.AddScoped<IOrderService, OrderServiceRepository>();
builder.Services.AddScoped<IOrderServiceType, OrderServiceTypeRepository>();
builder.Services.AddScoped<IOrderStatus, OrderStatusRepository>();
builder.Services.AddScoped<IOrderStatusHistory, OrderStatusHistoryRepository>();
builder.Services.AddScoped<IPayment, PaymentRepository>();
builder.Services.AddScoped<IPaymentMethod, PaymentMethodRepository>();
builder.Services.AddScoped<IPurchase, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseDetail, PurchaseDetailRepository>();
builder.Services.AddScoped<IRole, RoleRepository>();
builder.Services.AddScoped<IServiceType, ServiceTypeRepository>();
builder.Services.AddScoped<ISpareCategory, SpareCategoryRepository>();
builder.Services.AddScoped<ISparePart, SparePartRepository>();
builder.Services.AddScoped<ISparePartSupplier, SparePartSupplierRepository>();
builder.Services.AddScoped<ISupplier, SupplierRepository>();
builder.Services.AddScoped<IUnitMeasure, UnitMeasureRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IVehicle, VehicleRepository>();
builder.Services.AddScoped<IVehicleMake, VehicleMakeRepository>();
builder.Services.AddScoped<IVehicleModel, VehicleModelRepository>();
builder.Services.AddScoped<IWarranty, WarrantyRepository>();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();