using Microsoft.EntityFrameworkCore;
using PersonalSite.Data;
using PersonalSite.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Builds the Connection to the Database for the Default User.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(Config.DefaultConnection ?? throw new InvalidOperationException("Connection string 'PersonalSite' not found."), ServerVersion.AutoDetect(Config.DefaultConnection)));

//Builds the Connection to the Database for the Admin User.
builder.Services.AddDbContext<AdminContext>(options =>
    options.UseMySql(Config.AdminConnection ?? throw new InvalidOperationException("Connection string 'PersonalSite' not found."), ServerVersion.AutoDetect(Config.AdminConnection)));

//Builds the app.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Code to redirect to the Homepage, if a site wasn't found.
//Could be used to redirect to an proper Error 404 Page.
app.Use(async (context, next) => {
    await next();
    if (context.Response.StatusCode == 404) {
        context.Request.Path = "/Home";
        context.Response.Redirect("/");
        await next();
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
