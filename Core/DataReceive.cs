using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DataReceive
    {
        public static UchetEntities connection = new UchetEntities();
        public List<Employee> GetEmployees()
        {
            return new List<Employee>(connection.Employee);
        }
    }
}
