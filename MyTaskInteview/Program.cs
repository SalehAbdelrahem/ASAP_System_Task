using Application.Contract.Address;
using Application.Contract.Person;
using Application.Contracts.User;
using Application.Features.Persons.Command.CreatePerson;
using Domain;
using Infrastructre.Addresses;
using Infrastructre.Persons;
using InfraStructure.Persons;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyDBContext;
using MyTaskInteview.Helpers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TaskDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddIdentity<Person, IdentityRole>(options =>
{
    // options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<TaskDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddMediatR(config =>
{ config.RegisterServicesFromAssembly(typeof(CreatePersonCommant).Assembly); });





/// ingect
///
//

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonAccountRepository, PersonAccountRepository>();
//

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddCors();
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    ()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors(options =>
//{
//    options.AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader();
//    //.AllowCredentials();

//});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "ASAP System Task");

app.Run();
