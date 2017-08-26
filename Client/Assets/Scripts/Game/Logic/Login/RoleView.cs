using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RoleView:View
{
    Login.RolePanel window
    {
        get
        {
            return (Login.RolePanel)this.panel.ui;
        }
    }

    public RoleView()
    {
        Login.LoginBinder.BindAll();
    }

    protected override void OnInit()
    {
        this.window.enterGame.onClick.Add(OnCommand);
    }

    void OnCommand(EventContext context)
    {
        if(context.sender==this.window.enterGame)
        {
            if(LoginSystem.Instance.HasRole())
                Nets.Send(Cmd.CLIENTID.RQEnterGame);
            else
            {
                var cmd = new Cmd.ReqCreateRole();
                cmd.name = this.window.name.text;
                cmd.sex = 0;
                cmd.job = 1;
                Nets.Send(Cmd.CLIENTID.RQEnterGame,cmd);
            }
        }
    }

    protected override void OnShowMe()
    {
        if (LoginSystem.Instance.HasRole())
            SetForEnterGame();
        else
            SetForCreateRole();
    }

    void SetForEnterGame()
    {
        this.window.enterGame.title = "进入游戏";

    }

    void SetForCreateRole()
    {
        this.window.enterGame.title = "创建角色";
    }
}
