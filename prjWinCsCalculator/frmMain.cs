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
    }
}
