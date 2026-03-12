using LegoSiteClientAccess.Components;
using System.Net;

namespace LegoSiteClientAccess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }

        public static void TestConnection()
        {
            Console.WriteLine("https://localhost:7156/SetGallery");
        }
        public static string SendGetRequest(string incomingURL)
        {
            string json = "";
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(incomingURL);
                var result = client.GetAsync(endpoint).Result;
                json = result.Content.ReadAsStringAsync().Result;
            }
            return json;
        }
    }
}
