using InlamningDatalagring.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.Services
{
    public static class StaticDataService
    {
        public static ObservableCollection<ErrandModel> ErrandsList { get; set; } = new ObservableCollection<ErrandModel>();

        public static DataService DataService = new DataService();

        public static string SelectedStatus { get; set; } = null!;
        public static void SetErrandList()
        {

        }
    }
}
