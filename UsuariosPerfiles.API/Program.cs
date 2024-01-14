using UsuariosPerfiles.Abstraction.IAplication.Opciones;
using UsuariosPerfiles.Abstraction.IRepository.Perfiles;
using UsuariosPerfiles.Abstraction.IService.Opciones;
using UsuariosPerfiles.Aplication.Opciones;
using UsuariosPerfiles.Services.Opciones;
using UsuariosPerfiles.Repository.Opciones;
using UsuariosPerfiles.Abstraction.IRepository.Opciones;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPerfilAplication, PerfilAplication>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();

builder.Services.AddScoped<IPerfilOpcionAplication, PerfilOpcionAplication>();
builder.Services.AddScoped<IPerfilOpcionService, PerfilOpcionService>();
builder.Services.AddScoped<IPerfilOpcionRepository, PerfilOpcionRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
var devCors = "devCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: devCors, builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(devCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
