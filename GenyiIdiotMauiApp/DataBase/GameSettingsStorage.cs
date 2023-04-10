using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenyiIdiotMauiApp.Model;

namespace GenyiIdiotMauiApp.DataBase
{
    internal class GameSettingsStorage
    {
        static readonly string pathToSettings = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.json");

        public static void SaveSettings(GameSettings settings)
        {
            if (settings == null)
            {
                Preferences.Set("inGameQuestionsCountByUser", settings.InGameQuestions);
                Preferences.Set("timePerQuestionByUser", settings.TimeForOneQuestion);
            }
            else
            {
                Preferences.Set("inGameQuestionsCountByUser", settings.InGameQuestions);
                Preferences.Set("timePerQuestionByUser", settings.TimeForOneQuestion);
            }
        }

        public static GameSettings LoadSettings()
        {
            var questionsCountByUser = Preferences.Get("inGameQuestionsCountByUser", Preferences.Get("inGameQuestionsCountDefault", 10));
            var timePerQuestionByUser = Preferences.Get("timePerQuestionByUser", Preferences.Get("timePerQuestionDefault", 10));
            GameSettings settings = new GameSettings(questionsCountByUser, timePerQuestionByUser);
            return settings;
        }
    }
}
