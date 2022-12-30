using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RazorIntroduction.TagHelpers.Web.DatabaseContexts;
using RazorIntroduction.TagHelpers.Web.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/account/login";
});

builder.Services.AddDbContext<UserDatabaseContext>(options =>
{
    options.UseInMemoryDatabase("UserInMemoryDatabase");
});

var app = builder.Build();

AddUserData(app);

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


static void AddUserData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<UserDatabaseContext>();

    List<User> userList = new() {
        new User{
            Id = new Guid(),
            Username = "user-x",
            Email = "userx@user.com",
            Name = "User",
            Lastname = "X",
            Password = "pass",
            PictureUrl = "/userpictures/userx.jpg",
            Description = "Lorem Ipsum dolor sit amet😍",
            Posts=45,
            Followers = 756,
            Rating =4.7
        },
        new User{
            Id = new Guid(),
            Username = "user-y",
            Email = "usery@user.com",
            Name = "User",
            Lastname = "Y",
            Password = "pass",
            PictureUrl = "/userpictures/usery.jpg",
            Description = "Lorem Ipsum dolor sit amet 💯 ",
            Posts=37,
            Followers = 421,
            Rating =3.2
        },
        new User{
            Id = new Guid(),
            Username = "user-z",
            Email = "userz@user.com",
            Name = "User",
            Lastname = "Z",
            Password = "pass",
            PictureUrl = "/userpictures/userz.jpg",
            Description = "Lorem Ipsum dolor sit amet🔥 ",
            Posts=7,
            Followers = 363,
            Rating =9.5
        },
         new User{
            Id = new Guid(),
            Username = "user-w",
            Email = "userw@user.com",
            Name = "User",
            Lastname = "W",
            Password = "pass",
            PictureUrl = "/userpictures/userw.jpg",
            Description = "Lorem Ipsum dolor sit amet😻 ",
            Posts=12,
            Followers = 1248,
            Rating =5.8
        }
    };

    db.Users.AddRange(userList);

    db.SaveChanges();
}
