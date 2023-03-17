using AccessHive.API.Configurations;
using AccessHive.API.CustomSwaggerDocs;
using AccessHive.Application;
using AccessHive.Integration.MessagingBus;
using AccessHive.Integration.MessagingBus.Interfaces;
using AccessHive.Read.Data;
using AccessHive.Read.Data.QueryHandlers;
using AccessHive.Write.Data;
using AccessHive.Write.Data.CommandHandlers;
using AccessHive.Write.Data.EventDispatchers;
using AccessHive.Write.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));

    // Add services to the container.
    builder.Services.AddMediatR(typeof(RoleAddCommandHandler).GetTypeInfo().Assembly, typeof(GetRoleByIdQueryHandler).GetTypeInfo().Assembly);
    builder.Services.AddScoped(x =>
        new ReadDbContext(builder.Configuration.GetConnectionString("DBConnectionString"))
    );
    builder.Services.AddDbContext<WriteDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString"))
    );
    builder.Services.AddScoped<RoleRepository>();
    builder.Services.AddScoped<IAppService, AppService>();
    builder.Services.AddAutoMapperSetup();
    builder.Services.AddScoped<IBus>(c => new RmqServiceBus(builder.Configuration.GetConnectionString("RMQConnectionString")));
    builder.Services.AddScoped<MessageBus>();
    builder.Services.AddScoped<EventDispatcher>();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "AccessHive API", Version = "v1" });
        options.DocumentFilter<HealthChecksFilter>();
    });

    builder.Services
        .AddHealthChecks()
        .AddDbContextCheck<WriteDbContext>()
        .AddRabbitMQConnectionHealthCheck(builder.Configuration.GetConnectionString("RMQConnectionString"), "Rabbit MQ", HealthStatus.Degraded);

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
        app.UseSwagger();
        app.UseSwaggerUI();
    //}

    app.ApplyDatabaseSchema();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.MapDefaultHealthChecks();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
