﻿using PO_Zaliczeniowy.MAUI.Data;
using BlazorLeafletMap.Extensions;

namespace PO_Zaliczeniowy.MAUI;

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
		builder.Services.AddBlazorLeafletMap();

		return builder.Build();
	}
}
