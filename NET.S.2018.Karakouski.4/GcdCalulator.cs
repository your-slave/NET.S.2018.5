using System;

namespace NET.S._2018.Karakouski._4
{
    /// <summary>
    /// Impliments Euclide and Binary method of GCD calculation
    /// </summary>
    public static class GcdCalulator
    {
        /// <summary>
        /// Impliments Euclide of GCD calculation
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int EuclidGcdCalc(params int[] args)
        {
            int gcd = args[0];

            for(int i=1; i<args.Length; i++)
            {
                gcd = EuclidGcdCalc(gcd, args[i]);
            }

            return gcd;
         }

        /// <summary>
        /// Impliments recursive part of Euclide of GCD calculation
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static int EuclidGcdCalc(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            return EuclidGcdCalc(b, a % b);
        }
        /// <summary>
        /// Impliments Binary method of GCD calculation
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int BinaryGcdCalc(params int[] args)
        {
            int gcd = args[0];

            for (int i = 1; i < args.Length; i++)
            {
                gcd = BinaryGcdCalc(gcd, Math.Abs(args[i]));
            }

            return gcd;

        }

        /// <summary>
        /// Impliments recursive part of Binary of GCD calculation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int BinaryGcdCalc(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;

            if ((b % 2) == 0 && (a % 2) == 0) return BinaryGcdCalc(b >> 1, a >> 1) << 1;

            // a is even, b is odd
            else if ((b % 2) == 1) return BinaryGcdCalc(b >> 1, a);

            // a is odd, b is even
            else if ((a % 2) == 1) return BinaryGcdCalc(b, a >> 1);

            // a and b odd, a >= b
            else if (b >= a) return BinaryGcdCalc((b - a) >> 1, a);

            // a and b odd, a < b
            else return BinaryGcdCalc(b, (a - b) >> 1);
        }
    }
}
