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

namespace WpfUchet.Windows
{
    /// <summary>
    /// Interaction logic for Inspection.xaml
    /// </summary>
    public partial class Inspection : Window
    {
        public List<Technical_inspection> inspections { get; set; }
        public Inspection()
        {
            InitializeComponent();
            inspections = DataReceive.GetTechnical_inspections();
            lvInspection.ItemsSource = inspections;
        }
        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
