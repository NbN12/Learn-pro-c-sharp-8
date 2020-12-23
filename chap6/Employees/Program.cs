using System;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            // SalesPerson fred = new SalesPerson
            // {
            //     Age = 31,
            //     Name = "Fred",
            //     SalesNumber = 50
            // };

            // Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            // double cost = chucky.GetBenefitCost();
            // Console.WriteLine($"Benefit Cost: {cost}");

            // Define my benefit level.
            // Employee.BenefitPackageInner.BenefitPackageLevel myBenefitLevel = Employee.BenefitPackageInner.BenefitPackageLevel.Platinum;

            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            chucky.GiveBonus(300);
            chucky.DisplayStats();
            Console.WriteLine();

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();

            Console.ReadLine();
        }
    }
}
