using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Core.Services;
using SYCApp.Persistence;
using SYCApp.Persistence.Repositories;
using SYCApp.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conn = new SqliteConnection(builder.Configuration.GetConnectionString("SqliteConnection"));

builder.Services.AddDbContext<SYCAppDbContext>(option =>
    option.UseSqlite(conn));

builder.Services.ConfigureCors();
builder.Services.ConfigureRepositories();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SYCApp.Api", Version = "v1" });
});

EnsureDatabaseCreated(conn);

static void EnsureDatabaseCreated(SqliteConnection conn)
{
    var builder = new DbContextOptionsBuilder<SYCAppDbContext>();
    builder.UseSqlite(conn);

    using var context = new SYCAppDbContext(builder.Options);
    context.Database.EnsureCreated();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

