using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZweiFormulareEineDatenQuelle
{
   public partial class Form2 : Form
   {
      public Form2()
      { InitializeComponent(); }

      // der Übergabeparameter ist die aktuelle Zeile
      public void EditKunde(DataRowView drv)
      {
         //wenn ein neuer Datensatz hinzugefügt wird
         if (drv.Row.RowState == DataRowState.Detached) // detached = abgetrennt
         {
            textBox1.Text = "PQNRP";
            textBox2.Text = "Empire";
            textBox3.Text = "Yoda";
            textBox4.Text = "Jedi";
            textBox5.Text = "Space";
         }
         else //wenn ein vorhandener Datensatz geändert wird
         {
            //anzeigen:
            textBox1.Text = drv["KundenCode"].ToString();
            textBox2.Text = drv["Firma"].ToString();
            textBox3.Text = drv["Kontaktperson"].ToString();
            textBox4.Text = drv["Funktion"].ToString();
            textBox5.Text = drv["Ort"].ToString();
         }
         if (this.ShowDialog() == DialogResult.OK) // "OK"
         {
            //speichern:
            drv.BeginEdit();
            drv["KundenCode"] = textBox1.Text;
            drv["Firma"] = textBox2.Text;
            drv["Kontaktperson"] = textBox3.Text;
            drv["Funktion"] = textBox4.Text;
            drv["Ort"] = textBox5.Text;
            drv.EndEdit();
         }
         else // "Abbrechen"
            drv.CancelEdit();
      }
      private void button1_Click(object sender, EventArgs e)
      { DialogResult = DialogResult.OK; }
      private void button2_Click(object sender, EventArgs e)
      { DialogResult = DialogResult.Cancel; }
   }
}
