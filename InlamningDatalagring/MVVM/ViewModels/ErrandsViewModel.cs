using CommunityToolkit.Mvvm.ComponentModel;
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

        [ObservableProperty]
        private string title = "Ärenden";

        [ObservableProperty]
        private ObservableCollection<ErrandModel> errands = StaticDataService.ErrandsList;
    }
}
