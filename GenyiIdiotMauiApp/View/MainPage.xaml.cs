namespace GenyiIdiotMauiApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void ExitButton_Pressed(object sender, EventArgs e)
	{
		App.Current.Quit();
	}

	private async void SettingsButton_Pressed(Object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("SettingsPage");
	}

	private async void OnStartGamePressed(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("PlayGamePage");
    }

	private async void ShowResultsButton_Pressed(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("ResultsPage");
    }
}

