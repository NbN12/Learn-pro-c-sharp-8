using static System.Console;

namespace Employees
{
    public abstract partial class Employee
    {
        protected string EmpName;
        protected int EmpId;
        protected float CurrPay;
        protected int EmpAge;
        protected string EmpSSN;
        protected EmployeePayTypeEnum EmpPayType;
        // Contain a BenefitPackage object
        private BenefitPackage emBenefits = new BenefitPackage();

        public string Name
        {
            get => EmpName; set
            {
                if (value.Length > 15)
                {
                    WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                {
                    EmpName = value;
                }
            }
        }

        public int Id
        {
            get { return EmpId; }
            set { EmpId = value; }
        }
        public float Pay
        {
            get { return CurrPay; }
            set { CurrPay = value; }
        }

        public int Age { get => EmpAge; set => EmpAge = value; }

        public string SocialSecurityNumber { get => EmpSSN; private set => EmpSSN = value; }

        public EmployeePayTypeEnum PayType { get => EmpPayType; set => EmpPayType = value; }
        protected BenefitPackage EmBenefits { get => emBenefits; set => emBenefits = value; }

        public double GetBenefitCost() => EmBenefits.ComputePayDeduction();
    }
}