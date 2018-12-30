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
            try
            {
                int lowerBound = int.Parse(textBox1.Text);
                int upperBound = int.Parse(textBox2.Text);

                if (lowerBound < 2)
                    throw new Exception("lower bound must be bigger than 1");

                if (lowerBound > upperBound)
                    throw new Exception("lower bound can't be bigger than upper bound");
                
                textBox3.Text = "";

                progressBar1.Visible = true;
                progressBar1.Minimum = lowerBound;
                progressBar1.Maximum = upperBound;
                progressBar1.Value = lowerBound;
                progressBar1.Step = 1;

                Searcher sear = new Searcher(lowerBound, upperBound, 3, null);

                var table = sear.searchForPrimes();

                for (int i = 0; i < table.Length; i++)
                    if(table[i]) textBox3.AppendText((i + lowerBound).ToString());

                progressBar1.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR DETECTED", MessageBoxButtons.OK);
            }
        }
    }
}
