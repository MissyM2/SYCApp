using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SYCApp.Core.DataServices;
using SYCApp.Core.Processors;
using SYCApp.Persistence;
using SYCApp.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conn = new SqliteConnection(builder.Configuration.GetConnectionString("SqliteConnection"));

builder.Services.AddDbContext<SYCAppDbContext>(option =>
    option.UseSqlite(conn));

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

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginRequestProcessor, LoginRequestProcessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

