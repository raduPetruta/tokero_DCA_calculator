using Microsoft.EntityFrameworkCore;
using tokero_DCA_calculator.Components;
using tokero_DCA_calculator.Components.Service;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddScoped<CryptoService>();
builder.Services.AddScoped<BinanceService>();


builder.Services.AddDbContext<tokero_DCA_calculator.Models.CryptoContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-T5E0QMM\\SQLEXPRESS;Initial Catalog=crypto;Integrated Security=True;Trust Server Certificate=True");
});


builder.Services.AddHttpClient();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



var app = builder.Build();

app.UseCors("AllowAllOrigins");

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
