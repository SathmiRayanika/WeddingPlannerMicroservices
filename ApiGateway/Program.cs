var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add HttpClients for all services
builder.Services.AddHttpClient("EventService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5001");
});

builder.Services.AddHttpClient("GuestService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5002");
});

builder.Services.AddHttpClient("TaskService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5003");
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