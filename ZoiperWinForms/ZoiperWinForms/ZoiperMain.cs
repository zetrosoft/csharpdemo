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
        ZoiperManager.PendingCall incCall = null;
        ZoiperManager.PendingCall outCall = null;

        public ZoiperMain()
        {
            InitializeComponent();

            cbTransportType.SelectedIndex = 0;

            eventLog = new ZoiperManager.ZoiperEvent(LogZoiperEvent);
            incCall = new ZoiperManager.PendingCall(IncomingCall);
            outCall = new ZoiperManager.PendingCall(OutgoingCall);

            voip.OnZoiperEvent += eventLog;
            voip.OnIncomingCall += incCall;
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

        private void IncomingCall(ZoiperManager.VoIPCall call)
        {
            if (rtbRunLog.InvokeRequired)
                BeginInvoke(incCall, call);
            else
            {
                ActiveCallsListRefresh();

                if (MessageBox.Show(call.cliString_pPeer + " (" + call.cliString_pPeerNumber + ")", "Incoming call", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    call.AcceptCall();
                else
                    call.RejectCall();
            }
        }

        private void OutgoingCall(ZoiperManager.VoIPCall call)
        {
            if (rtbRunLog.InvokeRequired)
                BeginInvoke(outCall, call);
            else
                ActiveCallsListRefresh();
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
            grpBAccountState.Enabled = (voipUser != null);
            if (grpBAccountState.Enabled)
            {
                tbIsRegistered.Text = voipUser.IsRegistered.ToString();
            }
            else
            {
                tbIsRegistered.Text = "";
            }
        }

        private void ActiveCallsListRefresh()
        {
            lbActiveCalls.Items.Clear();
            grpBActiveCalls.Enabled = (voip.AllActiveCalls.Count > 0);
            if(grpBActiveCalls.Enabled)
            {
                foreach (var call in voip.AllActiveCalls.Values)
                    lbActiveCalls.Items.Add(call);
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

        private void btnCloseCall_Click(object sender, EventArgs e)
        {
            if(lbActiveCalls.SelectedItem != null)
            {
                var call = lbActiveCalls.SelectedItem as ZoiperManager.VoIPCall;
                call.RejectCall();
            }
        }
    }
}
