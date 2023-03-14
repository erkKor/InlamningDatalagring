using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InlamningDatalagring.Contexts;
using InlamningDatalagring.MVVM.Models;
using InlamningDatalagring.MVVM.Models.Entities;
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

        public ErrandsViewModel()
        {
            //DataService.GetAllAsync();
            LoadCaseAsync();
        }
        #region ErrandList

        [ObservableProperty]
        private ObservableCollection<ErrandModel> errandsList;
        public async Task LoadCaseAsync()
        {
            ObservableCollection<ErrandModel> errands = await DataService.GetAllAsync();
            ErrandsList = new ObservableCollection<ErrandModel>(errands);
        }
        
        //public ObservableCollection<ErrandModel> ErrandsList
        //{
        //    get { return errandsList; }
        //    set { SetProperty(ref errandsList, value); }
        //}
        #endregion

        [ObservableProperty]
        private string title = "Ärenden";
        [ObservableProperty]
        private ErrandModel selectedErrand = null!;
        [ObservableProperty]
        private string commentText = string.Empty;

        //[ObservableProperty]
        //private ObservableCollection<ErrandModel> selectedErrandCommentsList = null!;

        [RelayCommand]
        public async void UpdateStatus()
        {
            await DataService.UpdateStatus(SelectedErrand, StaticDataService.SelectedStatus);
        }

        [RelayCommand]
        public async void AddComment()
        {
            string comment = CommentText;
            await DataService.AddCommentAsync(comment, SelectedErrand.ContactId);
            CommentText = string.Empty;
        }

    }
}
