using System;

namespace StaticDataAndMembers
{
    public class SavingsAccount
    {
        // Instance-level data
        public double currBalance;

        // A static point of data.
        public static double currInterestRate;

        // Notice that our constructor is setting
        // the static currInterestRate value.
        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }

        // A static constructor!
        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            currInterestRate = 0.04;
        }

        // public SavingsAccount(double balance) => currBalance = balance;

        public static double GetInterestRate() => currInterestRate;

        // Static members to get/set interest rate.
        public static void SetInterestRate(double newRate) => currInterestRate = newRate;
    }
}