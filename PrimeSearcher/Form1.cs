using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSearcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(textBox1.Text + (char)e.KeyValue);
            }
            catch(Exception)
            {
                if(!e.KeyData.Equals(Keys.Back))
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(textBox2.Text + (char)e.KeyValue);
            }
            catch (Exception)
            {
                if (!e.KeyData.Equals(Keys.Back))
                    e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lowerBound = int.Parse(textBox1.Text);
            int upperBound = int.Parse(textBox2.Text);

            bool prime = true;

            textBox3.Text = "";
            
            progressBar1.Visible    = true;
            progressBar1.Minimum    = lowerBound;
            progressBar1.Maximum    = upperBound;
            progressBar1.Value      = lowerBound;
            progressBar1.Step       = 1;

            for (int dividend = lowerBound; dividend <= upperBound; dividend++)
            {
                for(int divider = 2; divider <= Math.Sqrt(dividend); divider++)
                {
                    if (dividend % divider == 0)
                    {
                        prime = false;
                        divider = dividend;
                    }
                }
                if (prime)
                {
                    textBox3.AppendText(dividend.ToString() + System.Environment.NewLine);
                }

                progressBar1.PerformStep();
                prime = true;
            }
            
            progressBar1.Visible = false;
        }
    }
}
