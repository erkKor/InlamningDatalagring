using InlamningDatalagring.MVVM.Models;
using InlamningDatalagring.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InlamningDatalagring.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ErrandsView.xaml
    /// </summary>
    public partial class ErrandsView : UserControl
    {
        public ErrandsView()
        {
            InitializeComponent();
        }

        private void lv_MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ErrandModel errandModel = (ErrandModel)lv_MyListView.SelectedItem;
            if (errandModel != null) 
            {
                comboBox.SelectedValue = errandModel.Status;
                StaticDataService.SelectedStatus = errandModel.Status;
                sp_ErrandInfo.Visibility = Visibility.Visible;
                sp_Comments.Visibility = Visibility.Visible;
                lv_MyListView.Visibility = Visibility.Hidden;
            }
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StaticDataService.SelectedStatus != null)
                StaticDataService.SelectedStatus = (comboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
           
            //test. = StaticDataService.SelectedStatus;
            //if (StaticDataService.SelectedStatus != null)
            //    StaticDataService.SelectedStatus = (string)comboBox.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
