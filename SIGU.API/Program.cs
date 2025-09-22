
// using Microsoft.EntityFrameworkCore;
// using SIGU.API.Data;

// using Microsoft.OpenApi.Models;

// var builder = WebApplication.CreateBuilder(args);

// // 👉 Controllers
// builder.Services.AddControllers();

// // 👉 Swagger
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
// });

// builder.Services.AddDbContext<SiguContext>(options => //esto es para conectar con la base de datos
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// // 👉 CORS
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//         policy =>
//         {
//             // policy.WithOrigins("http://localhost:4200")
//             //       .AllowAnyHeader()
//             //       .AllowAnyMethod();
//              policy.AllowAnyOrigin()
//                   .AllowAnyMethod()
//                   .AllowAnyHeader();
//         });
// });

// var app = builder.Build();

// // 👉 Swagger solo en Development
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
//         c.RoutePrefix = string.Empty; // hace que abra en http://localhost:5122/
//     });
// }

// app.UseCors("AllowAll");

// app.UseAuthorization();

// app.MapControllers();

// app.Run();

using Microsoft.EntityFrameworkCore;
using SIGU.API.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 👉 Controllers
builder.Services.AddControllers();

// 👉 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
});

// 👉 Base de datos PostgreSQL
builder.Services.AddDbContext<SiguContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 👉 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// 👉 Swagger solo en Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
        c.RoutePrefix = string.Empty; // Swagger en http://localhost:5122/
    });
}

// ⚠️ IMPORTANTE: colocar en este orden

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
