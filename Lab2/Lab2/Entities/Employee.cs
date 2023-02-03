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
    /// creating the parent class class and the getters and setters
    /// and also creating a method caled getPay for its children class to override
    /// </summary>
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;
        protected string phone;
        protected long sin;
        protected string birthday;
        protected string dept;


        //We dont have set because we arent changing the employess information
        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Address { get { return address; } }
        public string Phone { get { return phone; } }

      
        public Employee() { }
        public Employee(string id, string name, string address, string phone, 
            long sin, string birthday, string dept)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthday = birthday;
            this.dept = dept;
        }

        //This does the calculation needed 
        //the get the salary of the employee
        public virtual double getPay()
        {
            return 0;
        }

    }
}
