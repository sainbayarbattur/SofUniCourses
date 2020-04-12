namespace ValidationAttributes.Core.Models
{
    using System;

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            var number = Convert.ToInt32(value);

            if (number < minValue || number > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}