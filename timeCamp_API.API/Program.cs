using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using timeCamp.Infrastructure;
using Microsoft.Identity.Web;
using timeCamp.CommonLogic.Interfaces;
using timecamp.BusinessLogic.Services;
using timecamp.BusinessLogic.HelperServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped<ILoginService, LoginService>();
//builder.Services.AddScoped<IEmailService, EmailServiceHelper>();
builder.Services.AddTransient<IEmailService, EmailServiceHelper>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi((bearerOptions) => { },
    (miOptions) =>
    {
       
        miOptions.ClientId = Environment.GetEnvironmentVariable("Client_Id");
        miOptions.TenantId = Environment.GetEnvironmentVariable("Tenant_Id");
        miOptions.ClientSecret = Environment.GetEnvironmentVariable("Client_Secret");
        miOptions.Domain = Environment.GetEnvironmentVariable("AD_Domain");
        miOptions.CallbackPath = Environment.GetEnvironmentVariable("CallBackPath");
        miOptions.Instance = Environment.GetEnvironmentVariable("Identity_Instance");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowLocalhost3000");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
