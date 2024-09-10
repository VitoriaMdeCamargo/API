
using _2TDSPK.Database;
using _2TDSPK.Database.Models;
using _2TDSPK.Repository;
using _2TDSPK.Repository.Interface;
using _2TDSPK.Services.CEP;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace _2TDSPK.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(swagger =>
            {
                //Adiciona a possibilidade de enviar token para o controller
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                //Codigo para mudar a documentação do Swagger
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration.GetSection("Swagger:Title").Value,
                    Description = builder.Configuration.GetSection("Swagger:Description").Value,
                    Contact = new OpenApiContact()
                    {
                        Email = builder.Configuration.GetSection("Swagger:Email").Value,
                        Name = builder.Configuration.GetSection("Swagger:Name").Value
                    }
                });
            });

            builder.Services.AddDbContext<FIAPDBContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("FIAPDatabase"));
            });

            builder.Services.AddScoped<ICEPService, CEPService>();  
            builder.Services.AddScoped<IRepository<User>, Repository<User>>();

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
        }
    }
}
