using Microsoft.Maui.Platform;
using GenyiIdiotMauiApp.Model;
using GenyiIdiotMauiApp.DataBase;
using System.Threading;
using GeniyIdiotMauiApp.Service;
using Microsoft.Maui.Dispatching;

namespace GenyiIdiotMauiApp.View;

public partial class PlayGamePage : ContentPage
{
    //todo Возможность в конце посмотреть неправильные вопросы
	Dictionary<Question, string> wrongAnswers = new();
	List<Question> questions = new();
	List<Question> questionsToAsk = new List<Question>();
    int timePerQuestion = Preferences.Get("timePerQuestionByUser", Preferences.Get("timePerQuestionDefault", 10));
    int questionsCount = Preferences.Get("inGameQuestionsCountByUser", Preferences.Get("inGameQuestionsCountDefault", 10));
    Random random = new();
	int questionNumber = 1;
    private static System.Timers.Timer timer;
    Result result = new();
    Question question;
    IDispatcher dispatcher;
    

    public PlayGamePage(IDispatcher dispatcherProvider)
	{
        this.dispatcher = dispatcherProvider;
		InitializeComponent();
		LoadQuestions();
        OnStartGame();
    }

    private void LoadQuestions()
	{
        questions = QuestionsStorage.GetAllQuestions();
    }
	
	public void SendAnswer_Clicked(object sender, EventArgs e)
	{
        int userAnswer = 0;
        questionNumber++;
        result.QuestionsAsked++;
        questionsToAsk.Remove(question);
        if (!string.IsNullOrEmpty(answerField.Text))
        {
            try
            {
                userAnswer = int.Parse(answerField.Text);
            }
            catch (ArgumentException)
            {

            }
            if (question.Answer == userAnswer)
            {
                result.CorrectAnswersCount++;
            }
            else
            {
                wrongAnswers.Add(question, userAnswer.ToString());
            }
        }
        else
        {
            wrongAnswers.Add(question, "время вышло!");
        }
        if (questionsToAsk.Count > 0)
        {
            ShowQuestion();
            
        }
        else
        {
            result.Diagnosis = DiagnosisStorage.GetDiagnosisByResult(result.CorrectAnswersCount, questionsCount);
            timer.Stop();
            AskName();
            questionsToAsk.Clear();
            if (result.Name != "")
            {
                ResultStorage.AddResult(result);
                EndGame();
            }
            else
            {
                EndGame();
            }
        }
    }

    async void AskName()
    {
        var name = await DisplayPromptAsync("Игра окончена!", $"Вы ответили на {result.CorrectAnswersCount} из {questionsCount} вопросов.\nВаш диагноз: {result.Diagnosis}", "Сохранить результат", "Не сохранять", "Введите имя", 20, default, "");
        if (name != null)
        {
            result.Name = name;
        }
    }
    private void ResetTimer()
    {
        timer.Stop();
        timePerQuestion = 10;
    }

	private void OnStartGame()
	{
        timer = new System.Timers.Timer(timePerQuestion * 100);
        timer.Elapsed += Timer_Tick;
        timer.Start();
        timer.Enabled = true;
        questionsToAsk = GenerateQuestionsList(questionsCount);
        ShowQuestion();
    }

    private void ShowQuestion()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ResetTimer();
            questionLabel.Text = $"Вопрос {questionNumber} из {questionsCount}:";
            question = GenerateNextQuestion();
            questionTextLabel.Text = question.Text;
            answerField.Text = string.Empty;
            answerField.Focus();
        });
        timer.Start();
    }

	private List<Question> GenerateQuestionsList(int questionsCount)
	{
		var generatedQuestions = new List<Question>();
        var tempQuestions = new List<Question>();
        tempQuestions.AddRange(questions);
        for (int i = 0; i < questionsCount; i++)
		{
			var index = random.Next(0, tempQuestions.Count);
			generatedQuestions.Add(tempQuestions[index]);
			tempQuestions.RemoveAt(index);
		}
		return generatedQuestions;
	}

	private Question GenerateNextQuestion()
	{
        question = questionsToAsk.ElementAt(random.Next(0, questionsToAsk.Count));
		questionsToAsk.Remove(question);
		return question;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        timePerQuestion--;

        //sendAnswerButton.Text = $"Отправить ({timePerQuestion} {secondsSpelling(timePerQuestion)})";
        MainThread.BeginInvokeOnMainThread(() =>
        {
            sendAnswerButton.Text = $"Ответить ({timePerQuestion} {secondsSpelling(timePerQuestion)})";
        });
        if (timePerQuestion == 0)
        {
            timer.Stop();
            timePerQuestion = 10;
            SendAnswer_Clicked(sender, new EventArgs());
        }
    }

    private string secondsSpelling(int num)
    {
        string seconds = "";
        switch (num)
        {
            case 0:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                seconds = "секунд";
                break;
            case 1:
                seconds = "секунда";
                break;
            case 2:
            case 3:
            case 4:
                seconds = "секунды";
                break;
        }
        return seconds;
    }

    private async void EndGame()
    {
        while (Navigation.NavigationStack.Count > 1)
        {
            Navigation.RemovePage(Navigation.NavigationStack[1]);
        }

        await dispatcher.DispatchAsync(() => Shell.Current.Navigation.PopToRootAsync(true));
        //Shell.Current.GoToAsync(nameof(MainPage));
    }
}