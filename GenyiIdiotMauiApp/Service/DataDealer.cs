using System.Text;

using Microsoft.Maui.Storage;

namespace GenyiIdiotMauiApp.Model
{
    public class DataDealer
    {

        public static async Task<bool> SaveData(string filename, string data)
        {

            //using Stream stream = FileSystem.OpenAppPackageFileAsync(filename).Result;

            //using var writer = new StreamWriter(stream, Encoding.UTF8);

            //File.OpenWrite(filename);
            await File.WriteAllTextAsync(filename, data);
            
            return true;
        }

        public async static Task<string> GetDataFromJson(string filename)
        {
            
                try
                {
                //using var stream = FileSystem.OpenAppPackageFileAsync(filename).Result;
                //using var reader = new StreamReader(stream);
                //var data = await reader.ReadToEndAsync();
                var data = File.ReadAllText(filename, Encoding.UTF8);
                return data;
                }
                catch (IOException)
                {
                    return string.Empty;
                }
        }

        public static async void PreLoadData() 
        {
            var questions = "questions.json";
            var results = "results.json";
            var diagnoses = "diagnoses.json";

            var pathToQuestions = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), questions);
            var pathToResults = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), results);
            var pathToDiagnoses = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), diagnoses);
            var pathToSettings = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.json");

            using var qStream = FileSystem.OpenAppPackageFileAsync(questions).Result;
            using var qReader = new StreamReader(qStream);
            var originalQuestions = await qReader.ReadToEndAsync();
            if (!File.Exists(pathToQuestions))
            {
                File.WriteAllText(pathToQuestions, originalQuestions);
            }

            using var rStream = FileSystem.OpenAppPackageFileAsync(results).Result;
            using var rReader = new StreamReader(rStream);
            var originalResults = await rReader.ReadToEndAsync();
            if (!File.Exists(pathToDiagnoses))
            {
                File.WriteAllText(pathToResults, originalResults);
            }

            using var dStream = FileSystem.OpenAppPackageFileAsync(diagnoses).Result;
            using var dReader = new StreamReader(dStream);
            var originalDiagnoses = await dReader.ReadToEndAsync();
            if (!File.Exists(pathToDiagnoses))
            {
                File.WriteAllText(pathToDiagnoses, originalDiagnoses);
            }

            //var options = new JsonSerializerOptions { WriteIndented = true };
            //var settings = JsonSerializer.Serialize(new GameSettings(), options);
            //if (!File.Exists(pathToSettings))
            //{
            //    File.WriteAllText(pathToSettings, settings);
            //}

            if (!Preferences.ContainsKey("inGameQuestionsCountDefault"))
            {
                Preferences.Set("inGameQuestionsCountDefault", 10);
            }
            if (!Preferences.ContainsKey("timePerQuestionDefault"))
            {
                Preferences.Set("timePerQuestionDefault", 10);
            }
            

        }
            
    }
}
