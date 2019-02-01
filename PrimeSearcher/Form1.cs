using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.Caching;

namespace PrimeSearcher
{
    public partial class Form1 : Form
    {
        readonly private Messenger box3;
        readonly private Messenger box4;
        readonly private Messenger box5;

        public Form1()
        {
            InitializeComponent();

            box3 = new Messenger(new Format("_", "_"), (string str) => textBox3.AppendText(str));
            box4 = new Messenger(new Format("_", "_"), (string str) => textBox4.Text = str);
            box5 = new Messenger(new Format("_", "_"), (string str) => textBox5.Text = str);
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

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(textBox6.Text + (char)e.KeyValue);
            }
            catch (Exception)
            {
                if (!e.KeyData.Equals(Keys.Back))
                    e.SuppressKeyPress = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void searchWithStatisticExport()
        {
            int lowerBound = int.Parse(textBox1.Text);
            int upperBound = int.Parse(textBox2.Text);
            int repetitions = int.Parse(textBox6.Text);
            int threadNumber = (int)numericUpDown1.Value;
            iTester tester = comboBox1.Text.Equals("ASM") ? (iTester)new PrimeTesterASM() : (iTester)new PrimeTesterCsharp();

            Searcher sear;
            int tmp = upperBound;
            Stopwatch stopwatch;
            long sum = 0;
            bool[] table = null;
            upperBound = tmp;
            for (int ii = 0; ii < 10; ii++)
            {
                using (StreamWriter file = File.CreateText(comboBox1.Text + "_" + threadNumber + "_" + lowerBound + "_" + upperBound + ".txt"))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int index = 0; index < repetitions; index++)
                    {
                        sear = new Searcher(lowerBound, upperBound, threadNumber, tester);
                        table = null;
                        stopwatch = Stopwatch.StartNew();
                        table = sear.Proceed();
                        stopwatch.Stop();

                        sum += stopwatch.Elapsed.Ticks;
                        stringBuilder.AppendLine(stopwatch.Elapsed.Ticks.ToString());
                    }
                    file.Write(stringBuilder.ToString());
                    sum /= repetitions;
                    upperBound += tmp;
                }
                using (StreamWriter file = File.AppendText(comboBox1.Text + "_" + threadNumber + "_" + lowerBound + "_" + tmp + "-" + tmp * 10 + "_srednie.txt"))
                {
                    file.WriteLine(sum);
                }
            }
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < table.Length; i++)
                if (table[i]) s.Append((i + lowerBound).ToString() + Environment.NewLine);

            box3.Write(s.ToString());

            writeElapsedTicks(sum);
        }

        private void searchWithoutStatiscticExport()
        {
            int lowerBound = int.Parse(textBox1.Text);
            int upperBound = int.Parse(textBox2.Text);
            int repetitions = int.Parse(textBox6.Text);
            int threadNumber = (int)numericUpDown1.Value;
            iTester tester = comboBox1.Text.Equals("ASM") ? (iTester)new PrimeTesterASM() : (iTester)new PrimeTesterCsharp();

            Searcher sear = new Searcher(lowerBound, upperBound, threadNumber, tester);

            Stopwatch stopwatch = new Stopwatch();
            long sum = 0;
            bool[] table;

            stopwatch.Start();   
            table = sear.Proceed();
            stopwatch.Stop();

            sum = stopwatch.ElapsedTicks;

            StringBuilder s = new StringBuilder();

            for (int i = 0; i < table.Length; i++)
                if (table[i]) s.Append((i + lowerBound).ToString() + Environment.NewLine);

            box3.Write(s.ToString());
            writeElapsedTicks(sum);
        }

        private void checkExceptions()
        {
            int lowerBound = int.Parse(textBox1.Text);
            int upperBound = int.Parse(textBox2.Text);

            if (lowerBound < 2)
                throw new Exception("lower bound must be bigger than 1");

            if (lowerBound > upperBound)
                throw new Exception("lower bound can't be bigger than upper bound");

            if (!comboBox1.Text.Equals("ASM") && !comboBox1.Text.Equals("C#"))
                throw new Exception("comboBox string incorrect");
        }

        private void writeElapsedTicks(long ticks)
        {
            if (comboBox1.Text.Equals("ASM"))
            {
                box4.Write(ticks.ToString());
            }
            else if (comboBox1.Text.Equals("C#"))
            {
                box5.Write(ticks.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            textBox3.Clear();
            try
            {
                checkExceptions();               
                
                if(checkBox1.Checked)
                {
                    searchWithStatisticExport();
                }
                else
                {
                    searchWithoutStatiscticExport();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR DETECTED", MessageBoxButtons.OK);
            }
            label6.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Visible = checkBox1.Checked;
            label8.Visible = checkBox1.Checked;
        }
    }
}
