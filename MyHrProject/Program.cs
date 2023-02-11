using Microsoft.EntityFrameworkCore;
using MyHrProject.Data;
using MyHrProject.Services.Implementation;
using MyHrProject.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyHrProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyHrProjectContext") ?? throw new InvalidOperationException("Connection string 'MyHrProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IStaffService, StaffService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
