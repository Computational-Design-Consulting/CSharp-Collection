# Event Handling & Email Notification Extension
An extension to the exercise to practice creating and subscribing to events.


## relevant console-app files:
[Program.cs](https://github.com/Computational-Design-Consulting/CSharp-Collection/blob/mainCDC/Own%20examples%20and%20Ideas/EventMailEx/EventMailEx/Program.cs)  
[EventMailExLibrary.cs](https://github.com/Computational-Design-Consulting/CSharp-Collection/tree/mainCDC/Own%20examples%20and%20Ideas/EventMailEx/EventMailExLibrary)  
[MailExSendingMailTests.cs](https://github.com/Computational-Design-Consulting/CSharp-Collection/blob/mainCDC/Own%20examples%20and%20Ideas/EventMailEx/EventMailExTests/MailExSendingMailTests.cs)  


<!-- ![Result screenshot](Screenshot%202022-01-09%20213601.png) -->
<!-- <img src="Screenshot%202022-01-09%20213601.png" alt="class diagram" width="400"/>

![Result screenshot](Screenshot%202022-01-10%20162838.png)

![Result screenshot](Screenshot%202022-01-10%20175753.png)-->
<br/>
<br/> 

## Program description:

This Program is an extension to <a href="https://github.com/Computational-Design-Consulting/CSharp-Collection/tree/mainCDC/Own%20examples%20and%20Ideas/EventHandling_Email" title="An exercise to practice creating/ subscribing to events with Gmail-account to send/ receive information from  program about  events">Event Handling & Email Notification</a>.
 - Ported project(/solution) to .Net Core
 - Refactored classes into Library
 - uses asynchronous methods/ events
 - added unit testing  
<br/>
<br/>  

## Known issues:
 - [MailExSendingMailTests](https://github.com/Computational-Design-Consulting/CSharp-Collection/blob/mainCDC/Own%20examples%20and%20Ideas/EventMailEx/EventMailExTests/MailExSendingMailTests.cs) Test 5 -> fails!
   - tests if credentials match as expected
   - this test should ensure that the setup allows
     the the email credentials to be stored within
     appSettings and called as default values
   - probable cause:
     - [App.config](https://github.com/Computational-Design-Consulting/CSharp-Collection/blob/mainCDC/Own%20examples%20and%20Ideas/EventMailEx/EventMailExLibrary/App.config) doesn't target Core correctly
 - [Event_Async-Flow-Issue](https://github.com/Computational-Design-Consulting/CSharp-Collection/blob/mainCDC/Own%20examples%20and%20Ideas/EventMailEx/EventMailEx/Program.cs)
   - Results are scrambled within method
   - Flow Problem
      ```csharp
      static async Main Method
      {
        // ...instantiating eventClass/ subscribing event/ binding Method1 to Handler
        do{
            await
            /* calling the publisherClass.Event Method Task on eventClassInstance
            *    triggering ClassEvent
            *     eventInstanceSubscriptionHandler
            *      is calling the bound async Task Method1
            */
            
            // Some user promt => getting user_data
            
            /* Issue: Method1 action parts and user prompt get scrambled
            * TODO: 1. Trying to get Method1 to execute all parts together
            *         -  tried with the old Task.Factory
            *           - but then progress bar doesn't show steps anymore
            *       2. Making sure user promt gets executed after Method1
            *         -  maybe using global variable tracking change in Method1
            */
          } while (user_data says so)
      }

      static async Task Method1 (corrosponding to custom event Handler)
      {
        /* action part 1 // (i.e. Printing)
        *  action part 2 using:*/ await Task.Delay(3000) /*in loop // (to mimic progress bar)
        *  action part 3 
        */
      }
      ```
 - 