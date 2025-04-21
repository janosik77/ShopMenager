using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestApiShopmenager.BuissnesLogic.Auth;
using RestApiShopmenager.BuissnesLogic.Services;
using RestApiShopmenager.Models.Contexts;
using System.Text;

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
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IHomeService, HomeService>();

            // Konfiguracja JWT Authentication
            var jwtCfg = builder.Configuration.GetSection("Jwt");
            var secretKey = jwtCfg["Secret"];
            var issuer = jwtCfg["Issuer"];
            var audience = jwtCfg["Audience"];

            builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // w prod ustaw true
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                                                   Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

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
