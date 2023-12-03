using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var ConnectionStringBuilder = new NpgsqlConnectionStringBuilder
{
    ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection"),
    Username = builder.Configuration["UserID"],
    Password = builder.Configuration["Password"],
};



//! ConfigurationManager Configuration = builder.Configuration;

builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(ConnectionStringBuilder.ConnectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "Hello World!");


app.UseHttpsRedirection(); //Middleware

app.UseAuthorization(); //Middleware

app.MapControllers(); //Middleware

app.Run();
