using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LoginSelectServer : View
{
    Login.SelectServer window
    {
        get
        {
            return (Login.SelectServer)this.panel.ui;
        }
    }

    public LoginSelectServer()
    {
        Login.LoginBinder.BindAll();
    }

    protected override void OnInit()
    {
        window.serverList.RemoveChildrenToPool();
        window.serverList.onClickItem.Add(OnSelectServer);
        window.enterGame.onClick.Add(OnClickEnterGame);
        for (int i = 0; i < GameConfig.GameServers.Length; ++i)
        {
            var server = GameConfig.GameServers[i];
            var item = (Login.ServerItem)window.serverList.AddItemFromPool().asCom;
            item.name_.text = server.name;
            item.data = server;
        }
    }

    void OnClickEnterGame()
    {
    }

    void OnSelectServer(EventContext context)
    {
        var item = (Login.ServerItem)context.data;
        var server = (GameServer)item.data;
        LoginSystem.Instance.currentServerID = server.serverID;
        SetCurrentServer();
    }

    void SetCurrentServer()
    {
        if (LoginSystem.Instance.currentServerID > 0)
        {
            this.window.currentServer.text = string.Format("{0}服", LoginSystem.Instance.currentServerID);
        }
        else
        {
            this.window.currentServer.text = string.Empty;
        }
    }

    protected override void OnShowMe()
    {
        SetCurrentServer();
    }
}
