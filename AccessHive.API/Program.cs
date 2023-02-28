using AccessHive.API.Configurations;
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
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

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