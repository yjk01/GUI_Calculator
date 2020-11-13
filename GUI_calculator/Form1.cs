using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_calculator
{
    public partial class Form1 : Form
    {
        protected string input;
        protected string output;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // AC 
        private void button1_Click(object sender, EventArgs e)
        {
            input = "";
            output = "";

            textBox1.Text = output + "\r\n--------------------\r\n" + input;
        }

        // +/-
        private void button2_Click(object sender, EventArgs e)
        {
            int i, j;

            string tmp1 = "";
            string tmp2 = "";

            // get any numerical value from the previous entry until it hits a operator and store it in a temp string
            for(i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == 'x' || input[i] == '/' || input[i] == '%' || input[i] == '+' || input[i] == '-')
                    break;

                else
                    tmp1 += input[i];
            }

            // add a negative sign infront of the temp string
            tmp1 += '-';

            // because we are going backwards in the string, reverse the string to get the correct number
            char[] arr = tmp1.ToCharArray();

            Array.Reverse(arr);

            tmp1 = new String(arr);

            // add any previous values inside a new temp string
            for(j = 0; j <=i; j++)
                tmp2 += input[j];

            // add the new negative number into the new temp string
            tmp2 += tmp1;

            input = tmp2;

            textBox1.Text = input;
        }

        // %
        private void button3_Click(object sender, EventArgs e)
        {
            input += "%";

            textBox1.Text = input;
        }

        // /
        private void button4_Click(object sender, EventArgs e)
        {
            input += "/";

            textBox1.Text = input;
        }

        // 1
        private void button5_Click(object sender, EventArgs e)
        {
            input += "1";
            
            textBox1.Text = input;

        }

        // 2
        private void button6_Click(object sender, EventArgs e)
        {
            input += "2";
            textBox1.Text = input;
        }

        // 3
        private void button7_Click(object sender, EventArgs e)
        {
            input += "3";

            textBox1.Text = input;
        }

        // +
        private void button8_Click(object sender, EventArgs e)
        {
            input += "+";

            textBox1.Text = input;

        }

        // 4
        private void button9_Click(object sender, EventArgs e)
        {
            input += "4";

            textBox1.Text = input;

        }

        // 5
        private void button10_Click(object sender, EventArgs e)
        {
            input += "5";

            textBox1.Text = input;

        }

        // 6
        private void button11_Click(object sender, EventArgs e)
        {
            input += "6";

            textBox1.Text = input;

        }

        // -
        private void button12_Click(object sender, EventArgs e)
        {
            input += "-";

            textBox1.Text = input;

        }

        // 7
        private void button13_Click(object sender, EventArgs e)
        {
            input += "7";

            textBox1.Text = input;

        }

        // 8
        private void button14_Click(object sender, EventArgs e)
        {
            input += "8";

            textBox1.Text = input;

        }

        // 9
        private void button15_Click(object sender, EventArgs e)
        {
            input += "9";

            textBox1.Text = input;

        }

        // x
        private void button16_Click(object sender, EventArgs e)
        {
            input += "x";

            textBox1.Text = input;

        }

        // 0
        private void button17_Click(object sender, EventArgs e)
        {
            input += "0";

            textBox1.Text = input;

        }

        // .
        private void button18_Click(object sender, EventArgs e)
        {
            input += ".";

            textBox1.Text = input;

        }

        // =
        private void button19_Click(object sender, EventArgs e)
        {
            output = input; // save the input to another string to preserve current expression
            string op = "x/%+-";   // string that contains all the operators(index the stirng to choose operator)

            int cop = 0, j = 0, k = 0;     // place holders to indicate location and operator index

            double fn = 0, sn = 0, ff = 0; // variables that will hold the "numbers" of the calculation

            // look for multiplication
            for (int i = 0; i < input.Length && cop < 5; i++)
            {
                string tmp1 = "";
                string tmp2 = "";
                string tmp3 = "";

                if (input[i] == op[cop])
                {
                    // loop through the first half of the string until it hits another operator(which indicated that the number is complete)
                    for (j = i - 1; j >= 0; j--)
                    {
                        bool isNeg = false;

                        if (input[j] == '-')
                            isNeg = true;

                        if (input[j] == 'x' || input[j] == '/' || input[j] == '%' || input[j] == '+' || (input[j] == '-' && isNeg == false))
                            break;

                        tmp1 += input[j];
                    }

                    // because we are going backwards in the string, reverse the string to get the correct number
                    char[] arr = tmp1.ToCharArray();

                    Array.Reverse(arr);

                    tmp1 = new string(arr);

                    // loop through the last half of the string until it hits another operator(which indicates that the number is complete)
                    for (k = i + 1; k < input.Length; k++)
                    {
                        bool isNeg = false;

                        if (input[k] == '-' && k == i + 1)
                            isNeg = true;

                        if (input[k] == 'x' || input[k] == '/' || input[k] == '%' || input[k] == '+' || (input[k] == '-' && isNeg == false))
                            break;

                        tmp2 += input[k];
                    }

                    fn = Convert.ToDouble(tmp1);
                    sn = Convert.ToDouble(tmp2);

                    tmp1 = "";
                    tmp2 = "";

                    // switch case that looks for what operation is to be done
                    switch (op[cop])
                    {
                        case 'x':
                            ff = fn * sn;
                            break;
                        case '/':
                            ff = fn / sn;
                            break;
                        case '%':
                            ff = fn % sn;
                            break;
                        case '+':
                            ff = fn + sn;
                            break;
                        case '-':
                            ff = fn - sn;
                            break;
                    }

                    // put the first half of the equation into the temp array
                    for (int l = 0; l <= j; l++)
                        tmp3 += input[l];

                    // put the calculated expression into the temp array
                    tmp3 += ff.ToString();

                    // put the last half of the equation into the temp array
                    for (int m = k; m < input.Length; m++)
                        tmp3 += input[m];

                    // update the input string with the new calculated equation
                    input = tmp3;

                    // reset the i value to look for more of the same operation
                    i = 0;

                    Console.WriteLine(input);
                }

                // if the input string does not contain the operation anymore, change to another operation
                if (i == input.Length - 1)
                {
                    cop++;
                    i = 0;
                }
            }

            // output
            textBox1.Text = output + "\r\n--------------------\r\n" + input;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
