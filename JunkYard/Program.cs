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
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            Employee employee1 = new Employee(1, "Greg");
            Employee employee2 = new Employee(2, "Sue");
            Employee employee3 = new Employee(3, "Jill");

            //add to the dict
            employees.Add(1, employee1);
            employees.Add(2, employee2);
            employees.Add(3, employee3);

            //get info A
            foreach (var item in employees)
            {
                if (item.Key==2)
                {
                    Console.WriteLine(item.Value.EmployeeName);
                }
            }

            foreach (var item in employees.Values)
            {
                Console.WriteLine(item.EmployeeName);
            }

            foreach (var item in employees.Keys)
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
