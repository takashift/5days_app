using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5days_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int in1 = Int32.Parse(textBox1.Text);
            int in2 = Int32.Parse(textBox2.Text);
            //int ans = in1 + in2;
            int ans = 0;

            //if(label2.Text == "+")
            //{
            //    ans = in1 + in2;
            //}
            //else if (label2.Text == "-")
            //{
            //    ans = in1 - in2;
            //}
            //else if (label2.Text == "×")
            //{
            //    ans = in1 * in2;
            //}
            ////if (label2.Text == "÷")
            //else
            //{
            //    ans = in1 / in2;
            //}

            switch (label2.Text)
            {
                case ("+"):
                    ans = in1 + in2;
                    break;
                case ("-"):
                    ans = in1 - in2;
                    break;
                case ("×"):
                    ans = in1 * in2;
                    break;
                default:
                    ans = in1 / in2;
                    break;
            }
            label3.Text = ans.ToString();
            //label1.Text = "こんにちは。";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "+";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "×";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "÷";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int lots = r.Next(3);
            label3.Text = "今日の運勢は";
            switch(lots)
            {
                case (1):
                    label3.Text += "成し遂げたぜ。大吉";
                    break;
                case (2):
                    label3.Text += "まあまあ。吉";
                    break;
                default:
                    label3.Text += "凶";
                    break;
            }
        }
    }
}
