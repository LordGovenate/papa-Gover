using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Services;
using SoapCore;
using PokemonApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
//Migraciones
//AddScoped
//localhost

//despues de migraciones
//host.docker.internal
//AddSingleton
builder.Services.AddSingleton<IPokemonService,PokemonService>();
builder.Services.AddScoped<IPokemonRepository,PokemonRepository>();
builder.Services.AddSingleton<IHobbiesService,HobbiesService>();
builder.Services.AddScoped<IHobbiesRepository,HobbiesRepository>();
builder.Services.AddSingleton<IBooksService,BooksService>();
builder.Services.AddScoped<IBooksRepository,BooksRepository>();

builder.Services.AddDbContext<RelationalDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IHobbiesService>("/KevinAlonsoHobbiesService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IBooksService>("/BooksService.svc", new SoapEncoderOptions());

app.Run();