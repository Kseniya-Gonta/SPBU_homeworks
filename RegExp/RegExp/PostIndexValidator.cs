namespace RegExp
{
    public class PostIndexValidator : Validator
    {
        internal override string Pattern => @"^[0-9]{6}$";
        internal override string Entity => "post index";
    }
}