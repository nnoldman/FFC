using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commands: Dispatcher {
    public static Commands Instance;

    internal void Bind<T>(int id, Action<T> callback) where T : ICommand {
        throw new NotImplementedException();
    }
    internal void Trigger<T>(int id, Action<T> callback) where T : ICommand {
        throw new NotImplementedException();
    }

}
