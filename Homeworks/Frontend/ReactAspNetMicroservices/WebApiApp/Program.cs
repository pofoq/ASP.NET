using WebApiApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS Policies here
builder.Services.AddCorsPolicy();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS Middleware here
app.UseCors(ApiCorsPolicies.AllowSpecificOrigins);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
