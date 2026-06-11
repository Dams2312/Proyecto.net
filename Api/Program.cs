using Api.Extensions;
using Api.Infrastructure;
using Api.Security;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AutoTallerManager API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el JWT sin prefijo. Swagger enviara: Bearer {token}"
    });

});

builder.Services.AddEndpointsApiExplorer();

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
builder.Services.AddScoped<JwtTokenService>();

var jwt = builder.Configuration.GetSection("Jwt");
var jwtKey = jwt["Key"] ?? throw new InvalidOperationException("Jwt:Key is not configured.");
var jwtIssuer = jwt["Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer is not configured.");
var jwtAudience = jwt["Audience"] ?? throw new InvalidOperationException("Jwt:Audience is not configured.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,
            ValidateAudience = true,
            ValidAudience = jwtAudience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(2)
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole(RoleNames.Admin));
    options.AddPolicy("MechanicOrAdmin", policy => policy.RequireRole(RoleNames.Mecanico, RoleNames.Admin));
    options.AddPolicy("ReceptionistOrAdmin", policy => policy.RequireRole(RoleNames.Recepcionista, RoleNames.Admin));
    options.AddPolicy("Staff", policy => policy.RequireRole(RoleNames.Admin, RoleNames.Mecanico, RoleNames.Recepcionista));
});

builder.Services.ConfigureCors();

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddMapsterConfiguration();

var app = builder.Build();

await app.SeedAuthAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
