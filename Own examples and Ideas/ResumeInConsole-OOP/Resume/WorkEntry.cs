using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume
{
  public class WorkEntry : EntryBase
  {
    public WorkEntry(int yearStart) : base(yearStart)
    { WorkTitles = new string[0]; WorkDescriptions = new string[0]; }
    public WorkEntry(int yearStart, int yearEnd) : base(yearStart, yearEnd)
    { WorkTitles = new string[0]; WorkDescriptions = new string[0]; }
    public string Company { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string WorkPosition { get; set; }
    public string[] WorkTitles { get; set; }
    public string[] WorkDescriptions { get; set; }
    public string WorkApplication { get; set; }
    public string Reference { get; set; }
    public override string ToString()
    {
      string titles = "";
      if (WorkTitles.Length > 0)
      {
        foreach (string str in WorkTitles)
          if (!string.IsNullOrEmpty(str))
            titles += " " + str.ToString();
        titles += "\n";
      }
      string descriptions = "";
      if (WorkDescriptions.Length > 0)
      {
        foreach (string str in WorkDescriptions)
          if (!string.IsNullOrEmpty(str))
            descriptions += " " + str.ToString();
        descriptions += "\n";
      }
      return $"{Period}\t" +
        $"{Company}\t" +
         $"{City}\t" +
         $"{Country}\n" +
         $"{WorkPosition}\n" +
         $"{titles}" +
         $"{descriptions}" +
         $"{WorkApplication}" +
         $"{Reference+"\n"}";
    }
  }
}
