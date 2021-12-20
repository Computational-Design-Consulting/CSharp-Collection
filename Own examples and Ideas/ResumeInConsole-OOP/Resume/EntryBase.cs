using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume
{  public class EntryBase
  {
    internal int _yearStart, _yearEnd;
    public int[] _years;
    public EntryBase(int yearStart)
    {
      _yearStart = yearStart;
      _years = new int[] { _yearStart };
    }
    public EntryBase(int yearStart, int yearEnd) : this(yearStart)
    {
      _yearEnd = yearEnd;
      _years = new int[] { _yearStart, _yearEnd };
    }
    public int YearStart { get => _yearStart; set { _yearStart = value; } }
    public int YearEnd { get => _yearEnd; set { _yearEnd = value; } }
    public string Period { get => PeriodCalc(_years); }
    private string PeriodCalc(int[] years)
    {
      if (_yearEnd == 0)
        return years[0].ToString();
      else
        return $"{ _yearStart} - {_yearEnd}";
    }
  }
}
