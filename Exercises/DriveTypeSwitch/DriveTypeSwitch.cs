using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_LW_Typ
{
    class Program
    {
        static void Main(string[] args)
        { 
         // Read computer name
         Console.WriteLine("Computername: " + System.Environment.MachineName);

         //List drives
         foreach (string str in Environment.GetLogicalDrives())
               Console.WriteLine(str);
               // listBox1.Items.Add(s);

         Console.Title = "Den Typ der Laufwerke eines Systems ermitteln";

         // Determine all drives in system
         foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
         {
            // Print drive name
            Console.Write(driveInfo.Name);

            // Print drive type
            switch (driveInfo.DriveType)
            {
               case DriveType.CDRom:
                  Console.WriteLine("CD/DVD-ROM");
                  break;

               case DriveType.Fixed:
                  Console.WriteLine("Festplatten-Partition");
                  break;

               case DriveType.Ram:
                  Console.WriteLine("Ram-Disk");
                  break;

               case DriveType.Network:
                  Console.WriteLine("Netzwerklaufwerk");
                  break;

               case DriveType.NoRootDirectory:
                  Console.WriteLine("Laufwerk ohne Stamm-Verzeichnis");
                  break;

               case DriveType.Removable:
                  Console.WriteLine("Entfernbares Laufwerk");
                  break;

               case DriveType.Unknown:
                  Console.WriteLine("Unbekannter Typ");
                  break;
            }
         }

         Console.WriteLine();
         Console.WriteLine("Beenden mit Return");
         Console.ReadLine();
      }
    }
}
