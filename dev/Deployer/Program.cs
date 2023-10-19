// See https://aka.ms/new-console-template for more information

using Geekiam.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Test_DB");
builder.Services.AddDbContext<FeedsDbContext>(x => x.UseNpgsql(connectionString));
    

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<FeedsDbContext>();
    context?.Database.Migrate();
    
}
