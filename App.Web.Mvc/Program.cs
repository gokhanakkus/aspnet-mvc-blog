using App.Web.Data.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Auth/Login";
    x.LogoutPath = "/Auth/Logout";
    x.Cookie.Name = "Login";
    x.Cookie.MaxAge = TimeSpan.FromDays(1);
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", p => p.RequireClaim("Role", "Admin"));
    x.AddPolicy("ModeratorPolicy", p => p.RequireClaim("Role", new string[] { "Moderator", "Admin" }));
    x.AddPolicy("UserPolicy", p => p.RequireClaim("Role", "User"));
});

var app = builder.Build();

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
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "BlogRoute",
    pattern: "Blog/{title}-{id}/{action=Detail}/",
    new { controller = "Blog", action = "Detail", title = "" },
    new { id = @"^\d+$" }
    );
app.MapControllerRoute(
    name: "CategoryRoute",
    pattern: "Category/{title}-{id}/{action=Index}/",
    new { controller = "Category", action = "Index", title = "" },
    new { id = @"^\d+$" }
    );

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.EnsureDeletedAsync();

    if (await context.Database.EnsureCreatedAsync())
    {
        DbSeeder.Seed(context);
    }
}

app.Run();