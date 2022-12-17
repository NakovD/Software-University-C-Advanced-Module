namespace ValidationAttributes.Attributes
{
    using Contracts;

    using System;

    public class MyRequiredAttribute : MyValidationAttribute
    {

        public override bool IsValid(object obj) => obj != null;
    }
}
