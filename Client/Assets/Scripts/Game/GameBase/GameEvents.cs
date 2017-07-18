using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameEvents: Dispatcher {
    public static GameEvents Instance;

    internal void Bind(int id, Action callback) {
        throw new NotImplementedException();
    }
}
