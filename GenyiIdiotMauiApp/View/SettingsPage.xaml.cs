namespace GenyiIdiotMauiApp.View;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	public void OnSaveButtonPressed(object sender, EventArgs e)
	{

	}

	public void OnClearButtonPressed(object sender, EventArgs e)
	{

	}

	public async void OnManageQuestionsButtonPressed(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("ManageQuestionsPage");
    }
}