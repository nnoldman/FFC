using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SystemBase {
    protected bool timeConsuming = false;

    public SystemBase() {
        mSystems.Add(this);
    }

    public static List<SystemBase> mSystems = new List<SystemBase>();

    public static IEnumerator CloseGameSystems() {
        foreach (var system in mSystems) {
            system.CloseGameStage();
        }
        mSystems.Clear();
        yield return null;
    }

    public virtual IEnumerator Initialize() {
        yield return null;
    }

    public virtual void BindListeners() {

    }
    public virtual void CloseGameStage() {
    }
}
