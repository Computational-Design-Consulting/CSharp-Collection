using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace EventMailExLibrary
{
  public class SendingMail
  {
    static string txt;
    static bool _useHTML = false;
    static MailMessage message;
    static SmtpClient client;

    #region User - Prompts
    public static string UserContentPromt()
    {
      Console.WriteLine("Would you like to use HTML-Mail format? (y/else)");
      return Console.ReadLine();
    }

    public static string MailContent(string userAnswer, ref bool _useHTML)
    {
      string txt;
      if (userAnswer.ToUpper().Contains('Y'))
      {
        _useHTML = true;
        txt = GetIndexHTML(); //=> using Html-Email* <- as embedded project ressouce (Properties: Build Action: Embedded Ressource) 
      }
      else
        txt = "event1 is raised more than 10 times"; //=> used if just text*
      return txt;
    }
    #endregion

    #region .Net.Mail - Setup
    /// <summary>
    /// Preparing the .Net.Mail Server
    /// </summary>
    /// <param name="message">Mail Content</param>
    /// <param name="client">Email Account User</param>
    /// <param name="useDefaultCredentials"></param>
    public static void MailSetup(
      out MailMessage message, 
      out SmtpClient client, 
      bool useDefaultCredentials = false)
    {
      MailAddress to = new MailAddress("wannatestthismail@gmail.com");
      MailAddress from = new MailAddress("wannatestthismail@gmail.com");
      message = new MailMessage(from, to)
      {
        Subject = "Update on EventHandling_Email Program",
        Body = txt
      };
      if (_useHTML)
        message.IsBodyHtml = true; //<= enabled if not just using text*
      client = new SmtpClient("smtp.gmail.com", 587)
      {
        EnableSsl = true,
        ///UseDefaultCredentials:
        ///true  => works via App.config file (added to project)
        ///false => works using myCreds**:
        // TODO -> figure out how to write App.config for .NET Core 3.1
        UseDefaultCredentials = useDefaultCredentials
      };
      if (!useDefaultCredentials) // using myCreds**:
      {
        NetworkCredential myCreds =
                new NetworkCredential(
                      "wannatestthismail@gmail.com", "7QB6cMgr339hBMM");
        client.Credentials = myCreds;
      }

    }
    #endregion

    #region retrieving HTML-Mail
    /// local function retrieving embedded Html-Ressource
    ///
    public static string GetIndexHTML()
    {
      //Assembly asm = Assembly.GetExecutingAssembly();
      Assembly libAssembly = (new EventPublisherA()).GetAssembly(); // Getting Library Assembly, because Library Project holds embeded ressource
      using Stream stream = libAssembly.GetManifestResourceStream("EventMailExLibrary.index.html");
      using StreamReader reader = new StreamReader(stream);
      return reader.ReadToEnd();
    }
    #endregion

    #region sending Mail & general ErrorHnadling
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

      txt = MailContent(UserContentPromt(), ref _useHTML);
      MailSetup(out message, out client);

      try
      {
        client.Send(message);
        Console.WriteLine("message was sent");
      }
      catch (Exception ex)
      { Console.WriteLine("Mail couldn't be sent because:\n" + ex.ToString()); }
      Console.WriteLine("CreateAndSendMessageWithAttachment finished.");
    }
    #endregion 
  }
}
