using GenyiIdiotMauiApp.View;
using GenyiIdiotMauiApp.Service;
using GenyiIdiotMauiApp.ViewModel;

using Microsoft.Extensions.Logging;
using GenyiIdiotMauiApp.Model;
using GenyiIdiotMauiApp.DataBase;

namespace GenyiIdiotMauiApp;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<QuestionService>();
		builder.Services.AddSingleton<DataDealer>();
		builder.Services.AddSingleton<GameSettingsStorage>();
        builder.Services.AddSingleton<QuestionViewModel>();
        builder.Services.AddSingleton<ResultsPage>();
        builder.Services.AddSingleton<ResultService>();
        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddTransient<PlayGamePage>();
		builder.Services.AddSingleton<ManageQuestionsPage>();
        builder.Services.AddTransient<QuestionEditViewModel>();
        builder.Services.AddTransient<QuestionEditPage>();
		builder.Services.AddSingleton<AddNewQuestionPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
		DataDealer.PreLoadData();
		return builder.Build();
	}
}
