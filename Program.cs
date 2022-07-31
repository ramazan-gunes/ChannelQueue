using ChannelQueue.Abstract;
using ChannelQueue.Dtos;
using ChannelQueue.Queues;
using ChannelQueue.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(x =>
{
    x.AddConsole();
    x.AddDebug();

});

builder.Services.AddSingleton(typeof(ITaskQueue<Product>), typeof(ProductsQueue));
builder.Services.AddHostedService<QueueHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
