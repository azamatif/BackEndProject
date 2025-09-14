using BackEndProject.Data;
using BackEndProject.Models;
using BackEndProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
//    options.SignIn.RequireConfirmedEmail = true;
//})
//.AddEntityFrameworkStores<AppDbContext>()
//.AddDefaultTokenProviders();


object AddEntityFrameworkStores<T>()
{
    throw new NotImplementedException();
}

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();

var app = builder.Build();


// usual pipeline...
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
