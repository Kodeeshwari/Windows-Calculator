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

        Boolean lblFlag = false;
        Single num,total=0;
        Boolean equalFlag = false;
        String opr;

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
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnOne.Text : lblResult.Text + btnOne.Text;
                
            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnOne.Text;
            }
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {

            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnTwo.Text : lblResult.Text + btnTwo.Text;
                
            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnTwo.Text;
            }
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnThree.Text : lblResult.Text + btnThree.Text;
            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnThree.Text;
            }
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            if(!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnFour.Text : lblResult.Text + btnFour.Text;

            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnFour.Text;
            }

        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnFive.Text : lblResult.Text + btnFive.Text;
            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnFive.Text;
            }
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnSix.Text : lblResult.Text + btnSix.Text;

            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnSix.Text;
            }
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnSeven.Text : lblResult.Text + btnSeven.Text;

            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnSeven.Text;
            }
        }

        private void btneight_Click(object sender, EventArgs e)
        {
            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btneight.Text : lblResult.Text + btneight.Text;

            }
            else
            {
                lblFlag = false;
                lblResult.Text = btneight.Text;
            }
        }

        private void btnnine_Click(object sender, EventArgs e)
        {
            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnnine.Text : lblResult.Text + btnnine.Text;

            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnnine.Text;
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            if (!lblFlag)
            {
                lblResult.Text = lblResult.Text == "0" && lblExp.Text != null ? btnZero.Text : lblResult.Text + btnZero.Text;

            }
            else
            {
                lblFlag = false;
                lblResult.Text = btnZero.Text;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            opr = btnPlus.Text;
            lblExp.Visible = true;
            
            if (!lblFlag)
            {
                lblExp.Text += lblResult.Text + " " + opr;
                num = Convert.ToSingle(lblResult.Text);
                total += num;
                lblExp.Text = total + opr;
                lblResult.Text = total.ToString();
                lblFlag = true;  
            }
            else
            {
                lblExp.Text = lblResult.Text + " " + opr;
                
            }
        }
        Int16 count = 0;
        private void btnMinus_Click(object sender, EventArgs e)
        {
            
            opr = btnMinus.Text;
            lblExp.Visible = true;
            MessageBox.Show(lblFlag.ToString());
            if (!lblFlag)
            {
                lblExp.Text += lblResult.Text + " " + opr;
                MessageBox.Show(lblExp.Text);
                num = Convert.ToSingle(lblResult.Text);
                
                total = total - num;
                Decimal minus = Convert.ToDecimal(total);

                if (count < 1)
                {
                    minus = Decimal.Negate(minus);
                    total = Convert.ToSingle(minus);
                    count++;
                }

                lblExp.Text = total + opr;

                lblResult.Text = total.ToString();
                lblFlag = true;
            }
            else
            {
                lblExp.Text = lblResult.Text + " " + opr;
            }
              
        }

        private void btnDot_Click(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            
            if (!equalFlag)
            {
                
                num = Convert.ToSingle(lblResult.Text);
                
                switch (opr)
                {
                    case "+":
                        lblExp.Text += lblResult.Text + " " + btnEqual.Text;
                        total += num;
                        lblResult.Text = total.ToString();
                        equalFlag = true;
                        lblFlag = true;
                        break;
                    case "-":
                        lblExp.Text += lblResult.Text + " " + btnEqual.Text;
                        total -= num;
                        lblResult.Text = total.ToString();
                        equalFlag = true;
                        break;
                    default: MessageBox.Show("error");
                        break;
                }
            }
            else{
                switch (opr)
                {
                    case "+":
                        lblExp.Text = total +" "+ opr+" " + num;
                        total += num;
                        lblResult.Text = total.ToString();
                        lblFlag = true;
                        break;
                    case "-":
                        lblExp.Text = total + " " + opr + " " + num;
                        total -= num;
                        lblResult.Text = total.ToString();
                        equalFlag = true;
                        break;
                    default:
                        MessageBox.Show("error");
                        break;
                }
            }
            
        }
    }
}
