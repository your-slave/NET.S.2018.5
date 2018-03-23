using System;
using System.Linq;
using System.Text;

namespace NET.S._2018.Karakouski._4
{
    public static class BaseNumeralRepresentationExtension
    {
        private static string legal6BaseChars = "FEDCBA9876543210";

        public static string BinaryRepresentation(this double number)
        {
            //1025 (decimal) to base 15:
            //1025 / 15 = 68 , remainder 5
            //68 / 15 = 4 , remainder 8
            //4 / 15 = 0 , remainder 4


            //Поэтому уже в самых первых машинах начали использовать трюк, делая первый бит мантиссы всегда положительным. Такое предаставление назвали нормализованным.

            //aftrwer , the same but with minus

            throw new NotImplementedException();
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
