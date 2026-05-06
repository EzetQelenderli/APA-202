namespace _26_DynamicPropertiesViewModell
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            //app.MapControllerRoute(
            //   "Corporative",
            //   "Korporativ-satislar",
            //   new {controller="home",action="corporativesales"}
            //   );

            app.MapControllerRoute(
                "default",
                "{controller=home}/{action=index}/{id?}"
                );
            app.Run();
        }
    }
}
