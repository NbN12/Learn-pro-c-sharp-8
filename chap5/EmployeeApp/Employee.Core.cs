using static System.Console;

namespace EmployeeApp
{
    partial class Employee
    {
        // Field data.
        private string _empName;
        private int _empId;
        private float _currPay;
        private int _empAge;
        private string _empSSN;
        private EmployeePayTypeEnum _payType;

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