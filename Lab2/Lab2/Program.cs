using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2
{
    internal class Program
    {
        /// <summary>
        /// Author: Lisa Kamdem 
        /// Date: Feburary 1, 20222
        /// The summary for this program is reading through
        /// the emplyee.txt file, and than assign the findings in an employee
        /// object with the right parameter with the right information.
        /// After that, calculate the average of all the employees in the employee list
        /// later on find the highest wage and the lowest employee and lastly, find the average
        /// of each child class. Display all the calculation to found. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            
            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);



            foreach (string line in lines)
            {
                string[] cell = line.Split(':');

                string id = cell[0];
                string name = cell[1];
                string address = cell[2];
                string phone = cell[3];
                string sin = cell[4];
                string birthday = cell[5];
                string dept = cell[6];

                //this is just to get the fist number of the id
                //and after convert it to int
                string firstDigit = id.Substring(0, 1);
                int firstDigitInt = int.Parse(firstDigit);

                //A set salary each week
                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    //Salarie
                    string salary = cell[7];

                    //Adding all the information we got from line
                    //and adding it to an object and later adding that object to the parent class Employee
                    double salaryDouble = double.Parse(salary);
                    long sinLong = long.Parse(sin);
                    Salaried salaried = new Salaried(id, name, address, phone, sinLong, birthday, dept, salaryDouble);
                    employees.Add(salaried);
                }

                //No overtime: hourly rate * work hours
                //Overtime: (work hours - 40) * (hourly rate * 1.5)
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    //Wage
                    string rate = cell[7];
                    string hours = cell[8];

                    //Adding all the information we got from line
                    //and adding it to an object and later adding that object to the parent class Employee
                    double rateDouble = double.Parse(rate);
                    long sinLong = long.Parse(sin);
                    int hoursInt = int.Parse(hours);
                    Wages wages = new Wages(id, name, address, phone, sinLong, birthday, dept, rateDouble, hoursInt);
                    employees.Add(wages);

                }

                //No overtime: hourly rate * work hours
                //Overtime: print "no overtime was available"
                else if (firstDigitInt >= 8 && firstDigitInt <= 9)
                {
                    //Part time
                    string rate = cell[7];
                    string hours = cell[8];


                    //Adding all the information we got from line
                    //and adding it to an object and later adding that object to the parent class Employee
                    double rateDouble = double.Parse(rate);
                    long sinLong = long.Parse(sin);
                    int hoursInt = int.Parse(hours);
                    PartTime partTime = new PartTime(id, name, address, phone, sinLong, birthday, dept, rateDouble, hoursInt);
                    employees.Add(partTime);

                }
            }


            //This is to add all the salaries we get and add it up 
            //to get the sum at the end and also to get the average 
            //salary of each employee
            double weeklySumPay = 0;

            foreach(Employee employee in employees) 
            {
                double weeklyPay = employee.getPay();

                weeklySumPay += weeklyPay;
            }

            //I use a format so that it has 2 decimal number after the point
            //And than displays it as in one sentence
            double averagePay = weeklySumPay / employees.Count;
            string averagePayFormat = string.Format("{0:C2}", averagePay);
            Console.WriteLine("The average weekly pay: " + averagePayFormat + "\n");


            //In these foreach loop we will use them to get
            //the highest salary in wages and than the lost in part-time
            Wages highWage = null;
            Salaried highSalary = null;

            double wageCount = 0;
            double salaryCount = 0;
            double partTimeCount = 0; 
            foreach(Employee employee in employees)
            {
                if(employee is Wages)
                {
                    Wages wage = (Wages)employee;

                    if(highWage == null || wage.getPay() > highWage.getPay())
                    {
                        highWage = wage;
                    }

                    wageCount++;
                }

                if(employee is Salaried)
                {
                    Salaried salary = (Salaried)employee;
                    if(highSalary == null || salary.getPay() < highSalary.getPay())
                    {
                        highSalary = salary;
                    }

                    salaryCount++;
                }

                if(employee is PartTime)
                {
                    partTimeCount++;
                }
            }

            //to get the average of each child class divide by the parent class times 100
            //get the average and formating it so that theres 2 decimal points after and that 
            //it formats it so that it appears with the money symbol and has the commas in the right places
            //and also printing the highest salary in wage class and lowest salary in salary class
            double wageAverage = (wageCount / employees.Count) * 100;
            double salaryAverage = (salaryCount / employees.Count) * 100;
            double partTimeAverage = (partTimeCount / employees.Count) * 100; 

            string highWageFormat = string.Format("{0:C2}", highWage.getPay());
            string highSalaryFormat = string.Format("{0:C2}", highSalary.getPay());

            string wageAverageFormat = wageAverage.ToString("#.##");
            string salaryAverageFormat = salaryAverage.ToString("#.##");
            string partTimeAverageFormat = partTimeAverage.ToString("#.##");

            Console.WriteLine("Employee with the highest wage is: " + highWage.Name + " with a wage of: " + highWageFormat);
            Console.WriteLine("Employee with the lowest salary is: " + highSalary.Name + " with a wage of: " + highSalaryFormat+ "\n");
            Console.WriteLine("The average employee in wage is: " + wageCount + "/" + employees.Count + " (" + wageAverageFormat + "%)");
            Console.WriteLine("The average employee in salary is: " + salaryCount + "/" + employees.Count + " (" + salaryAverageFormat + "%)");
            Console.WriteLine("The average employee in part-time is: " + partTimeCount + "/" + employees.Count + " (" + partTimeAverageFormat + "%)");
            
        }
    }
}
