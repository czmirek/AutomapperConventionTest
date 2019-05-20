namespace test
{
    using AutoMapper;
    using System;
    using System.Text.RegularExpressions;

    public class UppercaseUnderscoreNamingConvention : INamingConvention
    {
        public Regex SplittingExpression
        {
            get
            {
                return new Regex("([^_]\\w[^_]*)");
            }
        }
        
        public string SeparatorCharacter => "_";

        public string ReplaceValue(Match match)
        {
            if(String.IsNullOrEmpty(match.Value))
                return "";

            return match.Value.ToUpperInvariant();
        }
    }
}