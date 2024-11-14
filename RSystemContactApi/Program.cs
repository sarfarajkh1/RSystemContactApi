using RSystem.Contact.Business;
using RSystem.Contact.Data.FileSystem;
using RSystemContactApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
// Add services to the container.

var services = builder.Services;
services.AddTransient<IContactService, ContactService>();
services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
