using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoiperWinForms
{
    public partial class ZoiperMain : Form
    {
        ZoiperManager voip = new ZoiperManager();

        public ZoiperMain()
        {
            InitializeComponent();

            voip.Initialize();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(voip.AddUser(tbUserName.Text, tbPassword.Text, tbServer.Text))
            {
                lbUsers.Items.Clear();
                foreach (var user in voip.ActiveUsers)
                    lbUsers.Items.Add(user);
            }
            else
            {
                MessageBox.Show("Adding user failed", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(lbUsers.SelectedItem != null)
            {
                var voipUser = lbUsers.SelectedItem as ZoiperManager.VoIPUser;
                if(!voip.RegisterUser(voipUser))
                    MessageBox.Show("Registration failed", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
