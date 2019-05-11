using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCalculator
{
    public partial class Calculator : Form
    {
        // Setting the variables
        // Used Double because of decimal answers
        // The value is declared as endValue which will always be set to 0 when starting the program or when clearing the program
        Double endValue = 0;
        String methodExecuted = "";
        bool ismethodExecuted = false;

        

        public Calculator()
        {
            InitializeComponent();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            if ((TxtResult.Text == "0") || (ismethodExecuted))
                TxtResult.Clear();
            ismethodExecuted = false;
            Button button = (Button)sender;
            TxtResult.Text = TxtResult.Text + button.Text;
        }

        private void TxtResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void MethodClick(object sender, EventArgs e)
        { 
            // MethodClick is what executes when the user clicks on addition, substraction, multiplication, or division
            Button button = (Button)sender;
            if (endValue != 0)
            {
                EnterKey.PerformClick();
                methodExecuted = button.Text;
                endValue = Double.Parse(TxtResult.Text);
                ismethodExecuted = true;
                LblOperation.Text = endValue + " " + methodExecuted;
            }
            else
            // Statement if the endValue is equal to 0
            {

                methodExecuted = button.Text;
                endValue = Double.Parse(TxtResult.Text);
                ismethodExecuted = true;
                LblOperation.Text = endValue + " " + methodExecuted;

            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //Sets the text box where the answer shows up to 0 when the C button is clicked
            TxtResult.Text = "0";
            endValue = 0;

        }

        private void EnterKey_Click(object sender, EventArgs e)
        { 
            //Switch statement for all of the operations

            switch (methodExecuted)
            {
                case "+":
                    TxtResult.Text = (endValue + Double.Parse(TxtResult.Text)).ToString();
                    break;
                case "-":
                    TxtResult.Text = (endValue - Double.Parse(TxtResult.Text)).ToString();
                    break;
                case "*":
                    TxtResult.Text = (endValue * Double.Parse(TxtResult.Text)).ToString();
                    break;
                case "/":
                    TxtResult.Text = (endValue / Double.Parse(TxtResult.Text)).ToString();
                    break;
                default:
                    break;
            }

            //LblOperation shows the preview of the numbers and operations being entered, it has no text because it has no value by default
            endValue = Double.Parse(TxtResult.Text);
            LblOperation.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

