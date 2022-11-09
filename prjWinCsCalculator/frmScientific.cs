using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsCalculator
{
    public partial class frmScientific : Form
    {
        public frmScientific()
        {
            InitializeComponent();
        }

        String opr, inputOne, inputTwo, temp, eqFormat;
        Double operandOne, operandTwo, total, memoryValue,num;
        Boolean eraseFlag = false;
        Boolean memFlag = false;
        Int16 memCount = 0;
        String sqrEq = "sqr", sqrtEq = "\u221A", reciEq = "1/",cubeEq="cube";
        Boolean eqFlag = false;


        private void btnOne_Click(object sender, EventArgs e)
        {
            displayBtnText(btnOne.Text);
        }

        private void frmScientific_Load(object sender, EventArgs e)
        {
            btnDiv.Text = "\u00f7";
            btnErase.Text = "\u232B";
            btnSqr.Text = "x\u00b2";
            btnSqrt.Text = "²\u221Ax";
            btnReci.Text = "\u00b9/x";
            btnPie.Text = "\u03c0";
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

        private void btnMminus_Click(object sender, EventArgs e)
        {
            memFlag = true;
            btnMC.Enabled = btnMR.Enabled = true;
            btnMC.ForeColor = btnMR.ForeColor = Color.Black;
            operandOne = Convert.ToDouble(lblResult.Text);
            memoryValue -= operandOne;
        }

        private void btnMadd_Click(object sender, EventArgs e)
        {
            memFlag = true;
            btnMC.Enabled = btnMR.Enabled = true;
            btnMC.ForeColor = btnMR.ForeColor = Color.Black;
            operandOne = Convert.ToDouble(lblResult.Text);
            memoryValue += operandOne;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = false;
            lblResult.Text = memoryValue.ToString();
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = false;
            memoryValue = 0;
            lblResult.Text = "0";
            lblExp.Text = "";
            lblExp.Visible = false;
        }
        
        private void btnCE_Click(object sender, EventArgs e)
        {
            if (btnCE.Text=="CE")
            {
                lblResult.Text = "0";
                btnCE.Text = "C";
            }
            else
            {
                lblExp.Text = "";
                lblExp.Visible = false;
                lblResult.Text = "0";
                inputOne = inputTwo = null;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            displayExpression(btnPlus.Text);
            btnPlus.Enabled = false;
            if (!btnMinus.Enabled || !btnMul.Enabled || !btnDiv.Enabled)
            {
                btnMinus.Enabled = btnMul.Enabled = btnDiv.Enabled = true;
            }
            checkInputs(btnPlus.Text);
        }
        private void displayExpression(String exp)
        {
            lblExp.Visible = true;
            lblExp.Text += lblResult.Text + exp;
        }
        Double basev = 1;
        private void checkInputs(String opr)
        {

            if (inputOne == null)
            {
                
                inputOne = lblResult.Text;
                operandOne = Convert.ToDouble(inputOne);
                temp = opr;
                if (opr == "exp")
                {
                    lblExp.Text = inputOne + ".e+0";
                }
            }
            else if (inputTwo == null)
            {
                inputTwo = lblResult.Text;
                operandTwo = Convert.ToDouble(inputTwo);
                if (opr == "exp")
                {
                    for (Int16 i = 0; i < operandTwo; i++)
                    {
                        basev *= 10 ;
                    }
                    operandTwo = basev;
                }
            }

            if (inputOne != null && inputTwo != null)
            {
                performCalculation(opr);
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
                case "mod":
                    operandOne = operandOne % operandTwo;
                    lblExp.Text = operandOne.ToString() + op;
                    lblResult.Text = operandOne.ToString();
                    temp = op;
                    inputTwo = null;
                    break;
                case "exp":
                    operandOne = operandOne*operandTwo;
                    lblExp.Text = inputOne + ".e+"+inputTwo;
                    lblResult.Text = operandOne.ToString();
                    break;
                case "xy":
                    Double basev=1;
                    for (Int16 i = 0; i < operandTwo; i++)
                    {
                        basev *= operandOne;
                    }
                    lblExp.Text = basev.ToString() + "";
                    lblResult.Text = basev.ToString();
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
            if (!btnPlus.Enabled || !btnMul.Enabled || !btnDiv.Enabled)
            {
                btnPlus.Enabled = btnMul.Enabled = btnDiv.Enabled = true;
            }
            checkInputs(opr);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            displayBtnText(btnDot.Text);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            opr = btnMul.Text;
            displayExpression(btnMul.Text);
            btnMul.Enabled = false;
            if (!btnMinus.Enabled || !btnPlus.Enabled || !btnDiv.Enabled)
            {
                btnMinus.Enabled = btnPlus.Enabled = btnDiv.Enabled = true;
            }
            checkInputs(opr);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            opr = btnDiv.Text;
            displayExpression(btnDiv.Text);
            btnDiv.Enabled = false;
            if (!btnMinus.Enabled || !btnPlus.Enabled || !btnMul.Enabled)
            {
                btnMinus.Enabled = btnPlus.Enabled = btnMul.Enabled = true;
            }
            checkInputs(opr);
        }

        private void btnSqr_Click(object sender, EventArgs e)
        {
            if (btnSqr.Text == "x\u00b3")
            {
                eraseFlag = true;
                getInput();
                lblResult.Text = Math.Round((operandOne * operandOne * operandOne)).ToString();
                displayEquation(cubeEq);
            }
            else
            {
                eraseFlag = true;
                getInput();
                lblResult.Text = Math.Round((operandOne * operandOne)).ToString();
                displayEquation(sqrEq);
            }
            
        }
        private void getInput()
        {
            lblExp.Visible = true;
            inputOne = lblResult.Text;
            operandOne = Convert.ToDouble(inputOne);
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

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            eraseFlag = true;
            getInput();
            lblResult.Text = Math.Sqrt(operandOne).ToString();
            displayEquation(sqrtEq);
        }

        private void btnReci_Click(object sender, EventArgs e)
        {
            eraseFlag = true;
            getInput();
            lblResult.Text = (1 / operandOne).ToString();
            displayEquation(reciEq);
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            if (!eraseFlag)
            {
                inputOne = lblResult.Text;
                lblResult.Text = inputOne.Length <= 1 ? lblResult.Text = "0" : lblResult.Text = inputOne.Remove(inputOne.Length - 1, 1);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            opr = btnMod.Text;
            displayExpression(btnMod.Text);
            btnMod.Enabled = false;
            checkInputs(opr);
        }

        private void btnexp_Click(object sender, EventArgs e)
        {
            opr = btnexp.Text;
            displayExpression(btnexp.Text);
            btnexp.Enabled = false;
            checkInputs(opr);

        }

        private void btnAbs_Click(object sender, EventArgs e)
        {
            lblExp.Visible = true;
            num = Convert.ToDouble(lblResult.Text);
            lblExp.Text = "abs( " + num + " )";
            num = num * (-1);
            lblResult.Text = num.ToString();
        }

        private void btnPie_Click(object sender, EventArgs e)
        {
            Double pie = 3.1415926535897932384626433832795;
            operandTwo = pie;
            lblResult.Text = pie.ToString();
        }

        private void btnxy_Click(object sender, EventArgs e)
        {
            opr = btnxy.Text;
            displayExpression(btnxy.Text);
            btnxy.Enabled = false;
            checkInputs(opr);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            lblExp.Visible = true;
            lblExp.Text = "log( " + lblResult.Text +" )";
            lblResult.Text = (Math.Log(Convert.ToDouble(lblResult.Text))).ToString();
        }

        private void btnTenx_Click(object sender, EventArgs e)
        {
            if(btnTenx.Text == "2 \u02e3")
            {
                lblExp.Visible = true;
                lblExp.Text = "2 ^ " + lblResult.Text;
                lblResult.Text = (Math.Pow(2, (Convert.ToDouble(lblResult.Text)))).ToString();
            }
            else
            {
                lblExp.Visible = true;
                lblExp.Text = "10 ^ " + lblResult.Text;
                lblResult.Text = (Math.Pow(10, (Convert.ToDouble(lblResult.Text)))).ToString();
            }
            
        }

        private void btnScnd_Click(object sender, EventArgs e)
        {
            btnScnd.ForeColor = Color.White;
            btnScnd.BackColor = Color.Maroon;
            btnSqr.Text = "x\u00b3";
            btnSqrt.Text = "\u221bx";
            btnxy.Text = "y \u221a x";
            btnTenx.Text = "2 \u02e3";
            btnLog.Text = "log \u2093 x";
            btnIn.Text = "e \u02e3";
            //if(btnSqrt.Text == "\u221bx") { btnSqrt.Enabled = false; }
            //if (btnxy.Text == "y \u221a x") { btnxy.Enabled = false; }
            //if (btnLog.Text == "log \u2093 x") { btnLog.Enabled = false; }
        }
        Boolean flagV = false;
        private void btnEqual_Click(object sender, EventArgs e)
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

                case "/":

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

        private void btnNegate_Click(object sender, EventArgs e)
        {
            lblExp.Visible = true;
            num = Convert.ToDouble(lblResult.Text);
            num = num * (-1);
            lblResult.Text = num.ToString();
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

        private void btnEight_Click(object sender, EventArgs e)
        {
            displayBtnText(btnEight.Text);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            displayBtnText(btnNine.Text);
        }
        private void displayBtnText(string btntext)
        {
            btnCE.Text = "CE";
            eraseFlag = false;
            if (!btnPlus.Enabled || !btnMinus.Enabled || !btnMul.Enabled || !btnDiv.Enabled || !btnMod.Enabled ||!btnexp.Enabled||!btnxy.Enabled)
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
            btnPlus.Enabled = btnMinus.Enabled = btnMul.Enabled = btnDiv.Enabled = btnMod.Enabled = btnexp.Enabled  = btnxy.Enabled= true;
        }
    }
}
