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
        ZoiperManager.ZoiperEvent eventLog = null;

        public ZoiperMain()
        {
            InitializeComponent();

            cbTransportType.SelectedIndex = 0;

            eventLog = new ZoiperManager.ZoiperEvent(LogZoiperEvent);

            voip.OnZoiperEvent += eventLog;
        }
        private void LogZoiperEvent(String eventText)
        {
            if (rtbRunLog.InvokeRequired)
                BeginInvoke(eventLog, eventText);
            else
            {
                rtbRunLog.Text += eventText + "\n";
                AccountInfoRefresh(lbUsers.SelectedItem as ZoiperManager.VoIPUser);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(voip.AddUser(cbTransportType.SelectedIndex, tbUserName.Text, tbPassword.Text, tbServer.Text))
            {
                lbUsers.Items.Clear();
                foreach (var user in voip.ActiveUsers.Values)
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
                if(!voipUser.RegisterUser())
                    MessageBox.Show("Registration failed", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnUnregister_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                var voipUser = lbUsers.SelectedItem as ZoiperManager.VoIPUser;
                if (!voipUser.UnregisterUser())
                    MessageBox.Show("Unregistration failed", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnCreateCall_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                var voipUser = lbUsers.SelectedItem as ZoiperManager.VoIPUser;
                if(!voipUser.MakeCall(tbCallee.Text))
                    MessageBox.Show("Call creation failed", "Error", MessageBoxButtons.OK);
            }
        }

        private void AccountInfoRefresh(ZoiperManager.VoIPUser voipUser)
        {
            lbActiveCalls.Items.Clear();
            grpBAccountState.Enabled = (voipUser != null);
            if (grpBAccountState.Enabled)
            {
                tbIsRegistered.Text = voipUser.IsRegistered.ToString();
                foreach(var call in voipUser.ActiveCalls.Values)
                {
                    lbActiveCalls.Items.Add(call);
                }
            }
            else
            {
                tbIsRegistered.Text = "";
            }
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccountInfoRefresh(lbUsers.SelectedItem as ZoiperManager.VoIPUser);
        }

        private void btnCertActivate_Click(object sender, EventArgs e)
        {
            grpBActication.Enabled = false;
            voip.Initialize(tbCertUserName.Text, tbCertPassword.Text);
        }
    }
}
