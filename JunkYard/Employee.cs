using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public Employee(int employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }
    }
}
