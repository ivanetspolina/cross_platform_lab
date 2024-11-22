using Lab6.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Lab6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<CallCenterDbContext>(options =>
            {
                var dbType = builder.Configuration.GetValue<string>("DatabaseType");
                Console.WriteLine($"Database type: {dbType}");

                switch (dbType)
                {
                    case "MSSQL":
                        var connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
                        Console.WriteLine($"Connection string: {connectionString}");
                        options.UseSqlServer(connectionString);
                        break;

                    case "Postgres":
                        var postgresConnection = builder.Configuration.GetConnectionString("PostgresConnection");
                        Console.WriteLine($"Connection string: {postgresConnection}");
                        options.UseNpgsql(postgresConnection);
                        break;

                    case "SqlLite":
                        var sqliteConnection = builder.Configuration.GetConnectionString("SqlLiteConnection");
                        Console.WriteLine($"Connection string: {sqliteConnection}");
                        options.UseSqlite(sqliteConnection);
                        break;

                    case "InMemory":
                        Console.WriteLine("Using InMemory database");
                        options.UseInMemoryDatabase("Lab6Db");
                        break;

                    default:
                        throw new Exception("Unknown database type in configuration.");
                }
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://dev-kf77w0uzkcitpl2f.us.auth0.com/";
                options.Audience = "call-center";

                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"OnAuthenticationFailed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        var claims = context.Principal?.Claims.Select(c => $"{c.Type}: {c.Value}");
                        Console.WriteLine($"Token validated. Claims: {string.Join(", ", claims ?? Array.Empty<string>())}");
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        Console.WriteLine($"Token received: {context.Token}");
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        Console.WriteLine($"OnChallenge: {context.Error}, {context.ErrorDescription}");
                        return Task.CompletedTask;
                    }
                };
            });



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<CallCenterDbContext>();
                    context.Database.Migrate();
                    CallCenterDbContext.Seed(context);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

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
