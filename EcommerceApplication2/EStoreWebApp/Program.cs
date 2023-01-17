var builder = WebApplication.CreateBuilder(args);
// 
// Add services to the container.
// if below line is commented code will not run.
// dependencies should bge injected before starting

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// middleware configuration
// configure 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    // we are telling to to open  index view of home controller
    // we can also change it.
    // here we can take Home?Index/45
    //45 here represents id
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
