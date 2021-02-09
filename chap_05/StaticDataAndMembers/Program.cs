using System;

namespace StaticDataAndMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Static Data *****\n");
            // Make an account.
            SavingsAccount s1 = new SavingsAccount(50);
            // Print the current interest rate.
            // Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.InterestRate);

            // Try to change the interest rate via property.
            // SavingsAccount.SetInterestRate(0.08);
            SavingsAccount.InterestRate = 0.08;

            // Make a second account.
            SavingsAccount s2 = new SavingsAccount(100);

            // Should print 0.08...right??
            // Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.InterestRate);

            // Make new object, this does NOT 'reset' the interest rate.
            SavingsAccount s3 = new SavingsAccount(10000.75);
            // Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.InterestRate);

            // This is just fine.
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();

            // Compiler error! Can't create instance of static classes!
            // TimeUtilClass u = new TimeUtilClass();

            Console.ReadLine();
        }
    }
}
