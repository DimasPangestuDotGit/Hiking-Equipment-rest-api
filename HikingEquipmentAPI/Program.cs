using HikingEquipment.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HikingEquipmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HikingEquipmentContext"), sqlOptions =>
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,                       
            maxRetryDelay: TimeSpan.FromSeconds(10), 
            errorNumbersToAdd: null                 
        )
    ));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HikingEquipment API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HikingEquipment API V1");
    c.RoutePrefix = string.Empty; 
});

app.Run();