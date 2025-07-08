using fin.server.Data;
using fin.server.Filters;
using fin.server.Repository;
using fin.server.Repository.Interface;
using fin.server.Service;
using fin.server.Service.Interface;

namespace fin.server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var connectionString = builder.Configuration.GetConnectionString("CONNECTION_STRING");
        builder.Services.AddNpgsql<FinContext>(connectionString);
        
        builder.Services.AddScoped<IAuth, AuthRepo>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        
        builder.Services.AddControllers(options =>
        {
            options.Filters.Add(new GlobalExceptionFilter());
        });


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
            pattern: "{controller=Home}/{action=Index}/{id?}");
        
        app.MigrateDB();

        app.Run();
    }
}