using System;

namespace StaticDataAndMembers
{
    // A simple savings account class.
    public class SavingsAccount
    {
        // Instance-level data
        public double currBalance;

        // A static point of data.
        private static double _currInterestRate;

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
            _currInterestRate = 0.04;
        }

        // public SavingsAccount(double balance) => currBalance = balance;
        // public static double GetInterestRate() => _currInterestRate;
        // Static members to get/set interest rate.
        // public static void SetInterestRate(double newRate) => _currInterestRate = newRate;

        // A Static property.
        public static double InterestRate { get => _currInterestRate; set => _currInterestRate = value; }
    }
}