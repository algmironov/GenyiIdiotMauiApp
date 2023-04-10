using GenyiIdiotMauiApp.View;

namespace GenyiIdiotMauiApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(PlayGamePage), typeof(PlayGamePage));
        Routing.RegisterRoute(nameof(ResultsPage), typeof(ResultsPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(ManageQuestionsPage), typeof(ManageQuestionsPage));
        Routing.RegisterRoute(nameof(QuestionEditPage), typeof(QuestionEditPage));
        Routing.RegisterRoute(nameof(AddNewQuestionPage), typeof(AddNewQuestionPage));
        Routing.RegisterRoute(nameof(PlayGamePage), typeof(PlayGamePage));
    }
}
