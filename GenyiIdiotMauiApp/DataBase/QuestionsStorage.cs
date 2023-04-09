using GenyiIdiotMauiApp.Model;

namespace GenyiIdiotMauiApp.DataBase
{
    public class QuestionsStorage
    {
        static readonly string filename = "questions.json";
        static readonly string pathToQuestions = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), filename);
        

        public static void AddQuestion(Question question)
        {
            
            var options = new JsonSerializerOptions { WriteIndented = true };
            var questionsJson = DataDealer.GetDataFromJson(pathToQuestions).Result;
            var questionsList = JsonSerializer.Deserialize<List<Question>>(questionsJson);
            questionsList.Add(question);
            questionsJson = JsonSerializer.Serialize(questionsList, options);
            _ = DataDealer.SaveData(pathToQuestions, questionsJson);
        }

        public static void RemoveQuestion(Question question)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var questionsJson = DataDealer.GetDataFromJson(pathToQuestions).Result;
            var questionsList = JsonSerializer.Deserialize<List<Question>>(questionsJson);
            questionsList.Remove(question);
            
            questionsJson = JsonSerializer.Serialize(questionsList, options);
            _ = DataDealer.SaveData(pathToQuestions, questionsJson);
        }
    }
}
