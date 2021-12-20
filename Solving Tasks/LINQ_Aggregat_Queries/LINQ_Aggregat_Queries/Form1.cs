using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_Aggregat_Queries
{
   public partial class Form1 : Form
   {
      public Form1()
      { InitializeComponent(); }

      //events:
      private void textBox1_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            try
            {
               double.Parse(textBox1.Text);
               listBox1.Items.Add(textBox1.Text);
               e.SuppressKeyPress = true;
            }
            catch (FormatException fe)
            {
               MessageBox.Show(
               "Please Enter a real number.\n\nMore information:\n" + fe.ToString()
               , fe.Message);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), ex.Message); }
            finally { textBox1.Clear(); }
         }
      }

      private void buttonStart_Click(object sender, EventArgs e)
      {
         if (listBox1.Items.Count > 0)
         {
            string[] strArr = listBox1.Items
                                      .OfType<string>()
                                      .ToArray();
            lblAnzahl.Text = Anzahl(strArr).ToString();
            lblSumme.Text = Summe(strArr).ToString();
            lblMittelwert.Text = Mittelwert(strArr).ToString();
            lblMaximum.Text = Maximum(strArr).ToString();
            lblMinimum.Text = Minimum(strArr).ToString();
         }
      }

      //methods:
      private double[] StringToDoubleArr(string[] strArr)      //helper
      { return strArr.Select(str => double.Parse(str)).ToArray(); }
      private double Anzahl(string[] strArr)                   //count
      { return StringToDoubleArr(strArr).Count(); }
      private double Summe(string[] strArr)                    //sum
      { return StringToDoubleArr(strArr).Sum(); }
      private double Mittelwert(string[] strArr)               //av
      { return StringToDoubleArr(strArr).Average(); }
      private double Maximum(string[] strArr)                  //max
      { return StringToDoubleArr(strArr).Max(); }
      private double Minimum(string[] strArr)                  //min
      { return StringToDoubleArr(strArr).Min(); }


   }
}