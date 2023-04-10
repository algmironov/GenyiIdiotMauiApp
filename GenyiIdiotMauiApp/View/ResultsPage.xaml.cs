using GenyiIdiotMauiApp.Model;

using Microsoft.Maui.Dispatching;

namespace GenyiIdiotMauiApp.View;

public partial class ResultsPage : ContentPage
{
    IDispatcher dispatcher;
	public ResultsPage(IDispatcher dispatcherProvider)
	{
        this.dispatcher = dispatcherProvider;
		InitializeComponent();
	}



    private async void ExitButton_Clicked(object sender, EventArgs e)
    {
        while (Navigation.NavigationStack.Count > 1)
        {
            Navigation.RemovePage(Navigation.NavigationStack[1]);
        }

        await dispatcher.DispatchAsync(() => Shell.Current.Navigation.PopToRootAsync(true));
    }
}