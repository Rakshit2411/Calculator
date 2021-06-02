using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        int firstNum = 0;
        string operation = "";
        char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public Form1()
        {
            InitializeComponent();
        }

        private void PrintNum(string num)
        {
            if (textBox_result.Text.Length == 1 && textBox_result.Text == "0")
            {
                textBox_result.Text = num;
            }
            else
            {
                textBox_result.Text += num;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintNum("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintNum("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintNum("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintNum("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintNum("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrintNum("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrintNum("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PrintNum("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PrintNum("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            PrintNum("0");
        }
        private void button_decimal_Click(object sender, EventArgs e)
        {
            PrintNum(".");
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            operation = "sum";
            firstNum = int.Parse(textBox_result.Text);
            textBox_result.Text = "0";
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            operation = "sub";
            firstNum = int.Parse(textBox_result.Text);
            textBox_result.Text = "0";
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            operation = "multi";
            firstNum = int.Parse(textBox_result.Text);
            textBox_result.Text = "0";
        }

        private void button_devide_Click(object sender, EventArgs e)
        {
            operation = "devide";
            firstNum = int.Parse(textBox_result.Text);
            textBox_result.Text = "0";
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            int secondNum = int.Parse(textBox_result.Text);
            if (operation == "sum")
            {
                textBox_result.Text = (firstNum + secondNum).ToString();
            }
            else if (operation == "sub")
            {
                textBox_result.Text = (firstNum - secondNum).ToString();
            }
            else if (operation == "multi")
            {
                textBox_result.Text = (firstNum * secondNum).ToString();
            }
            else if (operation == "devide")
            {
                textBox_result.Text = (firstNum / secondNum).ToString();
            }
            else
            {
                textBox_result.Text = (secondNum).ToString();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
        }

        private void textBox_result_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private string MakeBinary(int num)
        {
            string bin = "";
            string result = "";
            if (num == 1)
            {
                bin = "1";
            }
            else if (num == 0)
            {
                bin = "0";
            }

            while (num != 1)
            {
                bin += (num % 2).ToString();
                num /= 2;
            }
            bin += "1";
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                result += bin[i];
            }
            return result;
        }

        private void button_bin_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox_result.Text);
            string result = "";
            if (num >= 0)
            {
                result = MakeBinary(num);
            }
            textBox_result.Text = result;
        }

        private string MakeNumber(string bin)
        {
            if (!IsBinary(int.Parse(bin)))
            {
                return bin;
            }
            double result = 0.0;
            char[] charArray = bin.ToCharArray();
            Array.Reverse(charArray);

            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                if (charArray[i] == '1')
                {
                    result += Math.Pow(2, i);
                }
            }

            return result.ToString();
        }

        public bool IsBinary(int num)
        {
            int j = 0;
            while (num > 0)
            {
                j = num % 10;
                if ((j != 0) && (j != 1))
                {
                    return (false);
                }
                num /= 10;
            }
            return (true);
        }

        private void button_dec_Click(object sender, EventArgs e)
        {
            string bin = textBox_result.Text;
            string result = MakeNumber(bin);
            textBox_result.Text = result;
        }

        private void button_lon_Click(object sender, EventArgs e)
        {
            double num = double.Parse(textBox_result.Text);
            string answer = "";
            while (num > 0)
            {
                int power = CountPower(num);
                answer += letters[power];
                num -= Math.Pow(2, power);
            }

            char[] charArray = answer.ToCharArray();
            Array.Reverse(charArray);
            textBox_result.Text = new string(charArray);
        }

        private int CountPower(double num)
        {
            int counter = 0;
            int num2 = Convert.ToInt32(num);
            if (num2 == 1)
            {
                return 0;
            }
            while (num2 >= 2)
            {
                num2 /= 2;
                counter++;
            }

            return counter;
        }
    }
}
