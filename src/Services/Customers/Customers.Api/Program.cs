using Customers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddInMemoryCommandBus()
    .AddCommandHandlerInAssemblyOf<Customer>();

builder.Services
    .AddQueryBus()
    .AddQueryHandlerInAssemblyOf<Customer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
