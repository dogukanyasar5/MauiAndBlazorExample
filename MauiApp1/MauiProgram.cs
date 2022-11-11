using MauiApp1.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddDevExpressBlazor();
            builder.Services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options => {
                options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
            });
            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}