using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Dispatcher {
    public Dictionary<int, Action> mReceivers;
    public void Trigger(int id, object args) {
    }
    public void Bind(int id, Action<ICommand> callback) {
    }
}
