namespace FarsiLibrary.Utils
{
    public static class MathExtensions
    {
        public static int DivRem(this int dividend, int divisor, out int remainder)
        {
            int quotient = dividend / divisor;
            remainder = dividend - divisor * quotient;
            return quotient;
        }
    }
}