using drone_last.Models;
using Microsoft.EntityFrameworkCore;
using drone_last.Models.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<nppContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<DronesService>();
builder.Services.AddTransient<PilotesService>();
builder.Services.AddTransient<SessionsService>();
builder.Services.AddTransient<TypeDronesService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
