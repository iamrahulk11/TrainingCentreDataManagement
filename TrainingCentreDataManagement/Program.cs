using Microsoft.EntityFrameworkCore;
using TrainingCentreDataManagement.Models;
using TrainingCentreDataManagement.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDb>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddScoped<IBatch,BatchRepository>();
builder.Services.AddScoped<Istudent,StudentRepository>();
builder.Services.AddScoped<IFaculty,FacultyRepository>();
/*builder.Services.AddScoped<IBatch>();
builder.Services.AddScoped<IFaculty>();
builder.Services.AddScoped<Istudent>();*/

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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Batch}/{action=Index}/{id?}");

app.Run();
