using ParkingLotRental.Application; // Assuming ApplicationServicesExtensions is in this namespace
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Application Layer services
builder.Services.AddAutoMapper(Assembly.Load("ParkingLotRental.Application")); // For AutoMapper
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("ParkingLotRental.Application"))); // For MediatR


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// This will register the controllers
app.MapControllers();

app.Run();
