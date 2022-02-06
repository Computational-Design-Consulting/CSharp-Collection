using System;
using System.IO;
using System.Reflection;

namespace EventMailExLibrary
{
  /// <summary>
  /// Publisher Class
  /// </summary>
  public class EventPublisherA                                       //Publisher Class: (○ >necessary, - >for functionality)
  {
    /// <summary>
    /// instances
    /// </summary>
    public static int counter;                                            // - counting event-occurances

    /// <summary>
    /// Delegate pointing to subscriber-method(signature)
    /// I: string/ O: void
    /// </summary>
    /// <param name="messageFromPublisher">expecting string input</param>
    public delegate void Event1Handler(string messageFromPublisher);      // ○ Declare Delegate     

    /// <summary>
    /// Calls matching method on Publisher instance in subscriber
    /// </summary>
    public event Event1Handler Event1;                                    // ○ Declare Event of type Delegate, raised when called

    /// <summary>
    /// Method used on instance to trigger event and pass method-string-parameter
    /// </summary>
    public void RaiseEvent1() => Event1($"\"raised {++counter} times\""); // ○ Raise(Call) event, incrementing event-occurance-counter within method

    /// <summary>
    /// passing Library Assembly to Program, because Library holds embeded ressource
    /// </summary>
    /// <returns></returns>
    public Assembly GetAssembly() => Assembly.GetExecutingAssembly();
  }

}

