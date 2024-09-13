using FDV.Core.Mediator;
using FDV.Forum.Domain.Interfaces;
using FDV.Forum.Infra.Data;
using FDV.Forum.Infra.Repositories;
using FDV.Usuarios.App.Domain.Interfaces;
using FDV.Usuarios.App.Infra.Data;
using FDV.Usuarios.App.Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddDbContext<UsuarioContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ForumConnection")));

builder.Services.AddDbContext<PostagensContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ForumConnection")));

builder.Services.AddScoped<IMediatorHandler,MediatorHandler>();
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddScoped<IPostagemRepository,PostagemRepository>();

builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();