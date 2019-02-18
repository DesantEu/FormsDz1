using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsDz1
{
    public partial class Form1 : Form
    {
        private int top = 2000;
        int bot = 0;
        int num = 2000;

        int iter = 0;
        string title = "Number guesser 3000";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = $"top {top}";
            label2.Text = $"bot {bot}";
            iter++;
            DialogResult dr = MessageBox.Show($"Is Your number smaller then {num}?", title, MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)//guess < num
            {
                top = num;
                num = (top + bot) / 2;
                button1_Click(sender, e);
            }
            else if (dr == DialogResult.No)
            {
                if (iter == 1) MessageBox.Show("You can only choose a number below 2000");
                else
                {
                    DialogResult dr2 = MessageBox.Show($"Is Your number Bigger then {num}?", title, MessageBoxButtons.YesNo);

                    // guess > num
                    if (dr2 == DialogResult.Yes)
                    {
                        bot = num;
                        num = (bot + top) / 2;
                        button1_Click(sender, e);
                    }
                    else if (dr2 == DialogResult.No)
                    {
                        DialogResult dr3 = MessageBox.Show($"Is your number {num}?", title, MessageBoxButtons.YesNo);
                        if (dr3 == DialogResult.Yes)//final
                        {
                            MessageBox.Show($"Your number is {num}" +
                                $"\ndone in {iter} iterations");
                            bot = 0;
                            top = 2000;
                            num = 2000;iter = 0;
                        }
                        if (dr3 == DialogResult.No)

                            button1_Click(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("error");
            }
            iter = 0;
        }
    }
}
