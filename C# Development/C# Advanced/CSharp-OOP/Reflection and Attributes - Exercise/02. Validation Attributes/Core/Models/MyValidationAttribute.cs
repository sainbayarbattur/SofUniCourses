namespace ValidationAttributes.Core.Models
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]

    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}