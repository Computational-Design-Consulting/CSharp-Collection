using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EventMailExLibrary;

namespace EventMailEx
{
  /// <summary>
  /// Subscriber Class
  /// </summary>
  class Program
  {
    /// <summary>
    /// Field for consistant data to count events
    /// </summary>
    static int countEmails;

    #region static texts

    static readonly string _userInstructionsShort =
      $"Responding the following prompts with \"y\" 10 times will trigger" +
      " an email to the following address:\n\n";

    static readonly string _addressEmail =
      "user: wannatestthismail@gmail.com\n" +
      "password: 7QB6cMgr339hBMM\n\n\n";

    /*
    static string _userInstructionsLong =
      "user instructions:\n" +
      "\nWelcome to the EventHandling_Email Program!\n" +
      "\nTo test the email functionality the following promt from Method 1:\n" +
      "\"Repeat? (y/else)\"" +
      "\nhas to be answered with \"yes\" (or just \"y\") for ten times.\n" +
      "This enables Method 2, once the prompt:\n\n" +

      "\"Do you want to send a notification by mail? (y/else)\"\n" +
      "has been answered with \"y\", an email is sent to the following test-account:\n\n";*/
    #endregion


    /// <summary>
    /// Entry point, subscribing & raising event
    /// </summary>
    /// <param name="args"></param>
    //static Task Main(string[] args)                                           /// Program Entry Point
    static async Task Main(string[] args)                                           /// Program Entry Point
    {
      //Preparing test - working way to print embeded HTML-Mail:
      //MailMessage message;
      //SmtpClient client;
      //SendingMail.MailSetup(out message, out client);
      //Console.WriteLine("here" + client.Credentials);
      //Console.WriteLine(SendingMail.GetIndexHTML());

      //Console.WriteLine(_userInstructions+_addressEmail);                                   /// - user instructions long version
      Console.WriteLine(_userInstructionsShort + _addressEmail);                              /// - user instructions short version

      var subscriberEventObject = new EventPublisherA();                      /// ○ instantiate object of event publisher class type

      /// ○ Declare a delegate(pointer)-instance:(type.)Event1Handler
      ///   > pointing to method-call:OnEvent1_GiveConsoleFeedback()
      ///   > Add delegate-instance to (instance.).Event1's list of "Event Handlers"
      ///   In other words:
      ///   Binding (Publisher-instance.)Event:Event1
      ///   > with (Publisher-type.)delegate:Event1Handler
      ///   > calling argument-method:OnEvent1_GiveConsoleFeedback()
      //subscriberEventObject.Event1 +=
      //  new EventPublisherA.Event1Handler(OnEvent1_GiveConsoleFeedback);
      //subscriberEventObject.Event1 +=
      //  new EventPublisherA.Event1Handler(OnEvent1_SendMail); 
      subscriberEventObject.AsyncEvent1 +=
        new EventPublisherA.AsyncEvent1Handler(OnAsyncEvent1_GiveConsoleFeedback);
      subscriberEventObject.AsyncEvent1 +=
        new EventPublisherA.AsyncEvent1Handler(OnAsyncEvent1_SendMail);

      do
      {
        /// ○ call publisher-class-method on instance
        /// --> fires event(which calls the delegate(that uses the event argument))
        //subscriberEventObject.RaiseEvent1();


        await Task.WhenAll(subscriberEventObject.RasiseAsyncEvent1Async());
        // TODO: get following line to be executed after, or before, but not inbetween
        Console.WriteLine("\nUser Prompt: Repeat? (y/else)");                                  ///cosmetics
      } while (Console.ReadLine().ToUpper().Contains('Y'));                     ///repeat execution  
    }


    /// <summary>
    /// Method 1 called by delegate if event is raised (matching delegate)
    /// </summary>
    /// <param name="someString"></param>
    public static void OnEvent1_GiveConsoleFeedback(string eventString /* - "raised x times"*/)
    {
      // ○ Code to be executed when Event1 fires.
      Console.WriteLine("event fired with argument: " + eventString);
    }

    /// <summary>
    /// Method 1 Async called by delegate if event is raised (matching delegate)
    /// </summary>
    /// <param name="someString"></param>
    public static async Task OnAsyncEvent1_GiveConsoleFeedback(string eventString /* - "raised x times"*/)
    {
      // Adding (redundant) Progress Bar fun using async:
      var tasks = new List<Task<Action>>();
      Console.Write("Start Feedback about OnAsyncEvent1_GiveConsoleFeedback progress: \n|{");
      tasks.Add((Task<Action>)Task.Run(async ()=>
      await Task.Run(
        async () =>
        {
          int barLength = 20, mSec = 300; //barLength and stepTime

          char done = '▓', ahead = '░', close = '}';
          var progress = new StringBuilder(barLength);
          var delete = new StringBuilder(barLength);
          int relStepSize = mSec / barLength, counter = 0;
          for (int i = 0; i < mSec; i++)
            if (i % relStepSize <= 0)
            {
              await Task.Delay(mSec);   // Delay function to see bar growing, here so it's stepwise
              int toGo = barLength - 1 - counter;
              if (counter == 0)
              {
                progress.Append(done);
                for (int j = 0; j < toGo; j++)  //construct strings according barLength
                {
                  delete.Append("\b");    // fill delete string
                  progress.Append(ahead);   // fill relative left bar length
                }
                delete.Append("\b");    // fill delete string
                progress.Append(close);
              }
              else
              {
                if (counter == 2)
                  delete.Append("\b");
                progress.Replace(ahead, done, counter, 1);
                Console.Write(delete); //delete chars
              }
              Console.Write(progress); //write 
              counter++;
            }
        })));
      //await Task.WhenAll(tasks);

      Console.WriteLine("'|' > tedious task done! End Feedback! \n\n");
      Console.WriteLine("event fired with argument: " + eventString);
    }


    /// <summary>
    /// Method 2 called by delegate if event is raised (matching delegate)
    /// </summary>
    /// <param name="eventString"></param>
    public static async Task OnAsyncEvent1_SendMail(string eventString)
    {
      // ○ trigger email if event is raised more than 10 times:
      // - retrieving integer-part from 
      await Task.Run(async () =>
      {
        if (Convert.ToInt32(Regex.Match(eventString, @"\d+").Value) == 10)
          if (++countEmails < 4)
          {
            Console.WriteLine("The event has been raised 10 times" +
              "\nDo you want to send a notification by mail? (y/else)");
            if (Console.ReadLine().ToUpper().Contains('Y'))
              await SendingMail.CreateAndSendMessageWithAttachmentAsync();
          }
      });
    }

    /// <summary>
    /// Method 2 called by delegate if event is raised (matching delegate)
    /// </summary>
    /// <param name="eventString"></param>
    public static void OnEvent1_SendMail(string eventString)
    {
      // ○ trigger email if event is raised more than 10 times:
      // - retrieving integer-part from 
      if (Convert.ToInt32(Regex.Match(eventString, @"\d+").Value) == 10)
        if (++countEmails < 4)
        {
          Console.WriteLine("The event has been raised 10 times" +
            "\nDo you want to send a notification by mail? (y/else)");
          if (Console.ReadLine().ToUpper().Contains('Y'))
            SendingMail.CreateAndSendMessageWithAttachment();
        }
    }
  }
}
