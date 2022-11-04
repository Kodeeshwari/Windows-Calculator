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
    public partial class frmStandard : Form
    {
        public frmStandard()
        {
            InitializeComponent();
        }

        private void frmStandard_Load(object sender, EventArgs e)
        {
            btnMC.Enabled = btnMR.Enabled = false;
            
        }

       
    }
}
