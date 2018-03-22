using System;

namespace NET.S._2018.Karakouski._4
{
    public static class GcdCalulator
    {
        public static int EuclidGcdCalc(params int[] args)
        {
            int gcd = args[0];

            for(int i=1; i<args.Length; i++)
            {
                gcd = EuclidGcdCalc(gcd, args[i]);
            }

            return gcd;
         }

        private static int EuclidGcdCalc(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            return EuclidGcdCalc(b, a % b);
        }

        public static int BinaryGcdCalc(params int[] args)
        {
            throw new NotImplementedException();
        }
    }
}
