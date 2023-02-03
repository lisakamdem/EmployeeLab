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
    /// and also the claculations to find the part-time salary
    /// </summary>
    internal class PartTime : Employee
    {
        private double rate;
        private int hours;

        public double Rate { get { return rate; } }
        public int Hours { get { return hours; } }
        public PartTime() { }

        public PartTime(string id, string name, string address, string phone, long sin,
            string birthday, string dept, double rate, int hours)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthday = birthday;
            this.dept = dept;
            this.rate = rate;
            this.hours = hours;
        }

        //This does the calculation needed 
        //the get the salary of the employee
        public override double getPay()
        {
            double employeeSalary = 0.0;

            employeeSalary = this.rate * this.hours;
            
            return employeeSalary;
        }

    }

    
}
