using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace prjWinCsCalculator
{
    public partial class frmStabdard1 : Form
    {
        public frmStabdard1()
        {
            InitializeComponent();
        }

        String opr, inputOne,inputTwo,temp;
        Double operandOne,operandTwo,total;

        private void frmStabdard1_Load(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = false;
            lblExp.Text = "";
            lblExp.Visible = false;
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = true;
            btnMC.ForeColor = btnMR.ForeColor = Color.Black;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = false;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = false;
        }

        private void btnMadd_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = true;
            btnMC.ForeColor = btnMR.ForeColor = Color.Black;
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = true;
            btnMC.ForeColor = btnMR.ForeColor = Color.Black;
        }


        private void btnCE_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblExp.Text="";
            lblExp.Visible = false;
            lblResult.Text = "0";
            inputOne = inputTwo =null;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            displayBtnText(btnOne.Text); 
        }

        private void displayBtnText(string btntext)
        {
            if (!btnPlus.Enabled || !btnMinus.Enabled || !btnMul.Enabled || !btnDivide.Enabled)
            {
                lblResult.Text = btntext;
            }
            else
            {
                lblResult.Text = lblResult.Text == "0" && lblResult.Text != null ? btntext : lblResult.Text + btntext ;
            }
            btnPlus.Enabled = btnMinus.Enabled = btnMul.Enabled = btnDivide.Enabled = true;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            displayBtnText(btnTwo.Text);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            displayBtnText(btnThree.Text);

        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            displayBtnText(btnFour.Text);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            displayBtnText(btnFive.Text);

        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            displayBtnText(btnSix.Text);

        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            displayBtnText(btnSeven.Text);

        }

        private void btneight_Click(object sender, EventArgs e)
        {
            displayBtnText(btneight.Text);

        }

        private void btnnine_Click(object sender, EventArgs e)
        {
            displayBtnText(btnnine.Text);

        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            displayBtnText(btnZero.Text);

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            opr = btnPlus.Text;
            displayExpression(btnPlus.Text);
            btnPlus.Enabled = false;
            if(!btnMinus.Enabled || !btnMul.Enabled || !btnDivide.Enabled)
            {
                btnMinus.Enabled = btnMul.Enabled = btnDivide.Enabled = true;
            }
            checkInputs(opr);     
        }

        private void displayExpression(String exp)
        {
            lblExp.Visible = true;
            lblExp.Text += lblResult.Text + exp;
        }

        private void checkInputs(String opr)
        {
            
            if (inputOne == null)
            {
                inputOne = lblResult.Text;
                operandOne = Convert.ToDouble(inputOne);
                temp = opr;
            }
            else if(inputTwo==null)
            {
                inputTwo = lblResult.Text;
                operandTwo = Convert.ToDouble(inputTwo);           
            }

            if (inputOne != null && inputTwo != null)
            {
                performCalculation();
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            opr = btnMul.Text;
            displayExpression(btnMul.Text);
            btnMul.Enabled = false;
            if (!btnMinus.Enabled || !btnPlus.Enabled || !btnDivide.Enabled)
            {
                btnMinus.Enabled = btnPlus.Enabled = btnDivide.Enabled = true;
            }
            checkInputs(opr);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            opr = btnDivide.Text;
            displayExpression(btnDivide.Text);
            btnDivide.Enabled = false;
            if (!btnMinus.Enabled || !btnPlus.Enabled || !btnMul.Enabled)
            {
                btnMinus.Enabled = btnPlus.Enabled = btnMul.Enabled = true;
            }
            checkInputs(opr);

        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
                lblExp.Visible = true;
                inputOne = lblResult.Text;
                operandOne = Convert.ToDouble(inputOne);
                lblExp.Text = "Sqr(" + operandOne + ")";
                lblResult.Text = (operandOne * operandOne).ToString(); 
        }

        private void btnSroot_Click(object sender, EventArgs e)
        {
            lblExp.Visible = true;
            inputOne = lblResult.Text;
            operandOne = Convert.ToDouble(inputOne);
            lblExp.Text = "√(" + operandOne + ")";
            lblResult.Text = (operandOne * 0.5).ToString();

        }

        Double num;
        private void btnneg_Click(object sender, EventArgs e)
        {
            lblExp.Visible = true;
            num =Convert.ToDouble(lblResult.Text);
            num = num * (-1);
            lblResult.Text = num.ToString();
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            lblExp.Visible = true;
            inputOne = lblResult.Text;
            operandOne = Convert.ToDouble(inputOne);
            lblExp.Text = "1/" + operandOne;
            lblResult.Text = (1/operandOne).ToString();
        }
        Int16 strlen;
        private void btnErase_Click(object sender, EventArgs e)
        {
            inputOne = lblResult.Text;
            lblResult.Text = inputOne.Remove(inputOne.Length - 1, 1);
        }

        private void performCalculation()
        {
            switch (temp)
            {
                case "+":
                    operandOne = operandOne + operandTwo;
                    lblExp.Text = operandOne.ToString() + opr;
                    lblResult.Text = operandOne.ToString();
                    temp = opr;
                    inputTwo = null;
                    break;
                case "-":
                    if (Math.Sign(operandOne) == -1)
                    {
                        operandOne = (operandOne*-1) + operandTwo;
                        operandOne = -operandOne;
                    }
                    else
                    {
                        operandOne = operandOne - operandTwo;
                    }
                    lblExp.Text = operandOne.ToString() + opr;
                    lblResult.Text = operandOne.ToString();
                   temp = opr;
                    inputTwo = null; 
                    break;
                case "X":
                    operandOne = operandOne * operandTwo;
                    lblExp.Text = operandOne.ToString() + opr;
                    lblResult.Text = operandOne.ToString();
                    temp = opr;
                    inputTwo = null;
                    break;
                case "/":
                    operandOne = operandOne / operandTwo;
                    lblExp.Text = operandOne.ToString() + opr;
                    lblResult.Text = operandOne.ToString();
                    temp = opr;
                    inputTwo = null;
                    break;
                default:
                    MessageBox.Show("opr not valid");
                    break;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            opr = btnMinus.Text;
            displayExpression(btnMinus.Text);
            btnMinus.Enabled = false;
            if (!btnPlus.Enabled || !btnMul.Enabled || !btnDivide.Enabled)
            {
                btnPlus.Enabled = btnMul.Enabled = btnDivide.Enabled = true;
            }
            checkInputs(opr);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            displayBtnText(btnDot.Text);
        }

        Boolean flagV = false;
        private void btnEqual_Click(object sender, EventArgs e)
        {
            
            opr = btnEqual.Text;
            //displayExpression(btnEqual.Text);
            if (inputOne == null)
            {
                inputOne = lblResult.Text;
                operandOne = Convert.ToDouble(inputOne);
                temp = opr;
            }
            else if (inputTwo == null)
            {
                inputTwo = lblResult.Text;
                operandTwo = Convert.ToDouble(inputTwo);
            }

            switch (temp)
            {
                case "+":
                    if (!flagV)
                    {
                        lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + opr;
                        operandOne = operandOne + operandTwo;
                        flagV = false;
                    }
                    else
                    {
                        operandOne = Convert.ToDouble(lblResult.Text);
                        lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + opr;
                        operandOne = operandOne + operandTwo;
                    }
                   
                    lblResult.Text = operandOne.ToString();
                    temp = opr;
                    break;
                case "-":
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + opr;

                    if (Math.Sign(operandOne) == -1)
                    {
                        operandOne = (operandOne * -1) + operandTwo;
                        operandOne = -operandOne;
                    }
                    else
                    {
                        operandOne = operandOne - operandTwo;
                    }
                    
                    lblResult.Text = operandOne.ToString();
                    temp = opr;
                    inputTwo = null;
                    break;
            }
        }
    }
}
