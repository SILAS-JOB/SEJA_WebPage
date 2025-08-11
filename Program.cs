using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Facebook;


var builder = WebApplication.CreateBuilder(args);

// Autenticação externa (Google, Facebook)

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;

    });
.AddCookie();
.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
            {
                options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
                options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
            });

// builder.Services.AddAuthentication()
//     .AddGoogle(options =>
//     {
//         options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//         options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//     })
//     .AddFacebook(options =>
//     {
//       options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
//       options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
//     });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline de requisição
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // <- Aqui
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
