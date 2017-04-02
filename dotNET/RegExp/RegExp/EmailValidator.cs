namespace RegExp
{
    public class EmailValidator : Validator
    {
        private const string End = @"([\w\-]+[\.])+((\w{2,3}|info|museum|travel|name|mobi|jobs|coop|asia|aero|marketing|sales|support|abuse|security|postmaster))";
        internal override string Pattern => @"^[a-zA-Z+_]+[\w\-]*(\.[\-\w]+)*@" + End + "$";
        internal override string Entity => "email";
    }
}