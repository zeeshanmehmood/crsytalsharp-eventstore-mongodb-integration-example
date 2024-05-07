using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrystalSharp;
using CrystalSharp.MongoDb.Extensions;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.CommandHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string eventStoreConnectionString = builder.Configuration.GetConnectionString("AppEventStoreConnectionString");
string eventStoreDatabase = "crystalsharp-eventstore-example";
MongoDbSettings eventStoreDbSettings = new(eventStoreConnectionString, eventStoreDatabase);

CrystalSharpAdapter.New(builder.Services)
    .AddCqrs(typeof(CreateProductCommandHandler))
    .AddMongoDbEventStoreDb<string>(eventStoreDbSettings)
    .CreateResolver();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
