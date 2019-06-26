namespace Application.Common.Attr
{
    using System;
    public class DbContextAttribute : Attribute
    {
        public Type Use { get; set; }
    }
}