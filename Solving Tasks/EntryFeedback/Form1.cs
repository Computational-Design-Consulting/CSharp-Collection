using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntryFeedback
{
    public partial class EntryFeedback : Form
    {
        public EntryFeedback()
        {
            InitializeComponent();
        }

        private void cmdFeedback_Click(object sender, EventArgs e)
        {
            double value = 0;
            value = Convert.ToDouble(txtEntry.Text);

            
            //> or = or < 0?
            char operatorTest =
                value < 0 ? '<' :
                value == 0 ? '=' :
                '>';
            string tests = $"The entered value {value} is {operatorTest} 0";

            //Positive?
            if (value % 2 > 0)
                tests += "\nAlso, the value is an odd Number.";
            else if (value == 0)
                tests += "\nAlso, the value is Zero";
            else
                tests += "\nAlso, the value is an even Number.";
            lblFeedback.Text = tests;
        }
    }
}
