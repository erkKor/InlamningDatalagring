using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public static ObservableObject currentViewModel = new ErrandsViewModel();

        [RelayCommand]
        private void GoToAddErrand() => CurrentViewModel = new AddErrandViewModel();

        [RelayCommand]
        private void GoToErrands() => CurrentViewModel = new ErrandsViewModel();
    }


}
