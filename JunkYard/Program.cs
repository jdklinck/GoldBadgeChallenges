﻿using System;
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
            //Just testing code...

            Employee employeeA = new Employee(1,"Steve Johnson");
            Employee employeeB = new Employee(2,"Joe Johnson");
            Employee employeeC = new Employee(3,"Morris Johnson");
            Employee employeeD = new Employee(4,"Ted Johnson");

            Queue<Employee> employees = new Queue<Employee>();

            //ITS A F.I.F.O structre DONT FORGET...
            //Enqueue is to add....
            employees.Enqueue(employeeA);
            employees.Enqueue(employeeB);
            employees.Enqueue(employeeC);
            employees.Enqueue(employeeD);

            //see these values
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.EmployeeId);
                Console.WriteLine(employee.EmployeeName);
            }
            Console.WriteLine("*******Now we Dqueue****************");
            //Dequeue is to remove 
            employees.Dequeue();
            //see these values
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.EmployeeId);
                Console.WriteLine(employee.EmployeeName);
            }

            Console.WriteLine("*******Now we Dqueue More...****************");
            employees.Dequeue();
            //see these values
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.EmployeeId);
                Console.WriteLine(employee.EmployeeName);
            }


            //Console.WriteLine("*******Now we Dqueue More...****************");
            //employees.Dequeue();
            //see these values
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.EmployeeId);
            //    Console.WriteLine(employee.EmployeeName);
            //}

            //Console.WriteLine("*******Now we Dqueue More.(no more)..****************");
            //employees.Dequeue();
            //see these values
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.EmployeeId);
            //    Console.WriteLine(employee.EmployeeName);
            //}


            //if I want to view who is next I need to "PEEK"
            Console.WriteLine(employees.Peek().EmployeeName);
            Console.ReadKey();
        }
    }
}
