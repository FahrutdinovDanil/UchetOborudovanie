using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ExtraTechnicInspection
    {
        public int Id_inspection { get; set; }
        public DateTime Date_inspection { get; set; }
        public string Result { get; set; }
        public string Employee_name { get; set; }
        public int Id_equipment { get; set; }
        public bool Done { get; set; }
        public string Status { get; set; }
        public string EquipmentName => DataReceive.GetEquipment(Id_equipment).Name_equipment;
        //public string TattooImage => DataAccess.GetTattoo(IdTattoo).Image;
        //public string ProductionPlotName => DataReceive.GetPlot(Id_plot).Name_plot;
    }
}
