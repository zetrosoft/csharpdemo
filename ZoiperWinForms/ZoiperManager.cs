using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliWrapper;
using System.Threading;

namespace ZoiperWinForms
{
    public class ZoiperManager
    {
        const uint InvalidHandle = 0xFFFFFFFF;
        uint UserId = InvalidHandle;
        CliWrapper.CliWrapper zoiper = null;

        public class VoIPCall
        {
            public VoIPUser Owner
            {
                get;
                set;
            }

            public VoIPCall(VoIPUser ownerUser)
            {
                Owner = ownerUser;
                Owner.ActiveCalls[CallId] = this;
            }

            public uint CallId
            {
                get;
                set;
            }

            public String cliString_pPeer
            {
                get;
                set;
            }

            public string cliString_pPeerNumber
            {
                get;
                set;
            }

            public string cliString_pPeerURI
            {
                get;
                set;
            }

            public string cliString_pDNID
            {
                get;
                set;
            }

            public int autoAnswerSeconds
            {
                get;
                set;
            }

            public override string ToString()
            {
                StringBuilder callToStr = new StringBuilder();
                callToStr.Append(cliString_pPeer);
                if(!callToStr.Equals(cliString_pPeerNumber))
                    callToStr.Append(" (" + cliString_pPeerNumber + ")");
                callToStr.Append(" on: " + Owner.ToString());

                return callToStr.ToString();
            }

            public void AcceptCall()
            {
                Owner.VoIPProvider.CallAccept(CallId);
            }

            public void RejectCall()
            {
                var result = Owner.VoIPProvider.CallReject(CallId);
            }
        }

        public class VoIPUser
        {
            public VoIPUser()
            {
                ActiveCalls = new Dictionary<uint, VoIPCall>();
            }

            public CliWrapper.CliWrapper VoIPProvider
            {
                get;
                set;
            }

            public String UserName
            {
                get;
                set;
            }

            public UInt32 UserId
            {
                get;
                set;
            }

            public override string ToString()
            {
                return UserName;
            }

            public bool IsRegistered
            {
                get;
                set;
            }

            public bool RegisterUser()
            {
                return VoIPProvider.RegisterUser(UserId) == 0;
            }

            public bool UnregisterUser()
            {
                return VoIPProvider.UnregisterUser(UserId) == 0;
            }

            public bool MakeCall(String callee)
            {
                uint callId = 0;
                if(VoIPProvider.CallCreate(UserId, callee, ref callId) == 0)
                {
                    return true;
                }

                return false;
            }

            public Dictionary<uint, VoIPCall> ActiveCalls
            {
                get;
                set;
            }
        }

        public Dictionary<uint, VoIPCall> AllActiveCalls = new Dictionary<uint, VoIPCall>();
        public Dictionary<uint, VoIPUser> ActiveUsers = new Dictionary<uint, VoIPUser>();

        public bool Initialize(String certUserName, String certPassword)
        {
            zoiper = CliWrapper.CliWrapper.GetWrapperInstance();
            Random rand = new Random(DateTime.Now.Millisecond);
            var result = zoiper.InitializeWrapperContext((ushort)rand.Next(30000, 60000), (ushort)rand.Next(30000, 60000), (ushort)rand.Next(30000, 60000));

            if (result == 0)
            {
                zoiper.OnUserRegistered += Zoiper_OnUserRegistered;
                zoiper.OnUserRegistrationFailure += Zoiper_OnUserRegistrationFailure;
                zoiper.OnCallCreate += Zoiper_OnCallCreate;
                zoiper.OnCallCreated += Zoiper_OnCallCreated;
                zoiper.OnCallAccepted += Zoiper_OnCallAccepted;
                zoiper.OnCallRejected += Zoiper_OnCallRejected;
                zoiper.OnActivationCompleted += Zoiper_OnActivationCompleted;

                result = zoiper.StartActivationSDK(null, certUserName, certPassword, null);

                Thread eventPoller = new Thread(new ThreadStart(
                    () =>
                    {
                        while (true)
                        {
                            zoiper.PollEvents();
                            Thread.Sleep(300);
                        }
                    }
                    ));
                eventPoller.Start();
            }

            return result == 0;
        }

        private void Zoiper_OnActivationCompleted(CliWrapper.CliWrapper.Cli_eActivationStatus cli_status, string cliString_reason, string cliString_certificate, string cliString_build, string cliString_hddSerial, string cliString_mac, string cliString_checksum)
        {
            if (OnZoiperEvent != null)
                OnZoiperEvent("OnActivationCompleted Status: " + cli_status + " Certificate:" + cliString_certificate);
        }

