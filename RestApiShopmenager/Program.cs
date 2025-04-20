
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.BuissnesLogic.Services;
using RestApiShopmenager.Models.Contexts;

namespace RestApiShopmenager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CompanyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyContext")
                ?? throw new InvalidOperationException("Connection string 'CompanyContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<IHomeService, HomeService>();
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

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
