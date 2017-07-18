using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCore {

public enum ShowMode {
    None,
    FullScreen,
    Window,
    Model,
}

public class ViewBase : Window {
    public UIPanel panel;

    public virtual void Start() {
    }

    protected void OnActive() {
        OnShown();
        BindListeners();
    }

    protected void OnDeactive() {
        RemoveEvents();
        OnHide();
    }

    protected virtual void OnStart() {
    }
    protected virtual void OnDestroy() {
    }
    protected virtual void BindListeners() {
    }
    protected virtual void RemoveEvents() {
    }
}

public interface INetUser {
}

}
