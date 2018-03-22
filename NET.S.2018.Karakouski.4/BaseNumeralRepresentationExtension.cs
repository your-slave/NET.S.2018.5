using System;

namespace NET.S._2018.Karakouski._4
{
    public static class BaseNumeralRepresentationExtension
    {
        public static string BinaryRepresentation(this double number)
        {
            throw new NotImplementedException();
        }

        public static string Base10Number(this string number, int nBase)
        {
            if (nBase < 2 || nBase > 16)
                throw new ArgumentOutOfRangeException(nameof(nBase));
            throw new NotImplementedException();
        }
    }
}
