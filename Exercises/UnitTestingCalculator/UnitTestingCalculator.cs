using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Prepare: add MSTest.TestFramework -> packages.config
  <?xml version="1.0" encoding="utf-8"?>
  <packages>
    <package id="MSTest.TestFramework" version="2.2.10" targetFramework="net48" />
	  <package id="MSTest.TestAdapter" version="2.2.10" targetFramework="net48" />
  </packages>
*/

/* Manual:
 * To start testing add to VS-Console Project targeting .Net 4.8
 * To enter the Test Explorer hit Crtl+E 
 * To run the tests hit Ctrl+R, A
 * (Hit Ctrl+M, O to get an overview)
 */

namespace UnitTests
{
  /// <summary> The Program needs the entry point to work
  /// to theoretically be executed, albeit unused. 
  /// </summary>
  public class Program { public static void Main() { } }

  #region Class/Methods to test:
  /// <summary> Simple base class to test inheritance
  /// contains most of the implementation as default
  /// only the first method signature is abstract
  /// </summary>
  public abstract class CalculatorBase
  {
    public abstract int Add(int num1, int num2);
    public double Divide(int num1, int num2) => num1 / num2;
    public int Multiply(int num1, int num2) => num1 * num2;
    public int Subtract(int num1, int num2) => num1 - num2;
  }

  /// <summary> Offering simple Arithmetic
  /// </summary>
  public class Calculator : CalculatorBase
  {
    /// <summary> Stores a global Result '.Value' within the scope of the namespace
    /// Which is either of type int or double
    /// </summary>
    public static class Result
    {
      public static dynamic Value{ get; set; }
    }
    //public static dynamic Result { get; private set; }
    public override int Add(int num1, int num2) { Result.Value = num1 + num2; return Result.Value; }
  }
  #endregion

  //Testing via MSTest.TestFramework:
  /// <summary> Class containing simple testing methods 
  /// to assert properly arranged units of methods 
  /// by comparing results of their action to known answers
  /// </summary>
  [TestClass]
  public class UnitTestCalculator
  {
    #region testingMethods
    [TestMethod]
    public void MAdd_FivePlusThreeIsEight()
    {
      //Arrange
      Calculator myCalc = new Calculator();
      //Act
      int result = myCalc.Add(5, 3);
      //Assert
      Assert.IsTrue(result == 8);
      Assert.AreEqual(Calculator.Result.Value, result);
      Assert.IsInstanceOfType(myCalc, typeof(Calculator));
    }

    [TestMethod]
    public void MMultiply_FiveByThreeIsFifteen()
    {
      //Arrange
      Calculator myCalc = new Calculator();
      //Act
      int result = myCalc.Multiply(5, 3);
      //Assert
      Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void MSubtract_FiveMinusThreeIsTwo()
    {
      //Arrange 
      Calculator myCalc = new Calculator();
      //Act
      int result = myCalc.Subtract(5, 3);
      //Assert
      Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void MDivide_FifteenByFiveIsThree()
    {
      //Arrange
      Calculator myCalc = new Calculator();
      //Act
      double result = myCalc.Divide(15, 5);
      //Assert
      Assert.AreEqual(3, result);
    }
    #endregion

    #region testingClassHirarchy
    /// <summary>
    /// this is just to show the inheritence testing method, not to actually test the inbuilt .Net functionality
    /// </summary>
    [TestMethod]
    public void CCalculatorIsInstanceOfCalculatorBase()
    {
      //Arrange
      Calculator myCalc = new Calculator();
      /* not relevant for hirarchy:
        //Act
        int result = myCalc.Add(5, 3);
        //Assert
        Assert.IsTrue(result == 8);
        Assert.AreEqual(Calculator.Result.Value, result);
      */
      Assert.IsInstanceOfType(myCalc, typeof(CalculatorBase));
    }
    #endregion
  }

}
