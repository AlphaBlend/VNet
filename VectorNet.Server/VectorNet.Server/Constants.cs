﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lynxy.Network;

namespace VectorNet.Server
{
    public partial class Server
    {
        protected const int VNET_LOGON          = 0x01;
        protected const int VNET_CHATEVENT      = 0x02;
        protected const int VNET_TICTACTOE      = 0x03;
        protected const int VNET_CHANNELLIST    = 0x04;
        protected const int VNET_FEATUREQUERY   = 0x05;
        protected const int VNET_KEEPALIVE      = 0x06;
        protected const int VNET_CHANNELJOIN    = 0x07;
        protected const int VNET_QUEUESHARE     = 0x09;
        protected const int VNET_SERVERCHALLENGE = 0x0A;
        protected const int VNET_VNETPAD        = 0x0B;

        protected static class LogonResult
        {
            public const int SUCCESS            = 0x00;
            public const int INVALID_PASSWORD   = 0x01;
            public const int INVALID_USERNAME   = 0x02;
            public const int ACCOUNT_IN_USE     = 0x03;
            public const int INVALID_PROTOCOL   = 0x04;
        }
    }
}