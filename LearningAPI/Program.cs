using LearningAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer(cfg =>
	{
		cfg.RequireHttpsMetadata = false;
		cfg.SaveToken = true;
		cfg.TokenValidationParameters = new TokenValidationParameters
		{

			ValidIssuer = "http://localhost:5000",
			ValidAudience = "http://localhost:5000",
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a-very-long-radonmly-generated-secret-key-that-cannot-be-guessed")),
			ClockSkew = TimeSpan.Zero // remove delay of token when expire
		};
	});




string connectionString = builder.Configuration.GetConnectionString("dev");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
