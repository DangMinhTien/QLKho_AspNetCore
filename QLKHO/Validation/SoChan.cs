using System;
using System.ComponentModel.DataAnnotations;

namespace QLKHO.Validation
{
    public class SoChan : ValidationAttribute
    {
        public SoChan() => ErrorMessage = "{0} phải là số chẵn";
        public override bool IsValid(object value)
        {
            if( value == null) return false;
            int number = int.Parse(value.ToString());
            return number % 2 == 0;
        }
    }
}
