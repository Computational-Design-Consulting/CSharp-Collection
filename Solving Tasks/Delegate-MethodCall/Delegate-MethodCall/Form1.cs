using System;
using System.Windows.Forms;

namespace Delegate_MethodCall
{

   public partial class Form1 : Form
   {
      OperationHandler calculate;      //Delegate Method call

      private double op1, op2;         //global variables

      public Form1() { InitializeComponent(); }

      ///events:
      ///
      private void Form1_Load(object sender, EventArgs e)   //default
      {
         textBoxOperator1.Text = 3.5.ToString();
         textBoxOperator2.Text = 4.ToString();
      }
      //Call Without Delegate:
      private void buttonCallWithoutDelegate_Click(object sender, EventArgs e)
      {
         GetValues();
         if (radioButtonAdd.Checked)
            textBoxResult.Text = (op1 + op2).ToString();
         else
            textBoxResult.Text = (op1 * op2).ToString();
      }
      //With Delegate Call:
      private void buttonCallWithDelegate_Click(object sender, EventArgs e)
      {
         GetValues();
         if (radioButtonAdd.Checked)
            calculate = new OperationHandler(Calc.Add);
         else
            calculate = new OperationHandler(Calc.Multiply);
         textBoxResult.Text = calculate(op1, op2);
      }
      //Simplified Delegate Call:
      private void buttonCallSimple_Click(object sender, EventArgs e)
      {
         GetValues();
         if (radioButtonAdd.Checked)
            textBoxResult.Text = Calc.Add(op1, op2);
         else
            textBoxResult.Text = Calc.Multiply(op1, op2);
      }
      //Anonymous Method:
      private void buttonAnonymousMethod_Click(object sender, EventArgs e)
      {
         GetValues();
         if (radioButtonAdd.Checked)
            calculate = delegate (double x, double y)
            { return (x + y).ToString(); };
         else
            calculate = delegate (double x, double y)
            { return (x * y).ToString(); };
         textBoxResult.Text = calculate(op1, op2);
      }
      //Lambda Expression:
      private void buttonLambdaExpressions_Click(object sender, EventArgs e)
      {
         GetValues();
         Func<double, double, string> add = (x, y) => (x + y).ToString();
         Func<double, double, string> multi = (x, y) => (x * y).ToString();
         if (radioButtonAdd.Checked)
            textBoxResult.Text = add(op1, op2);
            //textBoxResult.Text = (op1, op2) => (x + y).ToString();
         else
            textBoxResult.Text = multi(op1, op2);
      }


      private void buttonClose_Click(object sender, EventArgs e)
      { Close(); }

      //methods:
      private void GetValues()   //Input Parser:   (nice handling!)
      {
         double.TryParse(textBoxOperator1.Text, out op1);
         double.TryParse(textBoxOperator2.Text, out op2);
      }
   }
}
