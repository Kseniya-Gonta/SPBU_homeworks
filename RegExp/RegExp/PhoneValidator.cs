namespace RegExp
{
    public class PhoneValidator : Validator
    {
        internal override string Pattern => @"(^(\+7|8)?((\(\d{3}\)|\d{3})[\- ]?)?[\d]{3}[\-]?([\d]{2}[\-]?){2}$)|101|102|103|104";
        internal override string Entity => "phone number";
    }
}