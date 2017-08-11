using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class GameConfig
{
    public static GameServer[] GameServers = new GameServer[]
    {
        new GameServer(){name="峥嵘岁月",host="127.0.0.1",port=11001,},
        new GameServer(){name="峥嵘岁月1",host="127.0.0.1",port=11002,},
        new GameServer(){name="峥嵘岁月2",host="127.0.0.1",port=11003,},
    };
}
