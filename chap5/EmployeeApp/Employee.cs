using static System.Console;

namespace EmployeeApp
{

    public enum EmployeePayTypeEnum
    {
        Hourly,
        Salaried,
        Commission
    }

    class Employee
    {
        // Field data.
        private string _empName;
        private int _empId;
        private float _currPay;
        private int _empAge;
        private string _empSSN;
        private EmployeePayTypeEnum _payType;

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
        // public void GiveBonus(float amount) => _currPay += amount;

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

        // Properties!
        public string Name
        {
            get => _empName; set
            {
                if (value.Length > 15)
                {
                    WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                {
                    _empName = value;
                }
            }
        }

        public int Id
        {
            get { return _empId; }
            set { _empId = value; }
        }
        public float Pay
        {
            get { return _currPay; }
            set { _currPay = value; }
        }

        public int Age { get => _empAge; set => _empAge = value; }

        public string SocialSecurityNumber { get => _empSSN; private set => _empSSN = value; }
        public EmployeePayTypeEnum PayType { get => _payType; set => _payType = value; }
    }
}