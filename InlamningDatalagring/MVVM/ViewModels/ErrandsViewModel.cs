using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InlamningDatalagring.Contexts;
using InlamningDatalagring.MVVM.Models;
using InlamningDatalagring.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.MVVM.ViewModels
{
    public partial class ErrandsViewModel : ObservableObject
    {
        public DataService DataService = new DataService();
        private ObservableCollection<ErrandModel> errandsList;
        public ErrandsViewModel()
        {
            //DataService.GetAllAsync();
            LoadCaseAsync();
        }

        [ObservableProperty]
        private string title = "Ärenden";


        public async Task LoadCaseAsync()
        {
            ObservableCollection<ErrandModel> errands = await DataService.GetAllAsync();
            ErrandsList = new ObservableCollection<ErrandModel>(errands);
        }
        //[ObservableProperty]
        //private ObservableCollection<ErrandModel> errands = StaticDataService.ErrandsList;
        
        public ObservableCollection<ErrandModel> ErrandsList
        {
            get { return errandsList; }
            set { SetProperty(ref errandsList, value); }
        }


        [ObservableProperty]
        private ErrandModel selectedErrand = null!;

        [RelayCommand]
        public void UpdateStatus()
        {
            
            DataService.UpdateStatus(selectedErrand, StaticDataService.SelectedStatus);
        }

    }
}
