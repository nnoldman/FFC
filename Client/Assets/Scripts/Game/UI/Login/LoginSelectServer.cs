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
        for(int i=0; i<5; ++i)
        {
            var item = (Login.ServerItem)window.serverList.AddItemFromPool().asCom;
            item.name_.text = (i + 1).ToString() + "Zone";
        }
    }

    void OnSelectServer(EventContext context)
    {
        var item = (Login.ServerItem)context.data;
        item.name_.text = "selected";
    }
}
