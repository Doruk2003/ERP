using Admin.Application;
using Admin.Infrastructure.Extensions;
using BlazorServer;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Application;
using Shared.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Configuration
// --------------------
builder.Services.Configure<MongoDbOptions>(
    builder.Configuration.GetSection(MongoDbOptions.SectionName)
);

// --------------------
// MongoDB
// --------------------
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var options = sp.GetRequiredService<IOptions<MongoDbOptions>>().Value;
    return new MongoClient(options.ConnectionString);
});

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var options = sp.GetRequiredService<IOptions<MongoDbOptions>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(options.Database);
});

// --------------------
// MediatR (STABİL / ENDÜSTRİ STANDARDI)
// --------------------
builder.Services.AddMediatR(
    typeof(Admin.Application.AssemblyMarker),
    typeof(Shared.Application.AssemblyMarker)
);

// --------------------
// Infrastructure
// --------------------
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddAdminInfrastructure();

// --------------------
// Blazor
// --------------------
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

// --------------------
// Pipeline
// --------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAntiforgery();

// app.MapRazorComponents<BlazorServer.App>().AddInteractiveServerRenderMode();
// app.MapRazorComponents<global::App>().AddInteractiveServerRenderMode();
app.MapRazorComponents<BlazorServer.Components.App>().AddInteractiveServerRenderMode();

app.Run();

// --------------------
// Options
// --------------------
public sealed class MongoDbOptions
{
    public const string SectionName = "MongoDb";

    public string ConnectionString { get; init; } = null!;
    public string Database { get; init; } = null!;
}
