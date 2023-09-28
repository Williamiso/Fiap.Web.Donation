using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.Web.Donation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("databaseUrl");
            builder.Services.AddDbContext<DataContext>(options =>

                options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true));

            builder.Services.AddSession();

            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}