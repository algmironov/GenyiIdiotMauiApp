using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenyiIdiotMauiApp.DataBase;
using GenyiIdiotMauiApp.Service;

namespace GenyiIdiotMauiApp.Model
{
    [Serializable]
    internal class GameSettings
    {
        private int inGameQuestions = 10;
        private int timeForOneQuestion = 10;
        public int InGameQuestions {
            get => inGameQuestions;
            set 
            {
                //if (value > QuestionService.GetQuestionsCount().Result) 
                //{
                //    timeForOneQuestion = 10;
                //    //throw new ArgumentException("Number of in game questions is greater than questions count! Parameter has been set to default.");
                //}
                //else if (value <= 0)
                //{
                //    throw new ArgumentException("Number of in game questions cannot be 0 or negative!");
                //}
                //else
                //{
                //    inGameQuestions = value;
                //}
                inGameQuestions = value;
            }
        }

        public int TimeForOneQuestion {
            get => timeForOneQuestion;
            set 
            { 
                //if (value < 5)
                //{
                //    timeForOneQuestion = 10;
                //    throw new ArgumentException("Too low time for one question. Parameter has been set to default.");
                //}
                //else
                //{
                //    timeForOneQuestion = value;
                //}
                timeForOneQuestion = value;
            } 
        } 
        public GameSettings(int inGameQuestions, int timeForOneQuestion) 
        {
            InGameQuestions = inGameQuestions;
            TimeForOneQuestion = timeForOneQuestion;
        }
    }
}
