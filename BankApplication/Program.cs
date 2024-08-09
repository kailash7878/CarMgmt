using CarMgmt.Intereface;
using CarMgmt.Repository;
using CarMgmt.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICar, CarServices>();
builder.Services.AddSingleton<IDataAccessLayer, DataAccessLayer>();


var app = builder.Build();
app.UseHttpsRedirection();
app.Run();