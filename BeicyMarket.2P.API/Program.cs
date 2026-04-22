using BeicyMarket._2P.API.DataAccessProy;
using BeicyMarket._2P.API.RepositoriesProy;
using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using Dapper.Contrib.Extensions;

//Prepara todo para empezar a armar la API
var builder = WebApplication.CreateBuilder(args);


var connectionString = "Server=localhost;User=root;Pwd=SOYmeli136.;Database=BeicyMarket2;Port=3306;";
builder.Services.AddScoped<DbContextProy>(provider => new DbContextProy(connectionString));
// ==========================================================

builder.Services.AddOpenApi();

//Le avisa al sistema que vamos a usar los Controladores 
builder.Services.AddControllers();

// Prepara las herramientas para crear la página web de pruebas (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services
builder.Services.AddScoped<ICategoryRepositoryProy, CategoryRepositoryProy>();
builder.Services.AddScoped<IProductRepositoriesProy, ProductRepositoryProy>();
builder.Services.AddScoped<IUserRepositoriesProy, UserRepositoryProy>();
builder.Services.AddScoped<ISaleRepositoryProy, SaleRepositoryProy>();
builder.Services.AddScoped<ISaleDetailRepositoryProy, SaleDetailRepositoryProy>();
builder.Services.AddScoped<IPetSpeciesRepositoryProy, PetSpeciesRepositoryProy>();
builder.Services.AddScoped<ISupplierRepositoryProy, SupplierRepositoryProy>();
builder.Services.AddScoped<IPaymentRepositoryProy, PaymentRepositoryProy>();
builder.Services.AddScoped<IShippingRepositoryProy, ShippingRepositoryProy>();


//Termina de configurar y construye la aplicación
var app = builder.Build();

// Activa visualmente la página de Swagger para que puedas darle clic a tus botones
app.UseSwagger();
app.UseSwaggerUI();

// Lee las rutas de los controladores 
app.MapControllers();

//Pone la API a funcionar y a escuchar peticiones
app.Run();