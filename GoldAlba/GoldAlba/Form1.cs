using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GoldAlba
{
    public partial class Form1 : Form
    {
        private double Get1Pay()
        {
            double _1dayPay = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            double _1dayWorking = double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            double _1monthWorks = double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture);

            double inComeTexMinus = _1dayPay * (3.3 / 100.0);
            double _1dayPayMinus = _1dayPay - inComeTexMinus;

            return _1dayPayMinus * _1dayWorking * _1monthWorks;
        }

        private void ControlProgressValue()
        {
            int ProgressInt = 3;

            if (textBox1.Text == "")
            {
                ProgressInt--;
            }

            if (textBox2.Text == "")
            {
                ProgressInt--;
            }

            if (textBox3.Text == "")
            {
                ProgressInt--;
            }

            progressBar1.Value = ProgressInt;

            if (ProgressInt == 3)
            {
                progressBar1.ForeColor = Color.Green;
            }
            else
            {
                progressBar1.ForeColor = Color.Red;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Text = "AlbaGold@orangelie";
            this.DoubleBuffered = true;

            textBox4.ReadOnly = true;

            progressBar1.ForeColor = Color.Red;
            progressBar1.Style = ProgressBarStyle.Continuous;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = Get1Pay().ToString() + " (원)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("Output.txt", Get1Pay().ToString() + " (원)", System.Text.Encoding.UTF8);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ControlProgressValue();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ControlProgressValue();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ControlProgressValue();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "제작자: orangelie\n" +
                "홈페이지: https://github.com/orangelie\n" +
                "그림출처: pinterest\n"
                );
        }
    }
}
