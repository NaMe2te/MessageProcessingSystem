using MessageProcessingSystem.DataAccess.Extensions;
using MessageProcessingSystem.Application.Extensions;
using MessageProcessingSystem.UI.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddDataAccess(b => b.UseLazyLoadingProxies().UseSqlite("Data Source=message_processing_system.db"));

builder.Services.AddControllers();

builder.Services
    .AddCookiesAuthentication()
    .AddRoles();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();