using BlazorLeafletMap.Extensions;
using FleetManager.DAL.Repositories;
using FleetManager.DAL.Utilities;
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

		builder.Services.AddTransient<FleetManagerContext>();
		builder.Services.AddTransient<YachtsRepository>();
		builder.Services.AddTransient<UnitOfWork>();
		builder.Services.AddBlazorLeafletMap();

		return builder.Build();
	}
}
