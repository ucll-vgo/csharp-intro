using System;

namespace FractionExercise
{
    public class Fraction
    {
        public Fraction(int numerator, int denominator)
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            this.Numerator = Math.Sign(denominator) * numerator / gcd;
            this.Denominator = Math.Abs(denominator) / gcd;
        }

        private static int GCD(int a, int b)
        {
            return a == 0 ? b : GCD(b % a, a);
        }

        public int Numerator { get; }

        public int Denominator { get; }

        /*
            Leave this method alone, the tests rely on it.
         */
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Fraction);
        }

        /*
            Leave this method alone, the tests rely on it.
         */
        public bool Equals(Fraction that)
        {
            return !object.ReferenceEquals(that, null) && this.Numerator == that.Numerator && this.Denominator == that.Denominator;
        }

        public override int GetHashCode()
        {
            return this.Numerator ^ this.Denominator;
        }

        public Fraction Invert()
        {
            return new Fraction(this.Denominator, this.Numerator);
        }

        public Fraction Add(Fraction b)
        {
            var a = this;

            var numer = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
            var denom = a.Denominator * b.Denominator;

            return new Fraction(numer, denom);
        }

        public Fraction Negate()
        {
            var a = this;

            return new Fraction(-a.Numerator, a.Denominator);
        }

        public Fraction Subtract(Fraction b)
        {
            var a = this;

            return a.Add(b.Negate());
        }

        public Fraction Multiply(Fraction b)
        {
            var a = this;
            var numer = a.Numerator * b.Numerator;
            var denom = a.Denominator * b.Denominator;

            return new Fraction(numer, denom);
        }

        public Fraction Divide(Fraction b)
        {
            var a = this;

            return a.Multiply(b.Invert());
        }
    }
}