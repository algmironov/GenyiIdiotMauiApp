using GenyiIdiotMauiApp.DataBase;
using GenyiIdiotMauiApp.Model;

namespace GenyiIdiotMauiApp.View;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		OnLoad();

    }

	public void OnSaveButtonPressed(object sender, EventArgs e)
	{
		var inGameQuestions = int.Parse(inGameQuestionsCount.Text);
		var timeForOneQuestion = int.Parse(inGameTimePerQuestion.Text);
		var newSettings = new GameSettings(inGameQuestions, timeForOneQuestion);
		GameSettingsStorage.SaveSettings(newSettings);
	}

	public void OnClearButtonPressed(object sender, EventArgs e)
	{
        Preferences.Set("inGameQuestionsCountByUser", Preferences.Get("inGameQuestionsCountDefault", 10));
        Preferences.Set("timePerQuestionByUser", Preferences.Get("timePerQuestionDefault", 10));

		inGameQuestionsCount.Text = Preferences.Get("inGameQuestionsCountDefault", 10).ToString();
		inGameTimePerQuestion.Text = Preferences.Get("timePerQuestionDefault", 10).ToString();


	}

    public async void OnManageQuestionsButtonPressed(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("ManageQuestionsPage");
    }

	private void OnLoad()
	{
		//var settings = GameSettingsStorage.LoadSettings();
		//inGameQuestionsCount.Text = settings.InGameQuestions.ToString();
		//inGameTimePerQuestion.Text = settings.TimeForOneQuestion.ToString();

		inGameQuestionsCount.Text = Preferences.Get("inGameQuestionsCountDefault", 10).ToString();
		inGameTimePerQuestion.Text = Preferences.Get("timePerQuestionDefault", 10).ToString();

	}
}