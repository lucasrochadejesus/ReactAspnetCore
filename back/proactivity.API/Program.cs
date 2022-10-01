using Microsoft.EntityFrameworkCore;
using proactivity.Data.Context;
using proactivity.Data.Repositories;
using proactivity.Domain.Interfaces.Repositories;
using proactivity.Domain.Interfaces.Services;
using proactivity.Domain.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddControllers()
    .AddJsonOptions(option =>
        {
            option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddScoped<IActivityRepo, ActivityRepo>();
builder.Services.AddScoped<IBaseRepo, GeneralRepo>();
builder.Services.AddScoped<IActivityService, ActivityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
);

app.MapControllers();

app.Run();
