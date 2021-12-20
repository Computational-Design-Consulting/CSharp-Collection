using System;

// parent:
public class BaseClass
{
  // virtual keyword enables both:
  // • method hiding (calling base method on derived object)
  // • method overriding (calling customized method)
  public virtual string TypeOrigin()
  {
    // hidden in derived (derived method used) when instance is only of derived type:
    return "\n   [on:]   " + this.GetType().Name + " \n" +
             "   [from:] BaseClass";
  }
}

// children:
public class DerivedOverrideClass : BaseClass
{
  // using "override" - keyword  (in method decleration)
  // for derived-class-object
  // • specific version of
  // • related functionality
  public override string TypeOrigin()
  {
    string newString = this.GetType().Name + "" +
           "\n           (specified method)";
    return "\n   [on:]   " + newString + 
           "\n   [from:] DerivedOverrideClass";
  }
}
public class SpecialDerivedOverrideClass : BaseClass
{
  // using "base" - keyword (in body)
  // of overridden method, to still
  // use base class method functionality in derived class when:
  // • at least one method-case occures where:
  // - no modified fuctionality is needed
  public override string TypeOrigin()
  {
    var hours = DateTime.Now.TimeOfDay.Hours;
    var message = " (daytime dependent: baseMethod/derivedMethod)";
    // modify office time to see effect:
    if (hours < 9 || hours > 23)
      return $"\n   It's {hours} something, I'm not gonna work now.{message}";
    else
      return $"\n   Welcome to my office, It's {hours} something.{message}" +
             $"\n   [on:]   {base.GetType().Name} \n" +
               $"   [from:] SpecialDerivedOverrideClass";
  }
}
public class DerivedNewClasss : BaseClass
{
  // using "new" - keyword  (in method decleration)
  // A)
  // if first base class instantiated / then derived constructor used:
  // for explicit method hiding (accidentially works if none is used as well)
  // ensures intent in derived class:
  // • best be used when base functionality is desired
  // • basically same affect as using base. in overridden method
  // - but can't be further modified

  // B)
  // if only derived class type object is instantiated
  // for unrelated functionality
  // • best used if base type is unrelated as well
  public new string TypeOrigin()
  {
    // hidden (base type used) when instance is of base type:
    string newString = this.GetType().Name +
           "\n           (unrelated method)";
    return "\n   [on:]   " + newString +
           "\n   [from:] DerivedNewClasss";
  }
}


// program:
public class TestProgram
{
  public static void Main()
  {
    // A)
    // instantiate first base class type object,
    // then use derived constructor because:
    // • base class is capable of morphing into 
    //   any derived class object (using their methods)
    // B)
    // instantiate only derived class type object, because:
    // • derived class is capable of accessing their own
    //   methods without overriding

    Console.WriteLine("Types (declare & instantiate):\n" +
                      "------------------------------\n");
    // A)
    // first base class / then use derived constructor:
    // step 01 - instantiate baseType:
    BaseClass objOverride = new BaseClass();
    Feedback("01", "objOverride", objOverride);
    // step 02 - morph into childType-shape:
    objOverride = new DerivedOverrideClass();
    Feedback("02", "objOverride", objOverride);

    // both as one-liners:
    SpecialDerivedOverrideClass objSpecialOverride = new SpecialDerivedOverrideClass();
    Feedback("01+02", "objSpecialOverride", objSpecialOverride, 1, 0);
    // A)
    // hiding derived method (irellevant in derived classes with overidden method above),
    // by declaring the derived instance of base type (relevant if new keyword is used(or forgotten)):
    // both as one-liners:
    BaseClass objDerivedNewBase = new DerivedNewClasss();
    Feedback("01+02", "objDerivedNewBase", objDerivedNewBase, 1, 0);

    // B)
    // hiding the base method, by declaring the instance only as derived type:
    DerivedNewClasss objDerivedNew = new DerivedNewClasss();
    Feedback("01+02", "objDerivedNew", objDerivedNew, 1, 2);


    // calling respective methods:
    Console.WriteLine(
      "Methods (calls from respective origin):\n" +
      "---------------------------------------\n");

    Console.WriteLine(
      $"objOverride\n • Override method:" +
      $"{objOverride.TypeOrigin()}\n");

    Console.WriteLine(
      $"objSpecialOverride\n \u2022 Special override method:" +
      $"{objSpecialOverride.TypeOrigin()}\n");

    Console.WriteLine(
      $"objDerivedNewBase\n • Base-method used (drived class \"new\"-method hidden):" +
      $"{objDerivedNewBase.TypeOrigin()}\n");

    Console.WriteLine(
      $"objDerivedNew\n • \"New\"-method used (base-method hidden):" +
      $"{objDerivedNew.TypeOrigin()}\n");
  }

  #region cosmetics
  // output cosmetics:
  private static void Feedback(
    string step, string name, object obj
    , int breaksBefore = 0, int breaksAfter = 0)
  {
    string space = "      ";
    space = space.Substring(0, (space.Length - step.Length));

    Breaks(ref breaksBefore, out string bBefore);
    Breaks(ref breaksAfter, out string bAfter);

    var instanceType = obj.GetType();
    string output = instanceType.Name;
    var baseType = obj.GetType().BaseType;
    if (instanceType.IsInstanceOfType(baseType))
      output = baseType.Name;

    Console.WriteLine($"{bBefore}{step}" +
    $"{space}• Type of instance: \"{name}\" = " +
    output+
      //$"{obj.GetType().Name}{bAfter}");
      //$"{obj.GetType().BaseType}
      bAfter);
  }
  // locally used function:
  private static void Breaks(ref int breaksNum, out string breaksString)
  {
    breaksString = "";
    while (breaksNum > 0)
    {
      breaksString += "\n";
      breaksNum--;
    }
  }
  #endregion cosmetics
}