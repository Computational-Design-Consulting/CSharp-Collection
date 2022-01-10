using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Reflection;

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

  /// <summary>
  /// Subscriber Class
  /// </summary>
  class Program                                               //Subscriber Class: (○ >necessary, - >for functionality, cosmetics >features)
  {
    /// <summary>
    /// Field for consistant data to count events
    /// </summary>
    static int countEmails;

    /// <summary>
    /// Entry point, subscribing & raising event
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)                                           /// Program Entry Point
    {
      Console.WriteLine(_userInstructions);                                   /// - user instructions

      var subscriberEventObject = new EventPublisherA();                      /// ○ instantiate object of event publisher class type

      /// ○ Declare a delegate(pointer)-instance:(type.)Event1Handler
      ///   > pointing to method-call:OnEvent1_GiveConsoleFeedback()
      ///   > Add delegate-instance to (instance.).Event1's list of "Event Handlers"
      ///   In other words:
      ///   Binding (Publisher-instance.)Event:Event1
      ///   > with (Publisher-type.)delegate:Event1Handler
      ///   > calling argument-method:OnEvent1_GiveConsoleFeedback()
      subscriberEventObject.Event1 += new EventPublisherA.Event1Handler(OnEvent1_GiveConsoleFeedback);
      subscriberEventObject.Event1 += new EventPublisherA.Event1Handler(OnEvent1_SendMail);

      do
      {
        /// ○ call publisher-class-method on instance
        /// --> fires event(which calls the delegate(that uses the event argument))
        subscriberEventObject.RaiseEvent1();

        Console.WriteLine("Repeat? (y/else)");                                  ///cosmetics
      } while (Console.ReadLine().ToUpper().Contains('Y')) ;                    ///repeat execution  
  }

    /// <summary>
    /// Method 1 called by delegate if event is raised (matching delegate)
    /// </summary>
    /// <param name="someString"></param>
    private static void OnEvent1_GiveConsoleFeedback(string eventString /* - "raised x times"*/)
    {
      // ○ Some code to be executed when Event1 fires.
      Console.WriteLine("event fired with argument: " + eventString);
    }

    /// <summary>
    /// Method 2 called by delegate if event is raised (matching delegate)
    /// </summary>
    /// <param name="eventString"></param>
    private static void OnEvent1_SendMail(string eventString)
    {
      // ○ trigger email if event is raised more than 10 times:
      // - retrieving integer-part from 
      if (Convert.ToInt32(Regex.Match(eventString, @"\d+").Value) == 10)
      {
        countEmails++;
        if (countEmails < 4)
        {
          Console.WriteLine("The event has been raised 10 times" +
            "\nDo you want to send a notification by mail? (y/else)");
          if (Console.ReadLine().ToUpper().Contains('Y'))
            CreateAndSendMessageWithAttachment();
        }
      }
    }

    /// <summary>
    /// Method 2 - Subroutine sending a report email
    /// either as plain text or as Html-Email
    /// uses either defined credentials or settings from "App.config" - file
    /// works with Gmail-Account set up only for this test-project
    /// requires account settings to be set to allow less secure apps access
    /// (https://myaccount.google.com/u/4/security?origin=3&rapt=AEjHL4NrKiGENm9xCx1UBR2Jf4NvoAh61IUF5FSGkOnlvwGpR9zZriS-jdnJ5fz9UFYLN8pyRiYCwukblshTVfnc3V7fbvusVw)
    /// </summary>
    public static void CreateAndSendMessageWithAttachment()
    {
      string txt;
      bool _useHTML = false;

      Console.WriteLine("Would you like to use HTML-Mail format? (y/else)");

      if (Console.ReadLine().ToUpper().Contains('Y'))
      {
        _useHTML = true;
        txt = GetIndexHTML(); //=> using Html-Email* <- as embedded project ressouce (Properties: Build Action: Embedded Ressource) 
      }
      else
        txt = "event1 is raised more than 10 times"; //=> used if just text*

      MailAddress to = new MailAddress("wannatestthismail@gmail.com");
      MailAddress from = new MailAddress("wannatestthismail@gmail.com");
      MailMessage message = new MailMessage(from, to);
      message.Subject = "Update on EventHandling_Email Program";
      message.Body = txt;
      if (_useHTML)
        message.IsBodyHtml = true; //<= enabled if not just using text*
      SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
      client.EnableSsl = true;

      //client.UseDefaultCredentials = true; //=> works via App.config file (added to project)
      client.UseDefaultCredentials = false; //=> works using myCreds:
      NetworkCredential myCreds = new NetworkCredential(
          "wannatestthismail@gmail.com", "7QB6cMgr339hBMM");
      client.Credentials = myCreds;

      try
      {
        client.Send(message);
        Console.WriteLine("message was sent");
      }
      catch (Exception ex)
      { Console.WriteLine("Mail couldn't be sent because:\n" + ex.ToString()); }
      Console.WriteLine("CreateAndSendMessageWithAttachment finished.");

      ///local function retrieving embedded Html-Ressource
      string GetIndexHTML()
      {
        Assembly asm = Assembly.GetExecutingAssembly();
        StreamReader reader = new StreamReader(asm.GetManifestResourceStream("EventHandling_Email.index.html"));
        string txtInternal = reader.ReadToEnd();
        return txtInternal;
      }
    }

    static string _userInstructions =
      "user instructions:\n" +
      "\nWelcome to the EventHandling_Email Program!\n" +
      "\nTo test the email functionality the following promt from Method 1:\n" +
      "\"Repeat? (y/else)\"" +
      "\nhas to be answered with \"yes\" (or just \"y\") for ten times.\n" +
      "This enables Method 2, once the prompt:\n" +


      "\n\"Do you want to send a notification by mail? (y/else)\"\n" +
      "has been answered with \"y\", an email is sent to the following test-account:\n\n" +
      "user: wannatestthismail@gmail.com\n" +
      "password: 7QB6cMgr339hBMM\n\n\n";
  }



}