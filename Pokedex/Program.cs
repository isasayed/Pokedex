using Pokedex.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();

builder.Services.AddHttpClient("pokeApi", (serviceProvider, client) =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
});

//! for one base url over the application
//builder.Services.AddScoped(sp => {
//    var client = new HttpClient();
//    client.BaseAddress = new("https://pokeapi.co/api/v2/");
//    return client;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
