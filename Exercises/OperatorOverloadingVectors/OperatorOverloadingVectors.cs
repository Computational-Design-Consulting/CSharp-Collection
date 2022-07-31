using System;

namespace Vectors
{
    class Vector
    {
        private int _x1, _x2, _x3;

        public Vector(int x1, int x2, int x3)
        {
            _x1 = x1;
            _x2 = x2;
            _x3 = x3;
        }

        public string Display => string.Format($"({_x1}, {_x2}, {_x3})");
        public static Vector operator +(Vector v1, Vector v2) =>  new Vector(v1._x1 + v2._x1, v1._x2 + v2._x2, v1._x3 + v2._x3);
        public static Vector operator -(Vector v) => new Vector(-v._x1, -v._x2, -v._x3);
        public static Vector operator *(int skalar, Vector Vector) => new Vector(Vector._x1 * skalar, Vector._x2 * skalar, Vector._x3 * skalar);
        public static Vector operator *(Vector Vector, int skalar) => skalar * Vector;
        public static bool operator ==(Vector v1, Vector v2) => (v1._x1 == v2._x1 && v1._x2 == v2._x2 && v1._x3 == v2._x3);
        //'==' overload requires '!=' overload!
        public static bool operator !=(Vector v1, Vector v2) => (v1._x1 != v2._x1 || v1._x2 != v2._x2 || v1._x3 != v2._x3);
        
        //Implicit conversion operators happens automatically without cast operator:
        //Conversion to another data type is lossless and error-free possible.
        ///<summary> conversion of the vector into a string
        ///</summary>
        public static implicit operator string(Vector v) => v.Display;
        //public static explicit operator string(Vector v) => v.Display;

        //Explicit conversion operators specifying the cast operator:
        //The conversion should not be done automatically implicitly
        //but explicitly by specifying a target data type in brackets. 
        ///<summary> Explicit conversion to a floating point type that
        ///specifies the length of a calculated vector
        ///</summary>
        public static explicit operator double(Vector v) =>  Math.Sqrt(v._x1 * v._x1 + v._x2 * v._x2 + v._x3 * v._x3);
    }
}
