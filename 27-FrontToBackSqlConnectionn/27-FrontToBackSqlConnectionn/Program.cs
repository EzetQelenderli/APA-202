using _27_FrontToBackSqlConnectionn.Data;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnectionn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=ApaProniaDb;Trusted_Connection=True;TrustServerCertificate=True");
            });



            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
