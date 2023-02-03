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
    /// and also the claculations to find the wage salary
    /// </summary>
    internal class Wages : Employee
    {
        private double rate;
        private int hours;

        public double Rate { get { return rate; } }
        public int Hours { get { return hours; } }
        public Wages() { }

        public Wages(string id, string name, string address,string phone, 
            long sin, string birthday, string dept, double rate, int hours)
            //,long sin)
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
            //long sinNum = sin;
        }

        //This does the calculation needed 
        //the get the salary of the employee
        public override double getPay()
        {
            double employeeSalary = 0.0;

            //Without overtime
            if (this.hours < 40)
            {
                employeeSalary = this.hours * this.rate;
                //return employeeSalary;
            }
            //with overtime
            else 
            {
                double beforeOvertime = 40 * this.rate;
                double overtime = (this.hours - 40) * (this.rate * 1.5);

                employeeSalary = beforeOvertime + overtime;
                //return employeeSalary;
            }

            return employeeSalary;
        }
    }
}
