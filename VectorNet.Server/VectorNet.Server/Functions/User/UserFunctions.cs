﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lynxy.Network;

namespace VectorNet.Server
{
    public partial class Server
    {
        //User Functions
        //This class is for methods that deal with a single user, not multiple users
        protected void DisconnectUser(User user)
        {
            RemoveUserFromChannel(user);
            user.IsOnline = false;
            user.Socket.Close();
        }

        protected void JoinUserToChannel(User user, Channel channel)
        {
            RemoveUserFromChannel(user);
            channel.AddUser(user, false);

            SendUserJoinedChannel(user);
            SendJoinedChannelSuccessfully(user);
            SendChannelList(user);
        }

        protected void RemoveUserFromChannel(User user)
        {
            if (user.Channel == null)
                return;
            SendUserLeftChannel(user);
            user.Channel.RemoveUser(user);
        }
    }
}
