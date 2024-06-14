using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NBP2024.API.Middlewares;
using NBP2024.Application.Mappings;
using NBP2024.Application.Services;
using NBP2024.Domain.Interfaces;
using NBP2024.Infrastructure;
using NBP2024.Infrastructure.MongoDB;
using NBP2024.Repository;
using NBP2024.Repository.Repositories;
using Serilog;
using Serilog.Core;
using System.Reflection;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Debug)
    .WriteTo.File("logs.txt")
    .CreateLogger();

try
{
    Log.Logger.Information("Application is starting");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, configuration) => configuration
           .ReadFrom.Configuration(context.Configuration)
                  .Enrich.FromLogContext()
                         .WriteTo.File("logs.txt"));

    // Add services to the container.
    builder.Services.AddDbContext<PlutoContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("PlutoContext")));
    builder.Services.AddAutoMapper(typeof(MappingProfile));
    builder.Services.AddScoped<MongoService>();

    builder.Services.AddScoped<ICourseRepository, CourseRepository>();
    //builder.Services.AddScoped<ICourseRepository, CoursesMongoRepository>();
    builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<CoursesService>();

    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<PlutoContext>()
                    .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(
        options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = "https://localhost:5001/",
                ValidIssuer = "https://localhost:5001/",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("78fUjkyzfLz56gTq78fUjkyzfLz56gTq"))
            };
        });

    builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

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

    app.UseGlobalExceptionMiddleware();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Logger.Fatal(ex, "Application failed to start");
}
