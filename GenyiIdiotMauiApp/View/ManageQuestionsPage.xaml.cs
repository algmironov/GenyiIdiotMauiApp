using GenyiIdiotMauiApp.ViewModel;
using GenyiIdiotMauiApp.Model;

namespace GenyiIdiotMauiApp.View;

public partial class ManageQuestionsPage : ContentPage
{
	public ManageQuestionsPage(QuestionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	public void OnLoadQuestionsButtonClick(object sender, EventArgs e)
	{
		
    }

    private void AddQuestion_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(AddNewQuestionPage));
    }
}