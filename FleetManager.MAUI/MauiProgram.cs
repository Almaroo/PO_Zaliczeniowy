using FleetManager.MAUI.Data;
using BlazorLeafletMap.Extensions;
using FleetManager.YachtsContext;

namespace FleetManager.MAUI;

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

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<FleetManagerContext>();
		builder.Services.AddBlazorLeafletMap();

		return builder.Build();
	}
}
