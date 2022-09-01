
using BlazorOne.DbOjects;
using BlazorOne.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlazorOne.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IUserServices, UserServices>();
//builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<EmployeeDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
   // .AddEntityFrameworkStores<BlazorOneContext>();
//builder.Services.AddDbContext<BlazorOneContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<BlazorOneContext>();                             
builder.Services.AddScoped<IEmpServices, EmpServices>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<EmployeeDBContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;
app.Run();
