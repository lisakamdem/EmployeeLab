using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Author: Lisa Kamdem
    /// Date: feb 3. 2023
    /// creating the child class and the getters and setters
    /// and also the claculations to find the salary
    /// </summary>
    internal class Salaried : Employee
    {
        private double salary;

        public double Salary { get { return salary; } }
        public Salaried() { }

        public Salaried(string id, string name, string address, string phone, long sin, 
            string birthday, string dept, double salary)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthday = birthday;
            this.dept = dept;
            this.salary = salary;
        }

        //This does the calculation needed 
        //the get the salary of the employee
        public override double getPay()
        {
            return this.salary;

        }
    }
}
