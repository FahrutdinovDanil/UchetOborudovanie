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
using System.Windows.Shapes;
using Core;
using System.Collections.ObjectModel;

namespace WpfUchet
{
    /// <summary>
    /// Interaction logic for WindowEquipment.xaml
    /// </summary>
    public partial class WindowEquipment : Window
    {
        public List<Equipment> equipments { get; set; }
        public ObservableCollection<Production_plot> plots { get; set; }
        
        public WindowEquipment()
        {
            InitializeComponent();
            plots = DataReceive.GetPlots();
            this.DataContext = this;
        }

        private void btnReadyClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        private void cbPlotTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = cbPlotType.SelectedItem as Production_plot;
            equipments = DataReceive.GetEquipments(t.Id_plot);
            lvEquipments.ItemsSource = equipments;
        }
    }
}
