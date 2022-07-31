using System;

namespace OperatorOverloading
{
    class Program
    {
        static void Main( string[] args )
        {
            var num1 = new Complex( 2, 4 );
            var num2 = new Complex( 1, 3 );
            Complex sum = num1 + num2 + num2;
            Console.WriteLine( sum );
        }
    }

    ///<summary>Overloding the addition operator: '+'
    ///</summary>
    class Complex
    {
        double _real;
        double _imaginär;

        public Complex( double real, double img )
        {
            _real = real;
            _imaginary = img;
        }

        public override string ToString() =>
            String.Format( "{0} + i{1}", this.real, this.imaginary );

        public static Complex operator +( Complex c1, Complex c2 ) =>
            new Complex( c1.real + c2.real, c1.imaginary + c2.imaginary );
    }
}
