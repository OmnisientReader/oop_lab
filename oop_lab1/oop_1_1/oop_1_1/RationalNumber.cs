using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oop_1_1
{
    public class RationalNumber
    {
        private int Numerator { get; }
        private int Denominator { get; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero");
            }
            int gcd = GreatestCommonDivisor(numerator, denominator);
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static RationalNumber operator -(RationalNumber a)
        {
            return new RationalNumber(-a.Numerator, a.Denominator);
        }

        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }

        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !(a == b);
        }

        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        }

        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
    }
}
