using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenyiIdiotMauiApp.Model;
using GenyiIdiotMauiApp.Service;
using GenyiIdiotMauiApp.View;

namespace GenyiIdiotMauiApp.ViewModel
{
    public partial class ResultViewModel : BaseViewModel
    {
        public ObservableCollection<Result> Results { get; } = new();
        readonly ResultService resultService;

        [ObservableProperty]
        bool isRefreshing;

        public ResultViewModel(ResultService resultService) : base()
        {
            this.resultService = resultService;
        }

        [RelayCommand]
        async Task GetResultsAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var results = await resultService.GetResults();

                if (Results.Count != 0)
                {
                    Results.Clear();
                }
                foreach (var result in results)
                {
                    Results.Add(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Results: {ex.Message}");
                await Shell.Current.DisplayAlert("Error with getting results!", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToResultsPage(Result result)
        {
            if (result == null)
                return;

            await Shell.Current.GoToAsync(nameof(ResultsPage), true, new Dictionary<string, object> { { "Result", result } });
        }
    }
}
