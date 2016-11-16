using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRODUCTS_MANAGEMENT.PL
{
    public partial class FRM_LOGIN : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGIN(textID.Text, textPWD.Text);
            if (Dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Is success !");
            }else
            {
                MessageBox.Show("Login Is Faild !");

            }
        }
    }
}
