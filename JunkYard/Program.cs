using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Employee> employeess = new Dictionary<int, Employee>();

            Employee employee1 = new Employee(1, "Greg");
            Employee employee2 = new Employee(2, "Sue");
            Employee employee3 = new Employee(3, "Jill");

            //add to the dict
            employeess.Add(1, employee1);
            employeess.Add(2, employee2);
            employeess.Add(3, employee3);

            //get info A
            foreach (var item in employeess)
            {
                if (item.Key==2)
                {
                    Console.WriteLine(item.Value.EmployeeName);
                }
            }

            foreach (var item in employeess.Values)
            {
                Console.WriteLine(item.EmployeeName);
            }

            foreach (var item in employeess.Keys)
            {
                if (item == 2)
                {
                    Console.WriteLine(item);
                }
            }



            Console.ReadKey();
        }
    }
}
