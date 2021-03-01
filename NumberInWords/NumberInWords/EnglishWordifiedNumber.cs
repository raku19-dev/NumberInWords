using System;
using System.Collections.Generic;
using System.Text;

namespace NumberInWords
{
    public class EnglishWordifiedNumber
    {
        public EnglishWordifiedNumber()
        {

        }
        private static readonly String HUNDRED = "hundred";

        private static readonly String[] zeroToNineteenWords =
        {
            "", //print nothing
            "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
            "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        private static readonly String[] tensWords =
        {
            "twenty", "thirty", "forty", "fifty", "sixty", "seventy",
            "eighty", "ninety", "thirty"
        };

        private static readonly String[] times = {"thousand", "million"};
        private static readonly String minusWord = "minus";
        private static readonly String zeroWord = "zero";
        SplitPer3Digit splitPer3Digit = new SplitPer3Digit();
        EnglishSeparator englishSeparator = new EnglishSeparator();

        public String toWords(long number)
        {
            validateInput(number);
            if (number == 0)
            {
                return zeroWord;
            }

            var absNumber = Math.Abs(number);
            StringBuilder output = new StringBuilder();
            if (number != absNumber)
            {
                output.Append(minusWord);
                output.Append(' ');
            }

            List<int> splitPer3 = splitPer3Digit.split(absNumber);
            for (int i = splitPer3.Count - 1; i > -1; --i)
            {
                String word = getWord(splitPer3[i]);
                if (word.Length > 0)
                {
                    if (isFirstCycle(splitPer3, i))
                    {
                        output.Append(
                            englishSeparator.getSeparator(
                                splitPer3[i]));
                    }

                    output.Append(word);
                    output.Append(getTimes(i));
                }
            }

            return output.ToString().Trim();
        }

        private String getWord(int number)
        {
            int hundreds = number / 100;
            int tens = number % 100;
            StringBuilder result = new StringBuilder();
            var andWordRequired = false;
            if (hundreds > 0)
            {
                result.Append(zeroToNineteenWords[hundreds]);
                result.Append(' ');
                result.Append(HUNDRED);
                andWordRequired = true;
            }

            if (tens > 0)
            {
                if (andWordRequired)
                {
                    result.Append(EnglishSeparator.AND_SEPARATOR);
                }

                if (tens <= 19)
                {
                    result.Append(zeroToNineteenWords[tens]);
                }
                else
                {
                    result.Append(tensWords[tens / 10 - 2]);
                    result.Append(' ');
                    result.Append(zeroToNineteenWords[tens % 10]);
                }
            }

            return result.ToString();
        }

        private String getTimes(int position)
        {
            String result = "";
            if (position > 0)
            {
                result =
                    " " + times[position - 1];
            }

            return result;
        }

        private Boolean isFirstCycle(List<int> splitPer3, int i)
        {
            return i != splitPer3.Count - 1;
        }

        private void validateInput(long number)
        {
            if (number < -999999999 || number > 999999999)
            {
                throw new
                    ArgumentOutOfRangeException("Given number is out of bounds");
            }
        }
    }
}