<<<<<<< HEAD
using System.Text.Json.Serialization;
=======
>>>>>>> cb0bdcc138b7856e9375df06e0075ae12405c89e
using Ecommerce.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

<<<<<<< HEAD
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x=> x.UseSqlServer("name=DockerConnection"));
builder.Services.AddTransient<SeedDb>();
=======
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x=> x.UseSqlServer("name=DockerConnection"));
>>>>>>> cb0bdcc138b7856e9375df06e0075ae12405c89e


var app = builder.Build();

<<<<<<< HEAD
SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory!.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}


=======
// Configure the HTTP request pipeline.
>>>>>>> cb0bdcc138b7856e9375df06e0075ae12405c89e
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin=>true));

app.Run();
