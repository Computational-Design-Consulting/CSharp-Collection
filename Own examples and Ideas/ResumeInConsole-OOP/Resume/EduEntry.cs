using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume
{
  public class EduEntry : EntryBase
  {
    public EduEntry(int yearStart) : base(yearStart)
    { EduDescriptions = new string[0]; EduActivities = new string[0]; }
    public EduEntry(int yearStart, int yearEnd) : base(yearStart, yearEnd)
    { EduDescriptions = new string[0]; EduActivities = new string[0]; }
    public string Institution { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string EduTitle { get; set; }
    public string[] EduDescriptions { get; set; }
    public string[] EduActivities { get; set; }
    public override string ToString()
    {
      string descriptions = "";
      if (EduDescriptions.Length > 0)
      {
        foreach (string str in EduDescriptions)
          if (!string.IsNullOrEmpty(str))
            descriptions += " " + str.ToString();
        descriptions+="\n";
      }
      string activities = "";
      if (EduActivities.Length > 0)
      {
        foreach (string str in EduActivities)
          if (!string.IsNullOrEmpty(str))
            activities += " " + str.ToString();
        activities+= "\n";
      }
      return $"{Period}\t" +
        $"{Institution}\t" +
         $"{City}\t" +
         $"{Country}\n" +
         $"{EduTitle}\n" +
         $"{descriptions}" +
         $"{activities}";
    }
  }
}
