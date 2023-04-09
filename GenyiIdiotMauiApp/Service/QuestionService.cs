﻿using System.Text;

using GenyiIdiotMauiApp.DataBase;
using GenyiIdiotMauiApp.Model;

using Microsoft.Maui.Storage;

namespace GenyiIdiotMauiApp.Service
{
    public class QuestionService
    {
        List<Question> questionList = new ();
        string pathToQuestions = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "questions.json");

        public async Task<List<Question>> GetQuestions()
        {
            StreamReader reader = new StreamReader(pathToQuestions, Encoding.UTF8);
            var contents = await reader.ReadToEndAsync();
            questionList = JsonSerializer.Deserialize<List<Question>>(contents);
            return questionList;
        }

        public static bool EditQuestion(Question oldQuestion, Question editedQuestion)
        {
            try
            {
                QuestionsStorage.AddQuestion(editedQuestion);
                QuestionsStorage.RemoveQuestion(oldQuestion);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteQuestion(Question question)
        {
            try
            {
                QuestionsStorage.RemoveQuestion(question);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddQuestion(Question question)
        {
            try
            {
                QuestionsStorage.AddQuestion(question);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}