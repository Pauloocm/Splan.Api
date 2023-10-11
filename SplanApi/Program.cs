using Splan.Platform.Application;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Infrastructure.Database;
using Splan.Platform.Infrastructure.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient<ISplanAppService, SplanAppService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
var app = builder.Build();

#region [Cors]
builder.Services.AddCors();
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region [Cors]
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
