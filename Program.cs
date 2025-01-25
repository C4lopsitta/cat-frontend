using cat_frontend.Controllers;
using CatAPILib.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=IndexKawaii}"
);

app.MapControllerRoute(
    name: "cart",
    pattern: "cart",
    defaults: new { controller = "Cart", action = "Cart"}
);

app.MapControllerRoute(
    name: "home",
    pattern: "home",
    defaults: new { controller = "Home", action = "IndexKawaii" }
);
app.MapControllerRoute(
    name: "payment",
    pattern: "payment",
    defaults: new { controller = "Payment", action = "Payment" }
);
app.MapControllerRoute(
    name: "login",
    pattern: "login",
    defaults: new { controller = "Login", action = "Login" }
);

app.MapControllerRoute(
    name: "cat",
    pattern: "cat/{uid?}",
    defaults: new { controller = "Detail", action = "CatDetail" }
);

app.MapControllerRoute(
    name: "cat",
    pattern: "cat",
    defaults: new { controller = "Detail", action = "CatDetail" }
);
app.MapControllerRoute(
    name: "user",
    pattern: "user",
    defaults: new { controller = "Detail", action = "UserDetail" }
);


app.Run();
