using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabenW6D1_BahnhoefeZeichenen1
{
   public class Haltestelle
   {
      int _eva_nr;
      string _ds100;
      string _ort;
      string _verkehr;
      double _breite;
      double _länge;
      bool _isHbf;                           //better as instance variable

      /// <summary>
      /// using .EndsWith("Hbf") to instantiate
      /// </summary>
      /// <param name="eva_nr"></param>
      /// <param name="ds100"></param>
      /// <param name="ort"></param>
      /// <param name="verkehr"></param>
      /// <param name="länge"></param>
      /// <param name="breite"></param>
      public Haltestelle(int eva_nr, string ds100,
         string ort, string verkehr, double länge, double breite)
      {
         _eva_nr = eva_nr;
         _ds100 = ds100;
         _ort = ort;
         _verkehr = verkehr;
         _länge = länge;
         _breite = breite;
         _isHbf = _ort.EndsWith("Hbf");      //faster here
      }

      public int Eva_nr
      { get { return _eva_nr; } }
      public string Ds100
      { get { return _ds100; } }
      public string Ort
      { get { return _ort; } }
      public string Verkehr
      { get { return _verkehr; } }
      public double Länge
      { get { return _länge; } }
      public double Breite
      { get { return _breite; } }
      //public bool IsHbf
      //{ get { return _ort.EndsWith("Hbf"); } }   //slows down drawing
      public bool IsHbf
      { get { return _isHbf; } }                   //do when instancing instead
      public override string ToString()
      { return _ort; }
   }
}
