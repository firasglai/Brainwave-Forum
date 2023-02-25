using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyForum.DAL;
using MyForum.BL.Entities;
using MyForum.BL.Interfaces;
using MyForum.Web.Services;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyForumDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>(options => { options.SignIn.RequireConfirmedAccount = true; options.User.RequireUniqueEmail = true; })// ensure that all users have unique email addresses and ConfirmedAccounts
    .AddEntityFrameworkStores<MyForumDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

/*Manual Services Section (Transient or Scoped)*/
builder.Services.AddScoped<IForum, ForumService>();
builder.Services.AddScoped<IPost, PostService>();
builder.Services.AddScoped<IUser, UserService>();

// Configure Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ModeratorOnly", policy =>
        policy.RequireRole("Moderator"));
});

// Configure Roles (Moderator and Visitor)
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Create the "Moderator" role if it doesn't already exist
        if (!await roleManager.RoleExistsAsync("Moderator"))
        {
            await roleManager.CreateAsync(new IdentityRole("Moderator"));
        }

        // Create the "Visitor" role if it doesn't already exist
        if (!await roleManager.RoleExistsAsync("Visitor"))
        {
            await roleManager.CreateAsync(new IdentityRole("Visitor"));
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating the roles.");
    }
}

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*Uploading Images
builder.Services.AddSingleton<IFileProvider>(
new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"))
);
app.UseStaticFiles();
*/
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
