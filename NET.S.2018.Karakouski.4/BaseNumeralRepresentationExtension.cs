using System;
using System.Linq;
using System.Text;

namespace NET.S._2018.Karakouski._4
{
    /// <summary>
    /// Impliments method of converstion number from 1o base to IEE-754 double and method of conversation of 10 base number to and base from 2 to 16
    /// </summary>
    public static class BaseNumeralRepresentationExtension
    {
        static string zeroMantissa = "0000000000000000000000000000000000000000000000000000";//52 bits
        static string zeroExponenta = "00000000000";//11 bits
        static string onesExponenta = "11111111111";//11 bits

        private static string legal6BaseChars = "0123456789ABCCDEF";
        /// <summary>
        /// Impliments method of converstion number from 1o base to IEE-754 double
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string IEEE754Representation(this double number)
        {

            StringBuilder result = new StringBuilder();

            switch (number)
            {
                case (Double.NegativeInfinity):
                    {
                        return result.Append('1').Append(onesExponenta).Append(zeroMantissa).ToString();
                    }
                case (Double.PositiveInfinity):
                    {
                        return result.Append('0').Append(onesExponenta).Append(zeroMantissa).ToString();
                    }
                case (-0.0):
                    {
                        return result.Append('1').Append(zeroExponenta).Append(zeroMantissa).ToString();
                    }
                case (Double.NaN):
                    {
                        return result.Append('1').Append(onesExponenta).Append('1').Append(zeroMantissa.Remove(0,1)).ToString();
                    }
                //case (0.0): //multimple cases with zero?..
                //    {
                //        return result.Append('0').Append(zeroExponenta).Append(zeroMantisa).ToString();
                //    }

            }

            if(number == -0.0)
                return result.Append('0').Append(zeroExponenta).Append(zeroMantissa).ToString();

            if (number > 0)
                result.Append('0');
            else
                result.Append('1');

            number = Math.Abs(number);

            int intExponent = (int)Math.Log(number, 2);
            intExponent += 1023;

            double doubleMantissa = number / intExponent;

            StringBuilder mantissa = new StringBuilder();
            StringBuilder exponent = new StringBuilder();

            while (intExponent > 0)
            {
                exponent.Insert(0, intExponent % 2);
                intExponent /= 2;
            }

            int count = 0;
            while (((doubleMantissa % 1) != 0) || count < 52)
            {
                doubleMantissa *= 2;
                mantissa.Append(((int)(doubleMantissa)));
                doubleMantissa %= 1;
                count++;
            }

            result.Append(exponent);
            result.Append(mantissa);

            return result.ToString();
        }

        /// <summary>
        /// Fills number with zeroes up to required size
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="size"></param>
        private static void FillTheRestWithZeroes(StringBuilder sb, int size)
        {
            if (sb.Length < size)
            {
                for (int i = 0; i < size - sb.Length; i++)
                {
                    sb.Append('0');
                }
            }
        }
        /// <summary>
        /// Impliments method of conversation of 10 base number to and base from 2 to 16
        /// </summary>
        /// <param name="number"></param>
        /// <param name="nBase"></param>
        /// <returns></returns>
        public static string Base10Number(this string number, int nBase)
        {
            if (nBase < 2 || nBase > 16)
                throw new ArgumentOutOfRangeException(nameof(nBase));

            number = number.ToUpper();

            if (!number.All(c => legal6BaseChars.Substring(0, nBase+1).Contains(c)))
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
        
        /// <summary>
        /// Converts symbolic representation to digit representation
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
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
