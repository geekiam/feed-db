﻿// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Test_DB");
builder.Services.AddDbContext<FeedsDbContext>(x => x.UseNpgsql(connectionString));
    

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<FeedsDbContext>();
    context?.Database.Migrate();
    if (context != null) DbInitialiser.Initialise(context);
}
