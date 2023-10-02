using System;

namespace szgya_employee
{
    class Program
    {
        static Dictionary<string, int> Above12MilHUFYearly(List<Employee> employees)
        {
            return employees
                .Where(e => e.SalaryYearlyHUF > 12000000)
                .ToDictionary(k => k.Name, v => v.SalaryYearlyHUF);
        }

        static bool YoungestAndOldest(List<Employee> employees, Employee youngest, Employee eldest)
        {
            youngest = employees.MinBy(e => e.Age);
            eldest = employees.MaxBy(e => e.Age);
            return employees.FindAll(e => e.Age == employees.Min(e => e.Age)).Count > 1;
        }
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            using StreamReader sr = new StreamReader("../../../employees.txt");
            while (!sr.EndOfStream)
            {
                employees.Add(new Employee(sr.ReadLine()));
            }

            Console.WriteLine($"8.feladat: átlag életkor: {employees.Average(e => e.Age)}");
            Console.WriteLine($"9.feladat: budapesti lakosok száma: {employees.Count(e => e.City == "Budapest")}");
            Console.WriteLine($"10.feladat: legidősebb személy: \n{employees.MaxBy(e => e.Age)}");
            Console.WriteLine($"11.feladat: {(employees.Exists(e => e.Age > 50) ? "van" : "nincs")}");
            Console.WriteLine("12.feladat");
            var f12arr = employees.Where(e => e.Age < 30).ToArray();
            foreach (var employee in f12arr)
            {
                Console.WriteLine(employee);
            }

            // 15
            //sajnos az ismétlődő keresztnevek miatt ennek a megoldásnak nincs sok értelme
            //using StreamWriter sw = new StreamWriter("../../../12mil.txt");
            //foreach (var item in Above12MilHUFYearly(employees))
            //{
            //    sw.WriteLine($"{item.Key};{item.Value}");
            //}
            using StreamWriter sw = new StreamWriter("../../../12mil.txt");
            foreach (var employee in employees.Where(e => e.SalaryYearlyHUF > 12000000))
            {
                sw.WriteLine($"{employee.Name};{employee.SalaryYearlyHUF}");
            }


            Console.WriteLine($"16.feladat: átlag fizetés: {employees.Average(e => e.Salary)}");

            Console.WriteLine($"17.feladat: dev átlagfizetés: {employees.Where(e => e.Position == "Developer").Average(e => e.Salary)} EUR");

            Console.WriteLine($"18.feladat: \n\tférfi átlagfizetés:{employees.Where(e => e.Gender).Average(e => e.Salary)}\n\tnői átlagfizetés:{employees.Where(e => !e.Gender).Average(e => e.Salary)}");

        }
    }
}