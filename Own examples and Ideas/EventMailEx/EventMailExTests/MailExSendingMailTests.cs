using EventMailExLibrary;
using System;
using System.Net;
using System.Net.Mail;
using Xunit;

namespace EventMailExTests
{
  public class MailExSendingMailTests
  {
    [Fact]
    public void Test1()
    {
      Assert.True(true);
    }

    #region SendingMail
    // sending mail
    // ( - user prompts)
    [Fact]
    public void Test2()
    {
      var useHTML = false;
      var txt = "event1 is raised more than 10 times";
      var txtSet = SendingMail.MailContent("nope", ref useHTML);
      Assert.False(useHTML);
      Assert.Equal(txtSet, txt);
      SendingMail.MailContent("YYy", ref useHTML);
      Assert.True(useHTML);
    }

    // .Net.Mail - Setup
    //  - checking connection settings and credentials
    [Fact]
    public void Test3()
    {
      NetworkCredential myCreds =
                new NetworkCredential(
                      "wannatestthismail@gmail.com", "7QB6cMgr339hBMM");
      SendingMail.MailSetup(out MailMessage message, out SmtpClient client);
      Assert.Equal(587, client.Port);
      Assert.Equal("smtp.gmail.com", client.Host);
      NetworkCredential cred = 
        client.Credentials.GetCredential(
          "smtp.gmail.com", 587, myCreds.Password);
      Assert.Contains(myCreds.ToString(), cred.ToString());
      Assert.True(client.EnableSsl);
    }

    [Fact]
    public void Test4()
    {
      NetworkCredential myCreds =
          new NetworkCredential(
                "wannatestthismail@gmail.com", "7QB6cMgr339hBMM");
      SendingMail.MailSetup(out MailMessage message, out SmtpClient client, true);
      Assert.Equal(587, client.Port);
      Assert.Equal("smtp.gmail.com", client.Host);
      NetworkCredential cred = 
        client.Credentials.GetCredential(
          "smtp.gmail.com", 587, myCreds.Password);
      Assert.Contains(myCreds.ToString(), cred.ToString());
    }

    // retrieving HTML-Mail
    //  - 
    [Fact]
    public void Test5()
    {
      Assert.Contains("!DOCTYPE", SendingMail.GetIndexHTML());
    }

    #endregion


  }
}
