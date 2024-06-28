using BLL.Extensions;
using DAL.Data;
using server.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.ConfigureBusinessLayerServices(builder.Configuration);
builder.Services.ConfigureDataAccessLayer();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
   
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("EduCheckOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
