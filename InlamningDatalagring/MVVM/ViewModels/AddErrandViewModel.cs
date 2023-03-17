using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InlamningDatalagring.MVVM.Models;
using InlamningDatalagring.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.MVVM.ViewModels
{
    public partial class AddErrandViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Skapa ärende";
        [ObservableProperty]
        private string firstNameText = string.Empty;
        [ObservableProperty]
        private string lastNameText = string.Empty;
        [ObservableProperty]
        private string emailText = string.Empty;
        [ObservableProperty]
        private string phonenumberText = string.Empty;
        [ObservableProperty]
        private string descriptionText = string.Empty;

        [RelayCommand]
        private async void Add()
        {
            var errand = new ErrandModel()
            {
                FirstName = FirstNameText,
                LastName = LastNameText,
                Email = EmailText,
                PhoneNumber = PhonenumberText,
                Description = DescriptionText,
                TimeStamp = DateTime.Now.ToString(),
                
            };

            await DataService.AddErrandAsync(errand);
            FirstNameText = string.Empty;
            LastNameText= string.Empty;
            EmailText= string.Empty;
            PhonenumberText= string.Empty;
            DescriptionText= string.Empty;
        }
    }
}
