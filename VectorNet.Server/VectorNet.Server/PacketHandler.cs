﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lynxy.Network;

namespace VectorNet.Server
{
    public partial class Server
    {
        protected void HandlePacket(User user, PacketReader reader)
        {
            string username;
            string text;
            string client;
            try
            {
                byte packetId = reader.ReadByte();
                if (!user.IsOnline && packetId != VNET_LOGON)
                {
                    SendServerError(user, "You must logon first.");
                    DisconnectUser(user);
                }

                switch (packetId)
                {

                    case VNET_LOGON: //0x01
                        username = reader.ReadStringNT();
                        string password = reader.ReadStringNT();
                        client = reader.ReadStringNT();
                        byte queueSharing = reader.ReadByte();

                        //check client name
                        

                        //check username+pass combo
                        AccountState state = GetAccountState(username, password);
                        if (state == AccountState.InvalidPassword)
                        {
                            SendLogonResult(user, LogonResult.InvalidPassword);
                            return;
                        }
                        if (state == AccountState.NewAccount)
                            CreateNewAccount(username, password, user.IPAddress);

                        //remember challenge


                        if (GetUserByName(username) != null)
                        {
                            SendLogonResult(user, LogonResult.AccountInUse);
                            return;
                        }

                        user.Username = username;
                        user.Client = client;
                        user.IsOnline = true;

                        UpdateLastLogin(username);
                        SendLogonResult(user, LogonResult.Success);
                        if (state == AccountState.NewAccount)
                            SendServerInfo(user, "New account created!");
                        JoinUserToChannel(user, Channel_Main);

                        break;

                    case VNET_SERVERCHALLENGE: //0x02
                        break;

                    case VNET_CHATEVENT: //0x03
                        text = reader.ReadStringNT();
                        if (text[0] == '/')
                            HandleCommand(user, text.Substring(1));
                        else
                        {
                            ConsoleSendUserTalk(user, text); 
                            SendUserTalk(user, text);
                        }
                        break;

                    case 0x04:
                        break;
                    case 0x05:
                        break;
                    case 0x06:
                        break;
                    case 0x07:
                        break;
                    case 0x08:
                        break;
                    case 0x09:
                        break;
                    case 0x0A:
                        break;
                    case 0x0B:
                        break;
                    case 0x0C:
                        break;
                }
            }
            catch (Exception ex)
            {
                //TODO: log exception
            }
        }

        

    }
}
