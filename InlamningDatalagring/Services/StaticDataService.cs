using InlamningDatalagring.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.Services
{
    internal class StaticDataService
    {
        public static ObservableCollection<ErrandModel> ErrandsList { get; set; } = new ObservableCollection<ErrandModel>();

        public DataService DataService = new DataService();

        public static void SetErrandList()
        {

        }
    }
}