        private void Zoiper_OnCallAccepted(uint CallId, CliWrapper.CliWrapper.Cli_CodecEnum cli_codec, CliWrapper.CliWrapper.Cli_eCallDirection cli_dir)
        {
            if (OnZoiperEvent != null)
                OnZoiperEvent("OnCallAccepted CallId: " + CallId + " cli_codec:" + cli_codec + " cli_dir:" + cli_dir);
        }

        private void Zoiper_OnCallCreate(uint UserId, uint CallId, string cliString_pPeer)
        {
            if (!AllActiveCalls.Keys.Contains(CallId))
                AllActiveCalls[CallId] = new VoIPCall(ActiveUsers[UserId]);

            AllActiveCalls[CallId].cliString_pPeer = cliString_pPeer;


            if (OnZoiperEvent != null)
                OnZoiperEvent("OnCallCreate CallId: " + CallId + " cliString_pPeer:" + cliString_pPeer);

            if (OnOutgoingCall != null)
                OnOutgoingCall(ActiveUsers[UserId].ActiveCalls[CallId]);
        }

        private void Zoiper_OnCallCreated(uint UserId, uint CallId, string cliString_pPeer, string cliString_pPeerNumber, string cliString_pPeerURI, string cliString_pDNID, int autoAnswerSeconds)
        {
            if (!AllActiveCalls.Keys.Contains(CallId))
                AllActiveCalls[CallId] = new VoIPCall(ActiveUsers[UserId]);

            var voipCall = AllActiveCalls[CallId];
            voipCall.cliString_pPeer = cliString_pPeer;
            voipCall.cliString_pPeerNumber = cliString_pPeerNumber;
            voipCall.cliString_pPeerURI = cliString_pPeerURI;
            voipCall.cliString_pDNID = cliString_pDNID;
            voipCall.autoAnswerSeconds = autoAnswerSeconds;

            

            if (OnZoiperEvent != null)
                OnZoiperEvent(voipCall.Owner.UserName + " OnCallCreated cliString_pPeer: " + cliString_pPeer + " cliString_pPeerNumber:" + cliString_pPeerNumber + " cliString_pPeerURI:" + cliString_pPeerURI + " cliString_pDNID:" + cliString_pDNID + " autoAnswerSeconds:" + autoAnswerSeconds);

            if (OnIncomingCall != null)
                OnIncomingCall(voipCall);
        }

        private void Zoiper_OnCallRejected(uint CallId, int causeCode)
        {
            if (!AllActiveCalls.Keys.Contains(CallId))
            {
                var voipCall = AllActiveCalls[CallId];
                AllActiveCalls.Remove(CallId);
                voipCall.Owner.ActiveCalls.Remove(CallId);
            }

            if (OnZoiperEvent != null)
                OnZoiperEvent("OnCallRejected CallId: " + CallId + " causeCode:");
        }

        public bool AddUser(Int32 transportType, String username, String password, String server)
        {
            UserId = zoiper.AddUser(0, username, password, server, server, username, null);
            if (UserId != InvalidHandle)
            {
                ActiveUsers[UserId] = new VoIPUser
                {
                    VoIPProvider = zoiper,
                    UserName = username,
                    UserId = UserId
                };
                zoiper.SetUserTransport(UserId, (CliWrapper.CliWrapper.Cli_eUserTransport)transportType);
                zoiper.AddUserCodec(UserId, CliWrapper.CliWrapper.Cli_CodecEnum.CODEC_PCMU);
                zoiper.AddUserCodec(UserId, CliWrapper.CliWrapper.Cli_CodecEnum.CODEC_OPUS_FULL);
                return true;
            }
            return false;
        }

        public delegate void ZoiperEvent(String eventText);
        public ZoiperEvent OnZoiperEvent;

        public delegate void PendingCall(VoIPCall call);
        public PendingCall OnIncomingCall;
        public PendingCall OnOutgoingCall;

        private void Zoiper_OnUserRegistrationFailure(uint userId, int isRegister, int causeCode)
        {
            ActiveUsers[userId].IsRegistered = isRegister != 0;
            if (OnZoiperEvent != null)
                OnZoiperEvent(ActiveUsers[userId].UserName + " OnUserRegistrationFailure causeCode: " + causeCode);
        }

        private void Zoiper_OnUserRegistered(uint userId, string cliString_pAor, int newMsg, int oldMsg)
        {
            ActiveUsers[userId].IsRegistered = true;
            if (OnZoiperEvent != null)
                OnZoiperEvent(ActiveUsers[userId].UserName + " OnUserRegistered cliString_pAor: " + cliString_pAor);
        }
    }
}
