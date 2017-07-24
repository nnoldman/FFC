using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using FlatBuffers;

public class LoginSystem: GameSystem<LoginSystem> {
    public bool ret;
    public string user;
    public string passWord;
    public int roleIndex;
    public LOGIN_RETURN_CODE returnCode;

    public event GameEventHandler onLoginReturn;

    const string kUserKey = "__user";
    const string kPasswordKey = "__psw";

    public LoginSystem() {
        user = PlayerPrefs.GetString(kUserKey, string.Empty);
        passWord = PlayerPrefs.GetString(kPasswordKey, string.Empty);
    }

    public void Login(string user, string psw) {
        this.user = user;
        this.passWord = psw;
        FlatBufferBuilder builder = new FlatBufferBuilder(1024);
        Command.RqLogin.StartRqLogin(builder);
        Command.RqLogin.AddName(builder, builder.CreateString(user));
        Command.RqLogin.AddPsw(builder, builder.CreateString(psw));
        Command.RqLogin.AddId(builder, 5);
        var offset = Command.RqLogin.EndRqLogin(builder);
        Command.RqLogin.FinishRqLoginBuffer(builder, offset);
        //------------------------------------------------------

        Nets.Send(CSOPCode.RqServerLogin);
        PlayerPrefs.SetString(kUserKey, user);
        PlayerPrefs.SetString(kPasswordKey, psw);
    }

    public override void BindListeners() {
        BindCommand<LoginResult>(CommandID.EnterGame, OnPackage);
    }

    void OnPackage(LoginResult cmd) {
        returnCode = cmd.returnCode;
        roleIndex = cmd.roleIndex;
        if (onLoginReturn != null)
            onLoginReturn.Invoke();
    }
}
