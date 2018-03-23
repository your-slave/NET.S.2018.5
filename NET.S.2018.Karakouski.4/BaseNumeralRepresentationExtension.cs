using System;
using System.Linq;
using System.Text;

namespace NET.S._2018.Karakouski._4
{
    /// <summary>
    /// 
    /// </summary>
    public static class BaseNumeralRepresentationExtension
    {
        private static string legal6BaseChars = "FEDCBA9876543210";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string IEEE754Representation(this double number)
        {
            int beforeComa = Math.Abs((int) number);
            double afterComa = Math.Abs(number) - Math.Abs(beforeComa);

            

            StringBuilder mantissa = new StringBuilder();
            int temp = beforeComa;

            while (temp > 0)
            {
                mantissa.Append(temp % 2);
                temp /= 2;
            }

            int numberOfDigitsBeforeComa = mantissa.Length;

            double doubleTemp = afterComa;

            int count = 0;
            while (doubleTemp % 10 < 1 && count < 23)
            {
                doubleTemp *= 2;
                mantissa.Append((int)(doubleTemp));
                count++;
            }

            mantissa.Remove(0, 1);
            FillTheRestWithZeroes(mantissa, 52, true);

            int intExponent = numberOfDigitsBeforeComa - 1 + 127;
            StringBuilder exponent = new StringBuilder();

            temp = intExponent;
            while (temp != 1)
            {
                exponent.Append(temp % 2);
                temp /= 2;
            }

            FillTheRestWithZeroes(exponent, 11);

            StringBuilder result = new StringBuilder();
            if (number > 0)
                result.Append('0');
            else
                result.Append('1');
            result.Append(exponent);
            result.Append(mantissa);

            return result.ToString();
        }

        private static void FillTheRestWithZeroes(StringBuilder sb, int size, bool reverse = false)
        {
            if(reverse)
            {
                if (sb.Length < size)
                {
                    for (int i = 0; i < size - sb.Length; i++)
                    {
                        sb.Append('0');
                    }
                }
            }
            else
            {
                if (sb.Length < size)
                {
                    for (int i = 0; i < size - sb.Length; i++)
                    {
                        sb.Insert(0, '0');
                    }
                }
            }
        }

        public static string Base10Number(this string number, int nBase)
        {
            if (nBase < 2 || nBase > 16)
                throw new ArgumentOutOfRangeException(nameof(nBase));

            number = number.ToUpper();

            if (!number.All(c => legal6BaseChars.Substring(nBase-1).Contains(c)))
            {
                throw new ArgumentException(nameof(number));
            }

            int result = 0;

            for(int i=0; i< number.Length; i++)
            {
                checked { result += number[i].GetNumeric10BaseRespresentIon() * (int)Math.Pow(nBase, number.Length - 1 - i); }
            }

            return result.ToString();
        } 
        
        private static int GetNumeric10BaseRespresentIon(this char symbol)
        {
            if(Char.IsDigit(symbol))
                return (int)Char.GetNumericValue(symbol);

            switch (symbol)
            {
                case ('A'):
                    {
                        return 10;
                    }
                case ('B'):
                    {
                        return 11;
                    }
                case ('C'):
                    {
                        return 12;
                    }
                case ('D'):
                    {
                        return 13;
                    }
                case ('E'):
                    {
                        return 14;
                    }
                case ('F'):
                    {
                        return 15;
                    }
            }

            throw new ArgumentException();
        }
    }
}
