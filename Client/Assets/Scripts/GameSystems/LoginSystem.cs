using AppCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class LoginSystem: SystemBase
{
    public static LoginSystem Instance;

    public bool ret;
    public string user;
    public string passWord;
    public int roleIndex;
    public LOGIN_RETURN_CODE returnCode;

    const string kUserKey = "__user";
    const string kPasswordKey = "__psw";

    public LoginSystem()
    {
        user = PlayerPrefs.GetString(kUserKey, string.Empty);
        passWord = PlayerPrefs.GetString(kPasswordKey, string.Empty);
    }
    public List<int> lateServerIDs = new List<int>();

    private Connection accountConnection_;
    private Connection mGameConnection;

    private string user_;
    private string password_;
    private int accountID_;

    public void LoginPlant(string host,int port,string user, string psw)
    {
        user_ = user;
        password_ = psw;
        accountConnection_ = new Connection();
        accountConnection_.host = host;
        accountConnection_.port = port;
        accountConnection_.onConnectFailed = onConnectAccountFailed;
        accountConnection_.onConnectSucessed = onConnectAccountSucess;
        Nets.Instance.connect(accountConnection_);

        PlayerPrefs.SetString(kUserKey, user);
        PlayerPrefs.SetString(kPasswordKey, psw);
    }

    void onConnectAccountSucess()
    {
        Cmd.ReqAccountOperation req = new Cmd.ReqAccountOperation();
        req.action = Cmd.AccountAction.AccountAction_Login;
        req.user = user_;
        req.password = password_;
        Nets.send(Cmd.CLIENT_COMMAND.RQAccountOperation, req);
    }

    void onConnectAccountFailed(SocketError error)
    {
        Debug.LogWarning("onConnectAccountFailed:" + error.ToString());
    }

    public override void BindListeners()
    {
        Commands.Instance.Bind(Cmd.SERVER_COMMAND.RTAccountOperation, OnPackage);
    }

    void OnPackage(object pb)
    {
        Cmd.RetAccountOperation ret = ParseCmd<Cmd.RetAccountOperation>(pb);
        this.accountID_ = ret.accountid;
        this.lateServerIDs = ret.late_serverids;

        Debug.Log("RetAccountOperation:" + ret.accountid.ToString());
        UIController.Instance.Show<LoginSelectServer>();
    }
}
