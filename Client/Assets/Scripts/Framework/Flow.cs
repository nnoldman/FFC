using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCore {
public enum GameError {
}

public enum NetState {
    Unreachable,
    Local,
    MobileNet,
}

public class Flow {
    public static Flow Instance {
        get {
            if (mInstance == null)
                mInstance = new Flow();
            return mInstance;
        }
    }

    public static Flow mInstance;

    public Configuration config {
        get;
        set;
    }
    public Game game {
        get;
        set;
    }
    public GameError error {
        get;
        set;
    }
    private AppState state {
        get;
        set;
    }
    public ProgressView loadingView {
        get;
        set;
    }
    public YieldEventHandler onStartEnd {
        get;
        set;
    }

    public GameEventHandler checkNet {
        get;
        set;
    }

    public NetState netState {
        get;
        set;
    }


    private bool mStarted = false;
    private int mNetQueryCount = 0;
    private int mTargetNetQueryCount = 5;

    internal Flow() {
        Updater.Instance = new Updater();
        Loader.Instance = new Loader();
        UIController.Instance = new UIController();
    }
    public IEnumerator CheckNet() {
        yield return 0;
    }

    public IEnumerator Close() {
        yield return game.Close();
        yield return this.CloseGameStage();
    }

    public IEnumerator Restart() {
        if (loadingView != null)
            loadingView.Show();
        if (!mStarted) {
            yield return UIController.Instance.Initialize();
            yield return Loader.Instance.Initialize();
            yield return Updater.Instance.Initialize();
        } else {
            yield return this.Close();
        }

        while (netState == NetState.Unreachable && mNetQueryCount < mTargetNetQueryCount) {
            if (checkNet != null)
                checkNet.Invoke();
            yield return null;
        }

        game = new Game();

        if (!mStarted) {
            yield return Updater.Instance.CheckUpdata();
        }

        yield return game.Start();

        if (onStartEnd != null)
            yield return onStartEnd.Invoke();
        mStarted = true;
        yield return null;
    }

    public IEnumerator CloseGameStage() {
        yield return UIController.Instance.OnGameStageClose();
        yield return Loader.Instance.OnGameStageClose();
        yield return Updater.Instance.OnGameStageClose();
    }
}
}
