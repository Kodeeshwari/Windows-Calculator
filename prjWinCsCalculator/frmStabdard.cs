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
    public partial class frmStabdard : Form
    {
        public frmStabdard()
        {
            InitializeComponent();
        }

        String opr, inputOne, inputTwo, temp, eqFormat;
        Double operandOne, operandTwo, total, memoryValue;
        Boolean eraseFlag = false;
        Boolean memFlag = false;
        Int16 memCount = 0;
        String sqrEq = "sqr", sqrtEq = "\u221A", reciEq = "1/";
        Boolean eqFlag = false;


        private void frmStabdard1_Load(object sender, EventArgs e)
        {
            btnDivide.Text = "\u00f7";
            btnErase.Text = "\u232B";
            btnSquare.Text = "x\u00b2";
            btnSroot.Text = "²\u221Ax";
            btnReciprocal.Text = "\u00b9/x";
            btnMC.Enabled = btnMR.Enabled = false;
            lblExp.Text = "";
            lblExp.Visible = false;
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            memFlag = true;
            btnMC.Enabled = btnMR.Enabled = true;
            btnMC.ForeColor = btnMR.ForeColor = Color.Black;
            memoryValue = Convert.ToDouble(lblResult.Text);
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = false;
            memoryValue = 0;
            lblResult.Text = "0";
            lblExp.Text = "";
            lblExp.Visible = false;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = false;
            lblResult.Text = memoryValue.ToString();
        }

        private void btnMadd_Click(object sender, EventArgs e)
        {
            memFlag = true;
            btnMC.Enabled = btnMR.Enabled = true;
            btnMC.ForeColor = btnMR.ForeColor = Color.Black;
            operandOne = Convert.ToDouble(lblResult.Text);
            memoryValue += operandOne;
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            memFlag = true;
            btnMC.Enabled = btnMR.Enabled = true;
            btnMC.ForeColor = btnMR.ForeColor = Color.Black;
            operandOne = Convert.ToDouble(lblResult.Text);
            memoryValue -= operandOne;
        }


        private void btnCE_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblExp.Text = "";
            lblExp.Visible = false;
            lblResult.Text = "0";
            inputOne = inputTwo = null;
            eraseFlag = memFlag = eqFlag = false;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            displayBtnText(btnOne.Text);
        }

        private void displayBtnText(string btntext)
        {
            eraseFlag = false;

            if (!btnPlus.Enabled || !btnMinus.Enabled || !btnMul.Enabled || !btnDivide.Enabled)
            {
                lblResult.Text = btntext;
            }
            else
            {
                if (memFlag)
                {
                   
                    if (memCount <= 0)
                    {
                        lblResult.Text = "";
                        memCount++;
                    }
                    lblResult.Text = lblResult.Text == "0" && lblResult.Text != null ? btntext : lblResult.Text + btntext;
                }
                else
                {
                    lblResult.Text = lblResult.Text == "0" && lblResult.Text != null ? btntext : lblResult.Text + btntext;
                }

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
            displayExpression(btnPlus.Text);
            btnPlus.Enabled = false;
            if (!btnMinus.Enabled || !btnMul.Enabled || !btnDivide.Enabled)
            {
                btnMinus.Enabled = btnMul.Enabled = btnDivide.Enabled = true;
            }
            checkInputs(btnPlus.Text);
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
            else if (inputTwo == null)
            {
                inputTwo = lblResult.Text;
                operandTwo = Convert.ToDouble(inputTwo);
            }

            if (inputOne != null && inputTwo != null)
            {
                performCalculation(opr);
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
        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            eraseFlag = true;
            getInput();
            lblResult.Text = (1 / operandOne).ToString();
            displayEquation(reciEq);
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            eraseFlag = true;
            getInput();
            lblResult.Text = Math.Round((operandOne * operandOne)).ToString();
            displayEquation(sqrEq);
        }

        private void btnSroot_Click(object sender, EventArgs e)
        {
            eraseFlag = true;
            getInput();
            lblResult.Text = Math.Sqrt(operandOne).ToString();
            displayEquation(sqrtEq);
        }
        private void getInput()
        {
            lblExp.Visible = true;
            inputOne = lblResult.Text;
            operandOne = Convert.ToDouble(inputOne);
        }

        Double num;
        private void btnneg_Click(object sender, EventArgs e)
        {
            lblExp.Visible = true;
            num = Convert.ToDouble(lblResult.Text);
            num = num * (-1);
            lblResult.Text = num.ToString();
        }

        private void displayEquation(string equExp)
        {
            memFlag = true;
            if (!eqFlag)
            {
                eqFormat = equExp + "(" + operandOne + ")";
                eqFlag = true;

            }
            else
            {
                eqFormat = equExp + "(" + eqFormat + ")";
            }
            lblExp.Text = eqFormat;
        }

        
        private void btnPer_Click(object sender, EventArgs e)
        {
            Double calPercentage;
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
                    calPercentage = operandOne * operandTwo / 100;
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "%";
                    operandOne = operandOne + calPercentage;
                    lblResult.Text = operandOne.ToString();
                    break;
                case "-":
                    calPercentage = operandOne * operandTwo / 100;
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "%";
                    operandOne = operandOne - calPercentage;
                    lblResult.Text = operandOne.ToString();
                    break;
                case "X":
                    calPercentage = operandOne * operandTwo / 100;
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "%";
                    lblResult.Text = calPercentage.ToString();
                    break;
                case "\u00f7":
                    calPercentage = operandTwo / 100;
                    lblExp.Text = operandOne.ToString() + temp + calPercentage.ToString() + "%";
                    lblResult.Text = calPercentage.ToString();
                    break;
            }
        

    }

    private void btnErase_Click(object sender, EventArgs e)
    {
        if (!eraseFlag)
        {
            inputOne = lblResult.Text;
           
            lblResult.Text = inputOne.Length <= 1 ? lblResult.Text = "0" : lblResult.Text = inputOne.Remove(inputOne.Length - 1, 1);
        }
    }

    private void performCalculation(String op)
    {
        eraseFlag = true;
        switch (temp)
        {
            case "+":
                operandOne = operandOne + operandTwo;
                lblExp.Text = operandOne.ToString() + op;
                lblResult.Text = operandOne.ToString();
                temp = op;
                inputTwo = null;
                break;

            case "-":

                if (Math.Sign(operandOne) == -1)
                {
                    operandOne = (operandOne * -1) + operandTwo;
                    operandOne = -operandOne;
                }
                else
                {
                    operandOne = operandOne - operandTwo;
                }

                lblExp.Text = operandOne.ToString() + op;
                lblResult.Text = operandOne.ToString();
                temp = op;
                inputTwo = null;

                break;

            case "X":
                operandOne = operandOne * operandTwo;
                lblExp.Text = operandOne.ToString() + op;
                lblResult.Text = operandOne.ToString();
                temp = op;
                inputTwo = null;

                break;

            case "\u00f7":

                operandOne = operandOne / operandTwo;
                lblExp.Text = operandOne.ToString() + op;
                lblResult.Text = operandOne.ToString();
                temp = op;
                inputTwo = null;

                break;

            default:
               
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
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "=";
                    operandOne = operandOne + operandTwo;
                    flagV = false;
                }
                else
                {
                    operandOne = Convert.ToDouble(lblResult.Text);
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "=";
                    operandOne = operandOne + operandTwo;
                }

                lblResult.Text = operandOne.ToString();
                temp = "+";
                break;
            case "-":
                if (!flagV)
                {
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "=";
                    if (Math.Sign(operandOne) == -1)
                    {
                        operandOne = (operandOne * -1) + operandTwo;
                        operandOne = -operandOne;
                    }
                    else
                    {
                        operandOne = operandOne - operandTwo;
                    }
                    flagV = false;
                }
                else
                {
                    operandOne = Convert.ToDouble(lblResult.Text);
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "=";
                    if (Math.Sign(operandOne) == -1)
                    {
                        operandOne = (operandOne * -1) + operandTwo;
                        operandOne = -operandOne;
                    }
                    else
                    {
                        operandOne = operandOne - operandTwo;
                    }
                }

                lblResult.Text = operandOne.ToString();
                temp = "-";
                break;

            case "X":
                if (!flagV)
                {
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "=";
                    operandOne = operandOne * operandTwo;
                    flagV = false;
                }
                else
                {
                    operandOne = Convert.ToDouble(lblResult.Text);
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "=";
                    operandOne = operandOne * operandTwo;
                }

                lblResult.Text = operandOne.ToString();
                temp = "X";
                break;

            case "\u00f7":

                if (!flagV)
                {
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "=";
                    operandOne = operandOne / operandTwo;
                    flagV = false;
                }
                else
                {
                    operandOne = Convert.ToDouble(lblResult.Text);
                    lblExp.Text = operandOne.ToString() + temp + operandTwo.ToString() + "=";
                    operandOne = operandOne / operandTwo;
                }
                lblResult.Text = operandOne.ToString();
                temp = "/";
                break;
        }
    }
}
}
