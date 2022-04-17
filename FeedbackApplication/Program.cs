using FeedbackApplication.Models;
using FeedbackApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString(builder.Environment.IsDevelopment() ? "DevelopmentConnection" : "ProductionConnection")));
builder.Services.BuildServiceProvider().GetService<ApplicationDbContext>()?.Database.Migrate();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options => options.AddPolicy("AllowClientApp", 
    policy => policy
        .WithOrigins(builder.Configuration.GetValue<string>(builder.Environment.IsDevelopment() ? 
            "DevelopmentClientAppUrl" 
            : "ProductionClientAppUrl"))
        .AllowAnyMethod()
        .AllowAnyHeader()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IMessageService, MessageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowClientApp");

app.UseAuthorization();

app.MapControllers();

app.Run();