using AppCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class LoginSystem: SystemBase {
    public static LoginSystem Instance;

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

    Connection mAccountConnection;
    Connection mGameConnection;
    string mUser;
    string mPassword;

    public void LoginPlant(string host,int port,string user, string psw) {
        mUser = user;
        mPassword = psw;
        mAccountConnection = new Connection();
        mAccountConnection.host = host;
        mAccountConnection.port = port;
        mAccountConnection.onConnectFailed = onConnectAccountFailed;
        mAccountConnection.onConnectSucessed = onConnectAccountSucess;
        Nets.Instance.connect(mAccountConnection);

        PlayerPrefs.SetString(kUserKey, user);
        PlayerPrefs.SetString(kPasswordKey, psw);
    }

    void onConnectAccountSucess() {
        Cmd.ReqAccountOperation req = new Cmd.ReqAccountOperation();
        req.action = Cmd.AccountAction.AccountAction_Login;
        req.user = mUser;
        req.password = mPassword;
        Nets.send(Cmd.CLIENT_COMMAND.RQAccountOperation, req);
    }

    void onConnectAccountFailed(SocketError error) {
        Debug.LogWarning("onConnectAccountFailed:" + error.ToString());
    }

    public override void BindListeners() {
        Commands.Instance.Bind(Cmd.SERVER_COMMAND.RTAccountOperation, OnPackage);
    }

    void OnPackage(object pb) {
        Cmd.RetAccountOperation oper = ProtoBuf.Serializer.Deserialize<Cmd.RetAccountOperation>((MemoryStream)pb);
        if (onLoginReturn != null)
            onLoginReturn.Invoke();
    }
}
