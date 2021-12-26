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

namespace WpfUchet.Pages
{
    /// <summary>
    /// Interaction logic for Employee_menu.xaml
    /// </summary>
    public partial class Employee_menu : Page
    {
        public DataReceive dataReceive { get; set; }
        public List<Equipment_failure> failure { get; set; }
        public Employee_menu()
        {
            dataReceive = new DataReceive();
            failure = dataReceive.GetFailure();
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
                int Id_equipment = dataReceive.GetEquipment(btnEquipment.Content.ToString()).Id_equipment;
                bool Done = true;
                string Status = (Status_State.SelectedItem as Equipment_failure).Reason;
                if (dataReceive.AddNewTechnical_inspection(Date_inspection, Result,/* int newId_employee*/ Id_equipment, Done, Status))
                {
                    NavigationService.GoBack();
                }
            }
            catch
            {
                
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Back(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void ViewEquipment_Click(object sender, RoutedEventArgs e)
        {
            WindowEquipment window = new WindowEquipment();
            window.Show();
        }
    }
}
