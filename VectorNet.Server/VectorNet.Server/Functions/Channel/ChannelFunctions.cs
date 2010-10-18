﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lynxy.Network;

namespace VectorNet.Server
{
    public partial class Server
    {
        //Channel Functions
        //This class is for methods that deal with a single channel, not multiple channels
        protected Channel MainChannel = new Channel("Main");

        protected List<User> GetUsersInChannel(User userPerspective, string channel, bool excludeUser)
        {
            Channel chan = GetChannelByName(channel);
            if (chan == null)
                return null;
            return GetUsersInChannel(userPerspective, chan, excludeUser);
        }

        protected List<User> GetUsersInChannel(User userPerspective, Channel channel, bool excludeUser)
        {
            //TODO: user perspective
            List<User> ret = channel.Users;
            if (excludeUser && ret.Contains(userPerspective))
                ret.Remove(userPerspective);
            return ret;
        }
    }
}