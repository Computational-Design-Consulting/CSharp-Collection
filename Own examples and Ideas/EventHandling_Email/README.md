# Event Handling & Email Notification
extensive reminder of how overriding and overloading work

![Result screenshot](Screenshot 2022-01-09%20213601.png)

[jump to relevant console-app file](https://github.com/Computational-Design-Consulting/CSharp-Collection/blob/mainCDC/Own%20examples%20and%20Ideas/EventHandling_Email/EventHandling_Email/Program.cs)
<br/>
<br/>

## Program description:

This Program is a console application as an exercise to practice creating and subscribing to events.
To add some functionality, an email account has been created to send and receive information from the program about the events.

In the event-publisher-class: the events are raised by a method: "`public void RaiseEvent1()`" and used on an instance of their publisher-class.
Then the value (here a static counter-field for the event-occurances) is passed via method-parameter as a string.

This is handled by the event-class-delegate: "`public delegate void Event1Handler(string messageFromPublisher)`" pointing to a matching subscriber-method(signature), here the input is of string format and the output is void.

To use the handler/delegate, the "`Event1`" is declared in the event-class,
it then calls the matching method (here 2 different methods with the same signature are used) on the Publisher-instance: "`subscriberEventObject`" that is added in the subscriber-class:

"
```csharp
var subscriberEventObject = new EventPublisherA();
 subscriberEventObject.Event1 += new EventPublisherA.Event1Handler(OnEvent1_GiveConsoleFeedback);
 subscriberEventObject.Event1 += new EventPublisherA.Event1Handler(OnEvent1_SendMail);
 ```

A call from the subscriber-class to the publisher-class-method on the publisher-class-instance
"`subscriberEventObject.RaiseEvent1();`"
simultaneously fires the event and triggers bound method that was pointed to by the delegate when subscribing to the event.

While the user keeps agreeing to repeat raising the event, the counter-value rises.
Here the Method 1: "`private static void OnEvent1_GiveConsoleFeedback(string eventString)`"
is called every time the Event1 is raised and functions by giving feedback to the user.
It is using the integer portion of the (string)event-publisher-class-value as method-argument to inform about the amount of times it has been raised.

Method 2: "`private static void OnEvent1_SendMail(string eventString)`"
is also called every time the Event1 has been raised, however it compares the retrieved value to the number 10 and then triggers it's further response if that condition is met.

The response is another Method(subroutine): "`public static void CreateAndSendMessageWithAttachment()`"
sending a report email either as plain text or as Html-Email that was produced using/ modifying a template from https://unlayer.com.
It uses either defined credentials or settings from "App.config" - file to access the account.
The Gmail-Account was set up only for this test-project and requires to be set to allow "`less secure apps access`".
(found in: https://myaccount.google.com/u/4/security?origin=3&rapt=AEjHL4NrKiGENm9xCx1UBR2Jf4NvoAh61IUF5FSGkOnlvwGpR9zZriS-jdnJ5fz9UFYLN8pyRiYCwukblshTVfnc3V7fbvusVw)