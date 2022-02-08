using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

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

    public delegate Task AsyncEvent1Handler(string messageFromPublisher);

    /// <summary>
    /// Calls matching method on Publisher instance in subscriber
    /// </summary>
    public event Event1Handler Event1;                                    // ○ Declare Event of type Delegate, raised when called

    public event AsyncEvent1Handler AsyncEvent1;

    /// <summary>
    /// Method used on instance to trigger event and pass method-string-parameter
    /// </summary>
    public void RaiseEvent1() => Event1($"\"raised {++counter} times\""); // ○ Raise(Call) event, incrementing event-occurance-counter within method

    public async Task RasiseAsyncEvent1Async() => await AsyncEvent1($"\"raised {++counter} times\""); 

    /// <summary>
    /// passing Library Assembly to Program, because Library holds embeded ressource
    /// </summary>
    /// <returns></returns>
    public Assembly GetAssembly() => Assembly.GetExecutingAssembly();
  }

}

