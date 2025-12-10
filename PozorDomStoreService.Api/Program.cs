using PozorDomStoreService.Api.Extensions;
using PozorDomStoreService.Application.Services;
using PozorDomStoreService.Domain.Interfaces.Repositories;
using PozorDomStoreService.Domain.Interfaces.Services;
using PozorDomStoreService.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDatabaseContext(builder.Configuration);

builder.Services.AddScoped<IDeviceTypeRepository, DeviceTypeRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IHubRepository, HubRepository>();

builder.Services.AddScoped<IDeviceTypeService, DeviceTypeService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IHubService, HubService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.Run();
