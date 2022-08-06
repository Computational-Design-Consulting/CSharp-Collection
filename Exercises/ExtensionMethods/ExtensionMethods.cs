using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//More explaination:
/* Typically, an object-oriented programming language allows classes to be extended through inheritance.
 * However, C# 3.0 already introduced a new syntax that allows new methods to be added directly to an existing class.
 * These so-called extension methods are implemented as static methods in a new static class
 * and can then be called like a normal method (i.e. instance method) of the extended data type.
 * To declare a method as an extension method, the keyword this is specified before the first parameter.
 * The argument type of the first parameter refers to the class or structure to be extended.
 * When the extension method is then called, the compiler passes the instance of the extended type
 * as the first argument to the method.
 */

namespace ExtensionMethods
{

  internal class Program
  {
    #region aesthetics
    internal static void Wait() => Console.ReadKey();
    internal static void Print(string str) => Console.WriteLine(str);
    #endregion

    static void Main(string[] args)
    {
      int num1 = -95;
      Print(num1.Multiply(7).ToString());  //  -665
      Print(num1.Abs().ToString());        //    95

      int num2 = 10, num3 = 4;
      double fNum1 = 0.7, fNum2 = 2.5;
      Print($"Reciprocal: 0.4^(-1) = {0.4.Reciprocal()} & 0.8^(-1) = {0.8.Reciprocal()}");
      Print($"DividedBy: {fNum1}/{fNum2} = {fNum1.DividedBy(fNum2)}\n" +
        $"15.2/3.2 = {15.2.DividedBy(3.2)} & {fNum1}/{num2} = {fNum1.DividedBy(num2)}\n" +
        $"{num2}/{num3} = {num2.DividedBy(num3)}");

      Wait();
    }
  }

  /// <summary> Top level static class containing extension methods
  /// </summary>
  internal static class IntExtension
  {
    ///<summary> 1. Erweiterungsmethode 
    ///</summary>
    public static int Multiply(this int instance, int factor) => instance * factor;
    ///<summary> 2. Erweiterungsmethode
    ///</summary>
    public static int Abs(this int instance) => instance < 0 ? -1 * instance : instance;
  }

  internal static class DoubleExtensions
  {
    public static double Reciprocal(this double value) => 1 / value;
    public static double DividedBy(this double dividend, double divisor) => dividend / divisor;
    public static double DividedBy(this double dividend, int divisor) => dividend / divisor;
    public static double DividedBy(this int dividend, int divisor) => 1.0 * dividend / divisor;
  }
}
