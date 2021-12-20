using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schieberegler
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         FarbeAnzeigen();
      }
      private void FarbeAnzeigen()
      {
         panFarbe.BackColor = Color.FromArgb(
            trkRot.Value, trkGrün.Value, trkBlau.Value);
         lblRotWert.Text = "" + trkRot.Value;
         lblGrünWert.Text = "" + trkGrün.Value;
         lblBlauWert.Text = "" + trkBlau.Value;
      }

      private void WertGeändert(object sender, EventArgs e)
      {
         FarbeAnzeigen();
      }
   }
}
