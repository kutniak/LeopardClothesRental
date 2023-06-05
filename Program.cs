using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrialLoginAndRegistrationWeb.Models; // +
using TrialLoginAndRegistrationWeb.Areas.Identity.Data;
using System.Configuration;

namespace TrialLoginAndRegistrationWeb
{
    public class Program
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

                                    builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            ///////////////////////////////////////
            ///
            builder.Services.AddDbContext<ApplicationContext>(option => 
                option.UseSqlServer("Server=MAKSYM;Database=Clothes;Trusted_Connection=True;MultipleActiveResultSets=true"));
            builder.Services.AddControllersWithViews();
            
            //////////////////////////////////////


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.MapDefaultControllerRoute(); // +
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
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}