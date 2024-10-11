using Dialog.Components;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Dialog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSyncfusionBlazor();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }

        private static void RegisterUILicense(IConfiguration configuration)
        {
            string licenseKey = configuration.GetValue<string>("SyncFusionLicenseKey");

            if (String.IsNullOrWhiteSpace(licenseKey) is false)
            {
                SyncfusionLicenseProvider.RegisterLicense(licenseKey);
            }
        }
    }
}
