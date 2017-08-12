﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class GameConfig
{
    public static GameServer[] GameServers = new GameServer[]
    {
        new GameServer(){name="峥嵘岁月",host="127.0.0.1",port=11001,serverID=1},
        new GameServer(){name="峥嵘岁月1",host="127.0.0.1",port=11002,serverID=2},
        new GameServer(){name="峥嵘岁月2",host="127.0.0.1",port=11003,serverID=3},

    };

    public static GameServer GetServer(int serverID)
    {
        return Array.Find<GameServer>(GameServers, (server) => server.serverID == serverID);
    }
}
