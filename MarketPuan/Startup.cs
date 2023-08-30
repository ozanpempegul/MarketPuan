using MarketPuan.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketPuan
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
