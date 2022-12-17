namespace ValidationAttributes.Attributes
{
    using Contracts;
    using Entities;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;

        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object value) => (int)value >= minValue && (int)value <= maxValue;
    }
}
