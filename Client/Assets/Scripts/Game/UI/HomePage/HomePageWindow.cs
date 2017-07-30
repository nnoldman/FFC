using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HomePageWindow: View {
    string host = "127.0.0.1";
    int ip = 15299;
    HomePage.Main window {
        get {
            return (HomePage.Main)this.panel.ui;
        }
    }

    public HomePageWindow() {
        HomePage.HomePageBinder.BindAll();
    }

    protected override void OnInit() {
        window.login.onClick.Add(Login);
    }

    void Login() {
        LoginSystem.Instance.LoginPlant(host,ip,window.user.text, window.psw.text);
    }
}
