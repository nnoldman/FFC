using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameSystem<T> : SystemBase, IEventSender where T : SystemBase, new() {
    public static T Instance {
        get {
            if(mInstance == null) {
                mInstance = new T();
                mSystems.Add(mInstance);
            }
            return mInstance;
        }
    }
    public static T mInstance;

    public void Trigger(int id, object data) {
        throw new NotImplementedException();
    }

    protected void BindCommand<T>(Cmd.SERVER_COMMAND id, Action<T> callback) where T : ICommand {
    }
}
