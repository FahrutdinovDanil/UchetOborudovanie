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

        public static ObservableCollection<Production_plot> GetPlots()
        {
            //List<Production_plot> plots = new List<Production_plot>(bd_connection.connection.Production_plot);
            //List<Production_plot> types = new List<Production_plot>();
            //foreach (var type in plots)
            //{
            //    types.Add(
            //        new Production_plot
            //        {
            //            Id_plot = type.Id_plot,
            //            Name_plot = type.Name_plot
            //        });
            //}
            //return types;
            ObservableCollection<Production_plot> plots = new ObservableCollection<Production_plot>(bd_connection.connection.Production_plot);
            return plots;
        }
        public static Production_plot GetPlot(int id_plot)
        {
            ObservableCollection<Production_plot> plots = GetPlots();
            var type = plots.Where(tt => tt.Id_plot == id_plot).FirstOrDefault();
            return type;
        }

        public static ObservableCollection<Equipment_failure> GetFailures()
        {
            //List<Equipment_failure> failure = new List<Equipment_failure>(bd_connection.connection.Equipment_failure);
            //List<Equipment_failure> parts = new List<Equipment_failure>();
            //foreach (var part in failure)
            //{
            //    parts.Add(
            //        new Equipment_failure
            //        {
            //            Id_equipment_failure = part.Id_equipment_failure,
            //            Reason = part.Reason
            //        });
            //}
            //return parts;
            ObservableCollection<Equipment_failure> failure = new ObservableCollection<Equipment_failure>(bd_connection.connection.Equipment_failure);
            return failure;
        }
        public static Equipment_failure GetFailure(int id_equipment_failure)
        {
            ObservableCollection<Equipment_failure> failure = GetFailures();
            var Efaiure = failure.Where(bp => bp.Id_equipment_failure == id_equipment_failure).FirstOrDefault();
            return Efaiure;
        }

        public static ObservableCollection<Equipment> GetEquipments()
        {
            //List<Equipment> equipment = new List<Equipment>(bd_connection.connection.Equipment);
            //List<Equipment> equipments  = new List<Equipment>();
            //foreach (var t in equipment)
            //{
            //    equipments.Add(
            //        new Equipment
            //        {
            //            Id_equipment = t.Id_equipment,
            //            Name_equipment = t.Name_equipment,
            //            Id_plot= t.Id_plot,
            //            //Image = t.Image
            //        });
            //}
            //return equipments;
            ObservableCollection<Equipment> equipment = new ObservableCollection<Equipment>(bd_connection.connection.Equipment);
            return equipment;
        }

        

        public static List<Equipment> GetEquipments(int Id_plot)
        {
            //ObservableCollection<Equipment> equipments = new ObservableCollection<Equipment>(bd_connection.connection.Equipment);
            ObservableCollection<Equipment> equipments = GetEquipments();
            return equipments.Where(a => a.Id_plot == Id_plot).ToList();
        }


        public static Equipment GetEquipment(string name)
        {
            ObservableCollection<Equipment> equipments = GetEquipments();
            return equipments.Where(t => t.Name_equipment == name).FirstOrDefault();
        }

        public static Equipment GetEquipment(int id_equipment)
        {
            ObservableCollection<Equipment> equipments = GetEquipments();
            return equipments.Where(t => t.Id_equipment == id_equipment).FirstOrDefault();
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
        public static void DeleteInspection(int id_inspection)
        {
            //List<Technical_inspection> inspections = GetTechnical_inspections();
            //var inspection = inspections.Where(t => t.Id_inspection == id_inspection).FirstOrDefault();
            Technical_inspection inspection = GetTechnical_inspection(id_inspection);

            bd_connection.connection.Technical_inspection.Remove(inspection);
            bd_connection.connection.SaveChanges();
        }

        public static void UpdateInspection(int id_inspection, Technical_inspection inspection)
        {

            bd_connection.connection.Technical_inspection.SingleOrDefault(t => t.Id_inspection == id_inspection);
            bd_connection.connection.SaveChanges();

        }

        public static void DeleteInspection(Technical_inspection inspection)
        {
            bd_connection.connection.Technical_inspection.Remove(inspection);
            bd_connection.connection.SaveChanges();
        }


        public static bool AddNewTechnical_inspection(DateTime newDate_inspection, string newResult, string newEmployee_name, int newId_equipment, bool newDone, string newStatus)
        {
            try
            {
                Technical_inspection inspection = new Technical_inspection()
                {
                    Date_inspection = newDate_inspection,
                    Result = newResult,
                    Employee_name = newEmployee_name,
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
                        Id_inspection = r.Id_inspection,
                        Date_inspection = r.Date_inspection,
                        Result = r.Result,
                        Id_equipment = r.Id_equipment,
                        Employee_name = r.Employee_name,
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
        //public static List<ExtraTechnicInspection> GetExtraTechnicInspection()
        //{
        //    var inspections = GetTechnical_inspections();
        //    List<ExtraTechnicInspection> Inspections = new List<ExtraTechnicInspection>();
        //    foreach (var i in inspections)
        //    {
        //        Inspections.Add(new ExtraTechnicInspection
        //        {
        //            Id_inspection = (int)i.Id_inspection,
        //            Result = (string)i.Result,
        //            Employee_name = (string)i.Employee_name,
        //            Id_equipment = (int)i.Id_equipment,
        //            Date_inspection = (DateTime)i.Date_inspection,
        //            Done = (bool)i.Done,
        //            Status = (string)i.Status
        //        });
        //    }

        //    return Inspections;
        //}
    }
}

