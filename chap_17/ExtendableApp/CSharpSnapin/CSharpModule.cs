using System;
using CommonSnappaleTypes;

namespace CSharpSnapin
{
    [CompanyInfo(CompanyName = "FooBar", CompanyUrl = "www.FooBar.com")]
    public class CSharpModule : IAppFunctionality
    {
        public void DoIt()
        {
            Console.WriteLine("You have just used the C# snap-in!");
        }
    }
}