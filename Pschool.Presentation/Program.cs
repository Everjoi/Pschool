using AspNetCoreRateLimit;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi.Models;
using Pschool.Application.Extensions;
using Pschool.Infrastructure.Data.Contexts;
using Pschool.Infrastructure.Extention;
using Pschool.Presentation.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pschool.Application.Mappings;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Logging.AddConsole();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration, builder.Host);
builder.Services.AddDbContext<PschoolPersonContext>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7086")
    });

//builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly, typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixedWindow", opt =>
    {
        opt.Window = TimeSpan.FromSeconds(1);
        opt.QueueLimit = 10;
        opt.PermitLimit = 10;
        opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;

    }).RejectionStatusCode = 429;

});

//swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Pschool", Version = "v1" });
});



var app = builder.Build();
DatabaseManagementService.MigrationInitialization(app);
app.UseSession();
app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.MapControllerRoute(
                name: "default",
                pattern: "/swagger/index.html");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.MapRazorPages();

app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();




app.Run();
