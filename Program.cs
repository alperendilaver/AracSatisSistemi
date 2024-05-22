using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Concreate;
using yazilim_mimari.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AracSatisContext>(options=>{
    var config = builder.Configuration;
     var connectionString=config.GetConnectionString("mysql");
     var version= new MySqlServerVersion(new Version(8,2,0));
    options.UseMySql(connectionString,version);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>
{options.LoginPath="/Kullanici/Login";
options.AccessDeniedPath="/Kullanici/Login";
});//cookie kullanacağımızı uygulamaya söyledik

builder.Services.AddAuthorization(options=>{
    options.AddPolicy("AdminPolicy",policy=>policy.RequireRole("Admin"));
    
    options.AddPolicy("UserPolicy",policy=>policy.RequireRole("Uye"));
});
builder.Services.AddScoped<IUserService,EfUserService>();
builder.Services.AddScoped<IIlanService,EfIlanService>();
builder.Services.AddScoped<IRequestService,EfRequestService>();
builder.Services.AddScoped<IAdminService,EfAdminService>();
builder.Services.AddScoped<ICommentService,EfCommentService>();
builder.Services.AddScoped<IGorselService,EfGorselService>();
builder.Services.AddScoped<ISearchService,EfSearchService>();
builder.Services.AddScoped<IGetMarkServie,EfGetMarkService>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ilan}/{action=Index}/{id?}");

app.Run();
