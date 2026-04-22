using BeicyMarket._2P.API.DataAccessProy;
using BeicyMarket._2P.API.RepositoriesProy;
using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using Dapper.Contrib.Extensions;



//Prepara todo para empezar a armar la API
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

//Le avisa al sistema que vamos a usar los Controladores 
builder.Services.AddControllers();

// Prepara las herramientas para crear la página web de pruebas (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services
builder.Services.AddScoped<DbContextProy>(); 
builder.Services.AddScoped<ICategoryRepositoryProy, CategoryRepositoryProy>();
builder.Services.AddScoped<IProductRepositoriesProy, ProductRepositoryProy>();
builder.Services.AddScoped<IUserRepositoriesProy, UserRepositoryProy>();
builder.Services.AddScoped<ISaleRepositoryProy, SaleRepositoryProy>();
builder.Services.AddScoped<ISaleDetailRepositoryProy, SaleDetailRepositoryProy>();
builder.Services.AddScoped<IPetSpeciesRepositoryProy, PetSpeciesRepositoryProy>();
builder.Services.AddScoped<ISupplierRepositoryProy, SupplierRepositoryProy>();
builder.Services.AddScoped<IPaymentRepositoryProy, PaymentRepositoryProy>();
builder.Services.AddScoped<IShippingRepositoryProy, ShippingRepositoryProy>();



//mapeo
SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("Tecnm26.Ecommerce.Core.EntitiesProy."))
        name = name.Replace("Tecnm26.Ecommerce.Core.EntitiesProy.", "");
        
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};

//Termina de configurar y construye la aplicación
var app = builder.Build();

// Activa visualmente la página de Swagger para que puedas darle clic a tus botones
app.UseSwagger();
app.UseSwaggerUI();

// Lee las rutas de los controladores 
app.MapControllers();
  
//Pone la API a funcionar y a escuchar peticiones
app.Run();