﻿using GenyiIdiotMauiApp.Model;

namespace GenyiIdiotMauiApp.DataBase
{
    public class ResultStorage
    {
        static readonly string filename = "results.json";
        static readonly string pathToResults = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), filename);


        public static void AddResult(Result result)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            List<Result> resultList = GetListOfResults();
            resultList.Add(result);
            var data = JsonSerializer.Serialize(resultList, options);
            _ = DataDealer.SaveData(pathToResults, data);
        }

        public static List<Result> GetListOfResults()
        {
            var resultsString = DataDealer.GetDataFromJson(pathToResults).Result;
            if (string.IsNullOrEmpty(resultsString))
            {
                return new List<Result>();
            }
            else
            {
                var results = JsonSerializer.Deserialize<List<Result>>(resultsString);
                return results;
            }
            
        }

        public static List<List<string>> GetAllResults()
        {
            List<List<string>> results = new ();
             var resultsString = DataDealer.GetDataFromJson(pathToResults).Result;
            if (!string.IsNullOrEmpty(resultsString))
            {
                var resultsList = JsonSerializer.Deserialize<List<Result>>(resultsString);
                
                foreach (var res in resultsList)
                {
                    List<string> elem = new() { res.Name, res.CorrectAnswersCount.ToString(), res.QuestionsAsked.ToString(), res.Diagnosis };
                    results.Add(elem);
                }

                return results;
            }
            return results;
        }

        public static void ClearResults()
        {
            File.WriteAllText(filename, string.Empty);
        }

        public static void RemoveChoosenResult(Result result)
        {
            var results = GetListOfResults().Where(x =>!x.Equals(result)).ToList();
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize<List<Result>>(results, options);
            _ = DataDealer.SaveData(pathToResults, jsonString);
        }

    }
}
