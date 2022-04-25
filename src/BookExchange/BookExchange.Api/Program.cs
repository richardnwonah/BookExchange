 using Microsoft.AspNetCore.Authentication.JwtBearer;
 using System.IdentityModel.Tokens;
 using Microsoft.IdentityModel.Tokens;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Configuration;
 using BookExchange.Api.Data;
 using BookExchange.Api.Services;
 using System.Text; 
 using BookExchange.Api.Repositories;
 using BookExchange.Api.Helpers;
 using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


 var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>(); 
builder.Services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>(); 
builder.Services.AddScoped<IUserService, UserService>();

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


 app.UseMiddleware<JwtMiddleware>();
 
app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
