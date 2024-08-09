using CarMgmt.Intereface;
using CarMgmt.Repository;
using CarMgmt.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataAccessLayer, DataAccessLayer>();
builder.Services.AddScoped<ICar, CarServices>();


//builder.Services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "BankApplication");    
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();