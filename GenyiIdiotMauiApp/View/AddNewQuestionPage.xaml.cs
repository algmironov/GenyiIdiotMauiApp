using GenyiIdiotMauiApp.Model;
using GenyiIdiotMauiApp.Service;

namespace GenyiIdiotMauiApp.View;

public partial class AddNewQuestionPage : ContentPage
{
    
    public AddNewQuestionPage()
	{
		InitializeComponent();
	}

    private void SaveQuestionButton_Clicked(object sender, EventArgs e)
    {
		Question question = new Question();
		question.Text = questionInputTextEditor.Text;
		question.Answer = int.Parse(questionInputAnswerEditor.Text);
		if (QuestionService.AddQuestion(question))
		{
			DisplayAlert("Сохранено!", "Новый вопрос сохранен успешно!", "OK");
            questionInputTextEditor.Text = String.Empty;
            questionInputAnswerEditor.Text = String.Empty;
        }
    }
}