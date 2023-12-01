using Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\Dapper.WebApi.xml");
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Dapper - Api",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DapperApi");
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();