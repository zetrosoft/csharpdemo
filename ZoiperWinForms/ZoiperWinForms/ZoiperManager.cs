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
                return cliString_pPeer + " (" + cliString_pPeerNumber + ")";
            }
        }


        public class VoIPUser
        {
            public VoIPUser()
            {
                ActiveCalls = new List<VoIPCall>();
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
                return VoIPProvider.CallCreate(UserId, callee, ref callId) == 0;
            }

            public List<VoIPCall> ActiveCalls
            {
                get;
                set;
            }
        }

        public Dictionary<uint, VoIPUser> ActiveUsers = new Dictionary<uint, VoIPUser>();

        public bool Initialize()
        {
            zoiper = CliWrapper.CliWrapper.GetWrapperInstance();
            Random rand = new Random(DateTime.Now.Millisecond);
            var result = zoiper.InitializeWrapperContext((ushort)rand.Next(30000, 60000), (ushort)rand.Next(30000, 60000), (ushort)rand.Next(30000, 60000));

            if (result == 0)
            {
                zoiper.OnUserRegistered += Zoiper_OnUserRegistered;
                zoiper.OnUserRegistrationFailure += Zoiper_OnUserRegistrationFailure;
                zoiper.OnCallCreated += Zoiper_OnCallCreated;

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

        private void Zoiper_OnCallCreated(uint UserId, uint CallId, string cliString_pPeer, string cliString_pPeerNumber, string cliString_pPeerURI, string cliString_pDNID, int autoAnswerSeconds)
        {
            ActiveUsers[UserId].ActiveCalls.Add(new VoIPCall
            {
                CallId = CallId,
                cliString_pPeer = cliString_pPeer,
                cliString_pPeerNumber = cliString_pPeerNumber,
                cliString_pPeerURI = cliString_pPeerURI,
                cliString_pDNID = cliString_pDNID,
                autoAnswerSeconds = autoAnswerSeconds
            });

            if (OnZoiperEvent != null)
                OnZoiperEvent(ActiveUsers[UserId].UserName + " OnCallCreated cliString_pPeer: " + cliString_pPeer + " cliString_pPeerNumber:" + cliString_pPeerNumber + " cliString_pPeerURI:" + cliString_pPeerURI + " cliString_pDNID:" + cliString_pDNID + " autoAnswerSeconds:" + autoAnswerSeconds);
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
