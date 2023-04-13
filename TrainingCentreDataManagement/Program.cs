using Microsoft.EntityFrameworkCore;
using TrainingCentreDataManagement.Models;
using TrainingCentreDataManagement.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDb>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<BatchRepository>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<FacultyRepository>();
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
    pattern: "{controller=Batch}/{action=Index}/{id?}");

app.Run();
