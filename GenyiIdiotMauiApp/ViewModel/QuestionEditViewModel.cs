using GenyiIdiotMauiApp.Model;

namespace GenyiIdiotMauiApp.ViewModel
{
    [QueryProperty(nameof(Question), "Question")]
    public partial class QuestionEditViewModel : BaseViewModel
    {
        
        public QuestionEditViewModel() { }

        [ObservableProperty]
        Question question;

    }
}
