using GenyiIdiotMauiApp.ViewModel;
using GenyiIdiotMauiApp.Model;
using GenyiIdiotMauiApp.Service;
using Microsoft.Maui.Controls.Platform;

namespace GenyiIdiotMauiApp.View;

[QueryProperty(nameof(Question), "Question")]
public partial class QuestionEditPage : ContentPage
{

	readonly Question question;
    readonly QuestionService questionService;
    

    public QuestionEditPage(QuestionEditViewModel viewModel, QuestionService service)
	{
		InitializeComponent();
		BindingContext = viewModel;
        questionService = service;
        

    }

    

    private void SaveChangesButton_Clicked(object sender, EventArgs e)
    {

        Question editedQuestion = new()
        {
            Text = questionEditPageTextEditor.Text,
            Answer = int.Parse(questionEditPageAnswerEditor.Text)
        };
        if (QuestionService.EditQuestion(question, editedQuestion))
        {
            DisplayAlert("Сохранение успешно!", "Новый вопрос успешно добавлен!", "OK");
        }
        
        
    }

    private void DeleteQuestionButton_Clicked(object sender, EventArgs e)
    {
        if(QuestionService.DeleteQuestion(question))
        {
            DisplayAlert("Удаление успешно!", "Вопрос успешно удален!", "OK");
        }
    }

}