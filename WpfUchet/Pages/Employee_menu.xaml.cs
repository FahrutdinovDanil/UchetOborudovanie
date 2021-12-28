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
using Core;
using WpfUchet.Windows;
using System.Collections.ObjectModel;

namespace WpfUchet.Pages
{
    /// <summary>
    /// Interaction logic for Employee_menu.xaml
    /// </summary>
    public partial class Employee_menu : Page
    {
        public ObservableCollection<Equipment_failure> failure { get; set; }
        public Employee_menu()
        {
            failure = DataReceive.GetFailures();
            this.DataContext = this;
            InitializeComponent();
        }
        private void btnEquipmentClick(object sender, RoutedEventArgs e)
        {
            WindowEquipment dialog = new WindowEquipment();
            if (dialog.ShowDialog() == true)
            {
                btnEquipment.Content = $"{(dialog.lvEquipments.SelectedItem as Equipment).Name_equipment}";
            }
        }

        private void PerformInspection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime Date_inspection = DateTime.Now;
                string Result = Solution.Text;
                int Id_equipment = DataReceive.GetEquipment(btnEquipment.Content.ToString()).Id_equipment;
                string Employee_name = Employee.Text;
                bool Done = true;
                string Status = (Status_State.SelectedItem as Equipment_failure).Reason;

                if (DataReceive.AddNewTechnical_inspection(Date_inspection, Result, Employee_name, Id_equipment, Done, Status))
                {
                    NavigationService.GoBack();
                }
            }
            catch
            {
                
            }
        }

        private void ViewEquipment_Click(object sender, RoutedEventArgs e)
        {
            WindowEquipment window = new WindowEquipment();
            window.Show();
        }

        private void ViewInspection_Click(object sender, RoutedEventArgs e)
        {
            Inspection window = new Inspection();
            window.Show();
        }
    }
}
