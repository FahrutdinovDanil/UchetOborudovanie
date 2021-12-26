using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Core
{
    public class DataReceive
    {
        public static UchetEntities connection = new UchetEntities();
        public List<Employee> GetEmployees()
        {
            return new List<Employee>(connection.Employee);
        }
        public List<Equipment> GetEquipments()
        {
            return new List<Equipment>(connection.Equipment);
        }
        public List<Production_plot> GetPlots()
        {
            return new List<Production_plot>(connection.Production_plot);
        }
        public List<Equipment> GetEquipments(int Id_plot)
        {
            ObservableCollection<Equipment> equipments = new ObservableCollection<Equipment>(bd_connection.connection.Equipment);

            return equipments.Where(a => a.Id_plot == Id_plot).ToList();
        }

        public Equipment GetEquipment(string name)
        {
            List<Equipment> equipments = GetEquipments();
            return equipments.Where(t => t.Name_equipment == name).FirstOrDefault();
        }
        public bool AddNewTechnical_inspection(Technical_inspection inspection)
        {
            try
            {
                bd_connection.connection.Technical_inspection.Add(inspection);
                bd_connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Equipment_failure> GetFailure()
        {
            return new List<Equipment_failure>(connection.Equipment_failure);
        }

        public bool AddNewTechnical_inspection(DateTime newDate_inspection, string newResult,/* int newId_employee*/ int newId_equipment, bool newDone, string newStatus)
        {
            try
            {
                Technical_inspection inspection = new Technical_inspection
                {
                    Date_inspection = newDate_inspection,
                    Result = newResult,
                    Id_equipment = newId_equipment,
                    Done = newDone,
                    Status = newStatus
                };

                bd_connection.connection.Technical_inspection.Add(inspection);
                bd_connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Technical_inspection> GetTechnical_inspection()
        {
            return new List<Technical_inspection>(bd_connection.connection.Technical_inspection); ;
        }

        //public List<Request> GetRequests(User user)
        //{
        //    List<Request> requests = GetRequests();
        //    List<Request> currentUserRequests = requests.Where(r => r.IdUser == user.IdUser).ToList();
        //    return currentUserRequests;
        //}
    }
}

