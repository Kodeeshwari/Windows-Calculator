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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void quitProgrammesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close this program ?", "Closing Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripBar.Visible = toolbarToolStripMenuItem.Checked?true:false;
          
        }

        private void statusBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStripbar.Visible = statusBToolStripMenuItem.Checked? true : false;
        }

        private void toolStripBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolCboOption.Items.Add("Any CPU");
            toolCboOption.Items.Add("Configuration Manager");
            toolCboOption.SelectedIndex = 0;  
        }

        private void versionStandardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStabdard fstc = new frmStabdard();
            fstc.Show();
            // to center the formchild inside the MDI
            fstc.Left = (this.Width - fstc.Width) / 2;
            fstc.Top = (this.Height - fstc.Height) / 2;
        }

        private void versionScientificToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmScientific fsci = new frmScientific();
            fsci.Show();
            // to center the formchild inside the MDI
            fsci.Left = (this.Width - fsci.Width) / 2;
            fsci.Top = (this.Height - fsci.Height) / 2;

        }

        private void manualUtiliToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Calculator\r\n\r\nThe windows app provides standard, scientific calculator functionality.\r\n\r\nFeatures\r\n\r\nStandard Calculator functionality which offers basic operations and evaluates commands immediately as they are entered.\r\n\r\nEqual operation perform the repatation of recent operation performed with two operands.\r\n\r\nYou can able to find the square root, square and reciprocal of different numbers repatedly.\r\n\r\nDuring calculation of percentage when you want to calculate the how many percentage for some X amount then press plus button to calculate the final price after the adding percentage to the result.\r\n\r\nYou can also able to find the discount value for some X amount by using minus button like \r\nif you want to calculate the 20% discount on 2000$ then you just need to put the 2000 press minus button and add discount percent like 20% then it shows the discounted final price.\r\n\r\nScientific calculator there is function called 2nd where you can able to find the different additional buttons to calculate cube cuberoot and etc.\r\n\r\nIn both calculator you can able to perform the memory operation by using M+,M-,MS,MC,MR\r\n\r\nMS - is used for storing value in memory.\r\n\r\nMR - is used for recalling the value from memory.\r\n\r\nM+ - is used for adding value to memory value.\r\n\r\nM- - is used for substractiong value with memory value\r\n\r\nMC is used to clear memory.\r\n\r\n");
        }

        private void aideCalc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
