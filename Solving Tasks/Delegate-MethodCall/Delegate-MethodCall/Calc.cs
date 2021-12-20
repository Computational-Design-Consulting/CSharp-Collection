namespace Delegate_MethodCall
{
   public class Calc
   {
      public static string Add(double a, double b)
      { return (a + b) + ""; }
      public static string Multiply(double a, double b)
      { return (a * b).ToString(); }
   }
   public delegate string OperationHandler(double a, double b);
}
