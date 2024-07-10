using System;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {

        private string expressao = "";
        private double result = 0;
        private bool resetOnNextInput = false;
        private bool lastInputWasOperator = false;
        private bool lastInputWasEqual = false;
        private const int MaxDisplay = 13;

        public Form1()
        {
            InitializeComponent();
            tbdisplay.ReadOnly = true;
        }

        private void AddNumberToDisplay(string number)
        {
            Reset();
            lastInputWasOperator = false;
            lastInputWasEqual = false;

            if (tbdisplay.Text.Length >= MaxDisplay)
            {
                return;
            }

            tbdisplay.Text += number;
            lbRes.Text += number;

        }
        private void AddOperatorToDisplay(string op)
        {

            lastInputWasEqual = false;

            if (tbdisplay.TextLength <= 0)
            {
                return;
            }

            if (lastInputWasOperator == true)
            {
                return;
            }
            resetOnNextInput = false;
            lbRes.Text += op;
            tbdisplay.Text += op;
            lastInputWasOperator = true;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            //botão C

            lastInputWasEqual = false;
            lastInputWasOperator = false;
            tbdisplay.Text = "";
            lbRes.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //botão /
            AddOperatorToDisplay("/");

        }
        private void btnadicao_Click(object sender, EventArgs e)
        {
            //botão +
            AddOperatorToDisplay("+");
        }

        private void btnsubt_Click(object sender, EventArgs e)
        {
            //botão -
            AddOperatorToDisplay("-");
        }

        private void btnmultip_Click(object sender, EventArgs e)
        {
            //botão *
            AddOperatorToDisplay("*");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //botão 0
            AddNumberToDisplay("0");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //botão 1
            AddNumberToDisplay("1");

        }
        private void btn2_Click(object sender, EventArgs e)
        {
            //botão 2
            AddNumberToDisplay("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            //botão 3
            AddNumberToDisplay("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            //botão 4
            AddNumberToDisplay("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //botão 5
            AddNumberToDisplay("5");
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            //botão 6
            AddNumberToDisplay("6");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //botão 7
            AddNumberToDisplay("7");
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            //botão 8
            AddNumberToDisplay("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            //botão 9
            AddNumberToDisplay("9");
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            //botão .
            if (tbdisplay.TextLength <= 0)
            {
                return;
            } else {
                AddOperatorToDisplay(".");
            }
        }

        private void btnequals_Click(object sender, EventArgs e)
        {
            if (tbdisplay.TextLength <= 1)
            {
                return;
            }
            if (lastInputWasOperator)
            {
                return;
            }
            if (lastInputWasEqual)
            {
                return;
            }
            lastInputWasEqual = true;
            try
            {
                resetOnNextInput = true;
                expressao = tbdisplay.Text;
                result = Eval(expressao);

                    if (result % 1 != 0)
                    {
                        string Fresult = result.ToString("F2");
                        Fresult = Fresult.Replace(',', '.');
                        tbdisplay.Text = Fresult;
                        lbRes.Text += "=" + Fresult;
                    } else
                    {
                         tbdisplay.Text = Convert.ToString(result);
                         lbRes.Text += "=" + Convert.ToString(result);
                    }    
            }
            catch (OverflowException)
            {
                tbdisplay.Text = "Overflow";
            }
            catch
            {
                tbdisplay.Text = "ERRO";
            }

            lastInputWasOperator = false;
        } 

        static Double Eval(String expression)
        {
            expression = expression.Replace(',', '.');
            System.Data.DataTable table = new System.Data.DataTable();
            return Convert.ToDouble(table.Compute(expression, String.Empty));
        }

        private void Reset()
        {
            if (tbdisplay.Text.Length >= MaxDisplay)
            {
                return;
            }

            if (resetOnNextInput == true)
            {
                tbdisplay.Text = "";
                lbRes.Text = "";
                resetOnNextInput = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
