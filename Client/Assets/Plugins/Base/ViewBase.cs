using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCore
{

public enum ShowMode
{
    None,
    FullScreen,
    Window,
    Model,
}

public class ViewBase : Window
{
    public UIPanel panel;

    protected virtual void BindListeners()
    {
    }

    protected virtual void RemoveEvents()
    {
    }

    protected virtual void OnShowMe()
    {
    }
    protected virtual void OnHideMe()
    {
    }

    override protected void OnHide()
    {
        this.panel.gameObject.SetActive(false);
        this.OnHideMe();
        this.RemoveEvents();
    }

    override protected void OnShown()
    {
        this.panel.gameObject.SetActive(true);
        this.OnShowMe();
        this.BindListeners();
    }
}


public interface INetUser
{
}

}
