using System;

namespace CommonSnappaleTypes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CompanyInfoAttribute : Attribute
    {
        public string CompanyName { get; set; }
        public string CompanyUrl { get; set; }
    }
}