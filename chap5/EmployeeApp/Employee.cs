using static System.Console;

namespace EmployeeApp
{

    public enum EmployeePayTypeEnum
    {
        Hourly,
        Salaried,
        Commission
    }

    partial class Employee
    {
        // Constructors.
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

        // Methods.
        // Updated DisplayStats() method now accounts for age.
        public void DisplayStats()
        {
            WriteLine("Name: {0}", _empName);
            WriteLine("ID: {0}", _empId);
            WriteLine("Age: {0}", _empAge);
            WriteLine("Pay: {0}", _currPay);
        }

        public void GiveBonus(float amount)
        {
            Pay = this switch
            {
                { PayType: EmployeePayTypeEnum.Commission } => Pay += .10F * amount,
                { PayType: EmployeePayTypeEnum.Hourly } => Pay += 40F * amount / 2080F,
                { PayType: EmployeePayTypeEnum.Salaried } => Pay += amount,
                _ => Pay += 0
            };
        }
    }
}