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
      public void EditKunde(DataRowView dataRowView)
      {
         //wenn ein neuer Datensatz hinzugefügt wird
         if (dataRowView.Row.RowState == DataRowState.Detached) // detached = abgetrennt
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
            textBox1.Text = dataRowView["KundenCode"].ToString();
            textBox2.Text = dataRowView["Firma"].ToString();
            textBox3.Text = dataRowView["Kontaktperson"].ToString();
            textBox4.Text = dataRowView["Funktion"].ToString();
            textBox5.Text = dataRowView["Ort"].ToString();
         }
         if (this.ShowDialog() == DialogResult.OK) // "OK"
         {
            //speichern:
            dataRowView.BeginEdit();
            dataRowView["KundenCode"] = textBox1.Text;
            dataRowView["Firma"] = textBox2.Text;
            dataRowView["Kontaktperson"] = textBox3.Text;
            dataRowView["Funktion"] = textBox4.Text;
            dataRowView["Ort"] = textBox5.Text;
            dataRowView.EndEdit();
         }
         else // "Abbrechen"
            dataRowView.CancelEdit();
      }
      private void button1_Click(object sender, EventArgs e) =>
         DialogResult = DialogResult.OK;
      private void button2_Click(object sender, EventArgs e) =>
         DialogResult = DialogResult.Cancel;
   }
}
