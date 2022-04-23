using David__Dawson_Assignment_3.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Giving Postman Access
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
       builder =>
       {
           builder.WithOrigins("https://web.postman.co")
                .AllowAnyHeader()
                .AllowAnyMethod();
       });
});



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GameDbContext>(options =>
      options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<Initializer>();
builder.Services.AddScoped<IPersonRepository, DbPersonRepository>();
builder.Services.AddScoped<IGameRepository, DbGameRepository>();
builder.Services.AddScoped<IPersonGameRepository, DbPersonGameRepository>();

var app = builder.Build();
SeedData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


static void SeedData(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var initializer = services.GetRequiredService<Initializer>();
        initializer.SeedDatabase();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError($"An error occurred while seeding the database: {ex.Message}");
    }
}
