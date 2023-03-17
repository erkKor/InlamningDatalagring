using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight.Messaging;
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
using static InlamningDatalagring.MVVM.ViewModels.MainViewModel;

namespace InlamningDatalagring.MVVM.ViewModels
{
    public partial class ErrandsViewModel : ObservableObject
    {
        public DataService DataService = new DataService();

        public ErrandsViewModel()
        {
            LoadCaseAsync();
        }
        #region ErrandList

        [ObservableProperty]
        private ObservableCollection<ErrandModel> errandsList;
        public async Task LoadCaseAsync()
        {
            ObservableCollection<ErrandModel> errands = await DataService.GetAllErrandsAsync();
            ErrandsList = new ObservableCollection<ErrandModel>(errands);
        }
        #endregion
        [ObservableProperty]
        private string title = "Ärenden";
        [ObservableProperty]
        private ErrandModel selectedErrand = null!;
        [ObservableProperty]
        private string commentText = string.Empty;

        [RelayCommand]
        public async void UpdateStatus()
        {
            await DataService.UpdateStatusAsync(SelectedErrand, StaticDataService.SelectedStatus);
        }

        [RelayCommand]
        public async void AddComment()
        {
            string comment = CommentText;
            await DataService.AddCommentAsync(comment, SelectedErrand.ContactId);
            await LoadCaseAsync();
            CommentText = string.Empty;
        }

        //[RelayCommand]
        //public void HomeButton()
        //{
        //    Messenger.Default.Send(new ChangeViewModelMessage(new AddErrandViewModel()));
        //}
    }
}
