using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenyiIdiotMauiApp.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        //public bool IsBusy { get; set; }

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;

        
    }
}
