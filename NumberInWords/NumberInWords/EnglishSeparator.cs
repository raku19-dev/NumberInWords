using System;

namespace NumberInWords
{
    public class EnglishSeparator
    {
        public static readonly String EMPTY_SEPARATOR = " ";
        public static readonly String AND_SEPARATOR = " and ";

        public String getSeparator(int nextNumber)
        {
            String result = "";
            if (nextNumber < 100)
            {
                result = AND_SEPARATOR;
            }
            else
            {
                result = EMPTY_SEPARATOR;
            }

            return result;
        }
    }
}