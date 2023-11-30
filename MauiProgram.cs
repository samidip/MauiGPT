using ChatGptNet;
using ChatGptNet.Models;
using Telerik.Maui.Controls.Compatibility;

namespace MauiGPT;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseTelerik()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddChatGpt(options =>
        {
            options.UseOpenAI(apiKey: "<Your OpnAI API Key>");

            options.DefaultModel = OpenAIChatGptModels.Gpt35Turbo;
            options.MessageLimit = 16;  
            options.MessageExpiration = TimeSpan.FromMinutes(5);
        });

        return builder.Build();
	}
}

