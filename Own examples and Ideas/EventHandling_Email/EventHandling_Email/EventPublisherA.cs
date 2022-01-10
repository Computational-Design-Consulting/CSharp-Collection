namespace EventHandling_Email
{
  /// <summary>
  /// Publisher Class
  /// </summary>
  class EventPublisherA                                       //Publisher Class: (○ >necessary, - >for functionality)
  {
    /// <summary>
    /// instances
    /// </summary>
    public static int counter;                                // - counting event-occurances

    /// <summary>
    /// Delegate pointing to subscriber-method(signature)
    /// I: string/ O: void
    /// </summary>
    /// <param name="messageFromPublisher">expecting string input</param>
    public delegate void Event1Handler(string messageFromPublisher); // ○ Declare Delegate     

    /// <summary>
    /// Calls matching method on Publisher instance in subscriber
    /// </summary>
    public event Event1Handler Event1;                       // ○ Declare Event of type Delegate

    /// <summary>
    /// Method used on instance to trigger event and pass method-string-parameter
    /// </summary>
    public void RaiseEvent1()
    {
      counter++;                                              // - incrementing event-occurance-counter
      Event1($"\"raised {counter} times\"");                  // ○ Raise event within method
    }
  }
}