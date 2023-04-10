using GenyiIdiotMauiApp.Service;
using GenyiIdiotMauiApp.Model;
using GenyiIdiotMauiApp.View;

namespace GenyiIdiotMauiApp.ViewModel
{
    public partial class QuestionViewModel : BaseViewModel
    {
        public ObservableCollection<Question> Questions { get; } = new();
        //public bool IsRefreshing { get; private set; }

        readonly QuestionService questionService;

        [ObservableProperty]
        bool isRefreshing;

        public QuestionViewModel(QuestionService questionService) : base()
        {
            //Title = "Questions";
            this.questionService = questionService;
        }


        [RelayCommand]
        async Task GetQuestionsAsync()
        {
            if(IsBusy) 
                return;
            try
            {
                IsBusy = true;
                var questions = await QuestionService.GetQuestions();

                if (Questions.Count != 0)
                {
                    Questions.Clear();
                }
                foreach (var question in questions)
                {
                    Questions.Add(question);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Questions: {ex.Message}");
                await Shell.Current.DisplayAlert("Error with getting questions!", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToQuestionEditPage(Question question)
        {
            if (question == null)
                return;

            await Shell.Current.GoToAsync(nameof(QuestionEditPage), true, new Dictionary<string, object> { { "Question", question } }); 
        }

        [RelayCommand]
        async Task CreateNewQuestion()
        {
            await Shell.Current.GoToAsync(nameof(QuestionEditPage), true, new Dictionary<string, object> { { "Новый вопрос", new Question() } });
        }

    }
}
