using Microsoft.EntityFrameworkCore;
using TaskService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<TaskDbContext0013>(options =>
    options.UseInMemoryDatabase("TaskDb"));

// Add HttpClient for calling EventService
builder.Services.AddHttpClient("EventService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5001");
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();