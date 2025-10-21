using System.Reflection.Metadata;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories;
using Services.Abstraction.Contracts;
using Services.Implementations;
using AssemblyReference = Services.AssemblyReference;

namespace E_Commerce;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddScoped<IDataSeeding, DataSeeding>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddAutoMapper(cfg => { }, typeof(AssemblyReference).Assembly);
        builder.Services.AddScoped<IServiceManager, ServiceManager>();
        
        
        var app = builder.Build();
        
        using var scope = app.Services.CreateScope();
        var objectDataSeeding = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
        await objectDataSeeding.SeedDataAsync();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();   //MiddleWares ==> Swagger 
            app.UseSwaggerUI(); //MiddleWares ==> Swagger 
        }

        app.UseHttpsRedirection();
        
        
        app.MapControllers();

        app.Run();
    }
}