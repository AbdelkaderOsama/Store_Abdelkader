
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistence;
using Presistence.Data;
using Services;
using Services.Abstraction;

using AssemblyMapping =  Services.AssemblyReference;

namespace Store_Abdelkader
{
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

            builder.Services.AddDbContext<StoreDbContext>( options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(AssemblyMapping).Assembly);
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            

            var app = builder.Build();

           using  var scop = app.Services.CreateScope();
           var dbinitializer =  scop.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbinitializer.InitializeAsync();

           

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
        }
    }
}
