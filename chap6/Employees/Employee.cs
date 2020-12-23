using static System.Console;

namespace Employees
{
    public enum EmployeePayTypeEnum
    {
        Hourly,
        Salaried,
        Commission
    }

    public abstract partial class Employee
    {
        public class BenefitPackageInner
        {
            // Assume we have other members that represent
            // dental/health benefits, and so on.
            public double ComputePayDeduction()
            {
                return 125.0;
            }
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }
        }

        public Employee() { }

        public Employee(string name, int id, float pay, string empSsn) : this(name, 0, id, pay, empSsn, EmployeePayTypeEnum.Salaried) { }

        public Employee(string name, int age, int id, float pay, string ssn, EmployeePayTypeEnum payType)
        {
            Name = name;
            Age = age;
            Id = id;
            Pay = pay;
            SocialSecurityNumber = ssn;
            PayType = payType;
        }

        public virtual void DisplayStats()
        {
            WriteLine("Name: {0}", EmpName);
            WriteLine("ID: {0}", EmpId);
            WriteLine("Age: {0}", EmpAge);
            WriteLine("Pay: {0}", CurrPay);
            WriteLine("SSN: {0}", SocialSecurityNumber);
        }

        // public void GiveBonus(float amount)
        // {
        //     Pay = this switch
        //     {
        //         { PayType: EmployeePayTypeEnum.Commission } => Pay += .10F * amount,
        //         { PayType: EmployeePayTypeEnum.Hourly } => Pay += 40F * amount / 2080F,
        //         { PayType: EmployeePayTypeEnum.Salaried } => Pay += amount,
        //         _ => Pay += 0
        //     };
        // }

        // public void GiveBonus(float amount) => CurrPay += amount;
        // This method can now be "overridden" by a derived class.
        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }
    }
}