using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _5days_app
{
    public partial class Form1 : Form
    {
        private int count = 0;
        private string file_num;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int in1 = 1;
            int in2 = 1;
            if (!Int32.TryParse(textBox1.Text, out in1) || !Int32.TryParse(textBox2.Text, out in2))
            {
                textBox2.Text = textBox1.Text = "18782";
                label2.Text = "+";
                label3.Text = "37564";
                return;
            }
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

            //String[] str = new String[3];
            //str[0] += "成し遂げたぜ。大吉";
            //str[1] += "まあまあ。吉";
            //str[2] += "凶";
            String[] str =
            {
                "成し遂げたぜ。大吉",
                "まあまあ。吉",
                "凶"
            };

            label3.Text += str[lots];

            //switch(lots)
            //{
            //    case (1):
            //        label3.Text += "成し遂げたぜ。大吉";
            //        break;
            //    case (2):
            //        label3.Text += "まあまあ。吉";
            //        break;
            //    default:
            //        label3.Text += "凶";
            //        break;
            //}
        }

        private void label4_Click(object sender, EventArgs e)
        {
       }

        private void button7_Click(object sender, EventArgs e)
        {
            Referee referee = new Referee();
            label4.Text = referee.Decision(0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label4.Text = new Referee().Decision(1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label4.Text = new Referee().Decision(2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            file_num = "01";
            timer1.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //NewDivination div = new NewDivination();
            NewDivination div = new ObaachanDiv();
            switch (count)
            {
                case 0:
                    timer1.Interval = 2000;
                    richTextBox1.Text = div.Concentration(0);
                    break;
                case 1:
                    richTextBox1.Text = div.Concentration(1);
                    break;
                case 3:
                    richTextBox1.Text = div.Divine(file_num);
                    timer1.Enabled = false;
                    count = -1;
                    break;
            }
            count++;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            file_num = "02";
            timer1.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            file_num = "03";
            timer1.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            file_num = "04";
            timer1.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            file_num = "05";
            timer1.Enabled = true;
        }
    }

    public class Referee {

        int pc = new Random().Next(3);

        // デフォルトで private
        string[] hand = { "✊", "✌", "✋" };
        public string Decision(int user)
        {
            string msg = "コンピューターの手は" + hand[pc] +"\n";

            if(pc == user)
            {
                msg += "引き分け";
            }
            else if((pc+1 == user) || (pc == 2 && user == 0))
            {
                msg += "コンピューターの勝ち";
            }
            else
            {
                msg += "あなたの勝ち";
            }

            return msg;
        }
    }

    public class Divination
    {
        public string Divine(string no)
        {
            string divmsg = "";
            string file_name = "..\\..\\unsei" + no + ".txt";
            StreamReader streamReader = new System.IO.StreamReader(file_name);
            string s;
            while ((s = streamReader.ReadLine()) != null)
            {
                divmsg += s + "\n";
            }
            streamReader.Close();
            return divmsg;
        }
    }
    abstract public class NewDivination : Divination
    {
        abstract public string Concentration(int no);
        //virtual public string Concentration(int no)
        //{
        //    string[] msg =
        //    {
        //        "ふんふん", "う～ん"
        //    };
        //    return msg[no];
        //}
    }
    public class HumboldtiDiv : NewDivination
    {
        override public string Concentration(int no)
        {
            string[] msg =
            {
                "ふんふん", "う～ん"
            };
            return msg[no];
        }
    }
    public class ObaachanDiv : NewDivination
    {
        override public string Concentration(int no)
        {
            string[] msg =
                {"なんでござんますか？","しょうがんないねぇ..."};
            return msg[no];
        }
    }
}
