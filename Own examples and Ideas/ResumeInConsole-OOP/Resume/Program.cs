using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume
{
  class Program
  {
    static void Main(string[] args)
    {
      var cv = new ResumeLibrary();
      Console.WriteLine(cv.ToString());
      Console.ReadLine();
    }
  }
}
