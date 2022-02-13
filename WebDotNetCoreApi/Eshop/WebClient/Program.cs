using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(p =>
                {
                    p.Cookie.Name = "cse.net.vn";
                    p.LoginPath = "/auth/login";
                    p.AccessDeniedPath = "/auth/denied";
                    p.ExpireTimeSpan = TimeSpan.FromDays(30);
                });

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();
app.UseStaticFiles();

//
app.UseAuthentication();
app.UseAuthorization();

//


app.MapControllerRoute(name: "dashboard", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
app.Run();
