namespace ValidationAttributes.Core.Models
{
    using System;

    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return true;
        }
    }
}