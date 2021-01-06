using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    public partial class Calculator : Form
    {
        private double result = 0;
        private string operators = "";
        private bool isOperationPerformed = false;
        private byte count = 0;
        private double temp = 0;
        public Calculator()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if((this.txtResult.Text == "0") || (this.isOperationPerformed))
            {
                this.txtResult.Clear();
                
            }
            this.isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!this.txtResult.Text.Contains("."))
                {
                    this.txtResult.Text = this.txtResult.Text + button.Text;
                }
            }
            else
            {
                this.txtResult.Text = this.txtResult.Text + button.Text;
            }
            this.count = 0;

        }
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (this.result != 0 && this.count == 0)
            {
                btnEqual.PerformClick();
            }
            else
            {
                this.result = Convert.ToDouble(this.txtResult.Text);
            }
            this.operators = button.Text;
            this.lblOperation.Text = this.result + " " + this.operators;
            this.isOperationPerformed = true;

        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = "0";
            this.result = 0;
            this.lblOperation.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if(this.count == 0) 
            {
                this.temp = Convert.ToDouble(this.txtResult.Text);
                this.count++;
                this.lblOperation.Text = this.lblOperation.Text + " " + this.txtResult.Text;
                switch (operators)
                {
                    case "+":
                        this.txtResult.Text = (this.result + this.temp).ToString();
                        break;
                    case "-":
                        this.txtResult.Text = (this.result - this.temp).ToString();
                        break;
                    case "*":
                        this.txtResult.Text = (this.result * this.temp).ToString();
                        break;
                    case "/":
                        this.txtResult.Text = (this.result / this.temp).ToString();
                        break;
                    default:
                        break;
                }

            }
            
            else if (this.count == 1)
            {
                switch (operators)
                {
                    case "+":
                        this.txtResult.Text = (this.result + this.temp).ToString();
                        break;
                    case "-":
                        this.txtResult.Text = (this.result - this.temp).ToString();
                        break;
                    case "*":
                        this.txtResult.Text = (this.result * this.temp).ToString();
                        break;
                    case "/":
                        this.txtResult.Text = (this.result / this.temp).ToString();
                        break;
                    default:
                        break;
                }
                this.lblOperation.Text = this.result + " " + this.operators + " " + this.temp;

            }
            this.result = Convert.ToDouble(this.txtResult.Text);

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (!this.txtResult.Text.Contains("-"))
            {
                this.txtResult.Text = "-" + this.txtResult.Text;

            }
            else
            {
                this.txtResult.Text = this.txtResult.Text.Remove(0, 1);
            }
        }
    }
}
