using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace szgya_employee
{
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public bool Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public int Salary { get; set; } //EUR

        public int SalaryYearlyHUF => this.SalaryYearly * 390;
        public int SalaryYearly => this.Salary * 12;
        public Employee(string line)
        {
            string[] data = line.Split(';');
            this.Name = data[0];
            this.Age = int.Parse(data[1]);
            this.City = data[2];
            this.Department = data[3];
            this.Position = data[4];
            this.Gender = data[5] == "Male";
            this.MaritalStatus = data[6] == "Married";
            this.Salary = int.Parse(data[7]);
        }

        public override string ToString()
        {
            return
                $"{this.Name,-9}|{this.Age,-2}|{this.City,-10}|{this.Department,-15}|{this.Position,-15}|{(this.Gender ? "Male" : "Female"),-6}|{(this.MaritalStatus ? "Married" : "Single"),-7}|{this.Salary,-5}";
        }
    }
}
