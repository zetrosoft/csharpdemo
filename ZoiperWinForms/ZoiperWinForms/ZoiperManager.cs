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

        public class VoIPUser
        {
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
        }

        public List<VoIPUser> ActiveUsers = new List<VoIPUser>();

        public bool Initialize()
        {
            zoiper = CliWrapper.CliWrapper.GetWrapperInstance();
            Random rand = new Random(DateTime.Now.Millisecond);
            var result = zoiper.InitializeWrapperContext((ushort)rand.Next(30000, 60000), (ushort)rand.Next(30000, 60000), (ushort)rand.Next(30000, 60000));

            if (result == 0)
            {
                zoiper.OnUserRegistered += Zoiper_OnUserRegistered;
                zoiper.OnUserRegistrationFailure += Zoiper_OnUserRegistrationFailure;

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
                //eventPoller.Start();
            }

            return result == 0;
        }

        public bool AddUser(String username, String password, String server)
        {
            UserId = zoiper.AddUser(0, username, password, server, server, username, null);
            if (UserId != InvalidHandle)
            {
                ActiveUsers.Add(new VoIPUser
                {
                    UserName = username,
                    UserId = UserId
                });
                return true;
            }
            return false;
        } 

        public bool RegisterUser(VoIPUser user)
        {
            return zoiper.RegisterUser(user.UserId) == 0;
        }

        private void Zoiper_OnUserRegistrationFailure(uint userId, int isRegister, int causeCode)
        {
            throw new NotImplementedException();
        }

        private void Zoiper_OnUserRegistered(uint userId, string cliString_pAor, int newMsg, int oldMsg)
        {
            throw new NotImplementedException();
        }
    }
}
