using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Core
{
    public static class DataReceive
    {
        //public static UchetEntities connection = new UchetEntities();

        //public List<Employee> GetEmployees()
        //{
        //    return new List<Employee>(connection.Employee);
        //}

        public static List<Production_plot> GetPlots()
        {
            //return new List<Production_plot>(connection.Production_plot);
            List<Production_plot> plots = new List<Production_plot>(bd_connection.connection.Production_plot);
            List<Production_plot> types = new List<Production_plot>();
            foreach (var type in plots)
            {
                types.Add(
                    new Production_plot
                    {
                        Id_plot = type.Id_plot,
                        Name_plot = type.Name_plot
                    });
            }
            return types;
        }
        public static Production_plot GetPlot(int id_plot)
        {
            List<Production_plot> plots = GetPlots();
            var type = plots.Where(tt => tt.Id_plot == id_plot).FirstOrDefault();
            return type;
        }

        public static List<Equipment_failure> GetFailures()
        {
            //return new List<Equipment_failure>(connection.Equipment_failure);
            List<Equipment_failure> failure = new List<Equipment_failure>(bd_connection.connection.Equipment_failure);
            List<Equipment_failure> parts = new List<Equipment_failure>();
            foreach (var part in failure)
            {
                parts.Add(
                    new Equipment_failure
                    {
                        Id_equipment_failure = part.Id_equipment_failure,
                        Reason = part.Reason
                    });
            }
            return parts;
        }
        public static Equipment_failure GetFailure(int id_equipment_failure)
        {
            List<Equipment_failure> failure = GetFailures();
            var Efaiure = failure.Where(bp => bp.Id_equipment_failure == id_equipment_failure).FirstOrDefault();
            return Efaiure;
        }

        public static List<Equipment> GetEquipments()
        {
            //return new List<Equipment>(connection.Equipment);
            List<Equipment> equipment = new List<Equipment>(bd_connection.connection.Equipment);
            List<Equipment> equipments  = new List<Equipment>();
            foreach (var t in equipment)
            {
                equipments.Add(
                    new Equipment
                    {
                        Id_equipment = t.Id_equipment,
                        Name_equipment = t.Name_equipment,
                        Id_plot= t.Id_plot,
                        //Image = t.Image
                    });
            }
            return equipments;
        }

        

        public static List<Equipment> GetEquipments(int Id_plot)
        {
            //ObservableCollection<Equipment> equipments = new ObservableCollection<Equipment>(bd_connection.connection.Equipment);
            List<Equipment> equipments = GetEquipments();
            return equipments.Where(a => a.Id_plot == Id_plot).ToList();
        }


        public static Equipment GetEquipment(string name)
        {
            List<Equipment> equipments = GetEquipments();
            return equipments.Where(t => t.Name_equipment == name).FirstOrDefault();
        }

        public static Equipment GetEquipment(int id_equipment)
        {
            List<Equipment> equipments = GetEquipments();
            return equipments.Where(t => t.Id_equipment == id_equipment).FirstOrDefault();
        }

        public static void DeleteEquipment(int id_equipment)
        {
            List<Equipment> equipments = GetEquipments();
            var equipment = equipments.Where(t => t.Id_equipment == id_equipment).FirstOrDefault();

            bd_connection.connection.Equipment.Remove(equipment);
            bd_connection.connection.SaveChanges();
        }

        public static void UpdateEquipment(int id_equipment, Equipment equipment)
        {

            bd_connection.connection.Equipment.SingleOrDefault(t => t.Id_equipment == id_equipment);
            bd_connection.connection.SaveChanges();

        }

        public static void DeleteEquipment(Equipment equipment)
        {
            bd_connection.connection.Equipment.Remove(equipment);
            bd_connection.connection.SaveChanges();
        }

        public static bool AddNewTechnical_inspection(Technical_inspection inspection)
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

        

        public static bool AddNewTechnical_inspections(DateTime newDate_inspection, string newResult,/* int newId_employee*/ int newId_equipment, bool newDone, string newStatus)
        {
            try
            {
                Technical_inspection inspection = new Technical_inspection()
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
        public static List<Technical_inspection> GetTechnical_inspections()
        {
            List<Technical_inspection> inspection = new List<Technical_inspection>(bd_connection.connection.Technical_inspection);
            List<Technical_inspection> inspections = new List<Technical_inspection>();
            foreach (var r in inspection)
            {
                inspections.Add(
                    new Technical_inspection
                    {
                        Date_inspection = r.Date_inspection,
                        Result = r.Result,
                        Id_equipment = r.Id_equipment,
                        Done = r.Done,
                        Status = r.Status
                    });
            }
            return inspections;
        }

        public static Technical_inspection GetTechnical_inspection(int id_inspection)
        {
            //return new List<Technical_inspection>(bd_connection.connection.Technical_inspection);
            List<Technical_inspection> inspections = GetTechnical_inspections();
            Technical_inspection inspection = inspections.Where(r => r.Id_inspection == id_inspection).FirstOrDefault();
            return inspection;
        }

        //public List<Request> GetRequests(User user)
        //{
        //    List<Request> requests = GetRequests();
        //    List<Request> currentUserRequests = requests.Where(r => r.IdUser == user.IdUser).ToList();
        //    return currentUserRequests;
        //}
    }
}

