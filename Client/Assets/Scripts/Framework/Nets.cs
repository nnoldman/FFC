using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class Nets : BaseController {
    static Nets msInstance = null;
    public static Nets Instance {
        get {
            return msInstance;
        }
    }

    public Nets() {
        msInstance = this;
    }

    public override IEnumerator Initialize() {
        mClientId = SystemInfo.deviceUniqueIdentifier;
        InitSocket();
        Debug.Log("NetManager Start ");
        yield return null;
    }

    public override void OnMapReady() {
        //this.ResumeMessageLoop();
    }

    public override void Update() {
        if (mMainSocket != null)
            mMainSocket.UpdateMessageQueue();
    }

    public enum EServerIpList {
        Local = 0,
        Lan_04 = 1,
        Lan_13 = 2,
        Lan_16 = 3,
        Public = 4,
    }

    public enum EPlatform {
        Device = 0,
        GameCenter = 1,
    }
    public enum EServer {
        Server1,
        Server2,
        Server3,
        Server4,
        Server5,
    }


    // member functions.
    string mClientId = null;

    SocketBase mMainSocket;

    public string ServerIp = "169.254.1.200";
    public int ServerPort = 15299;
    public float ConnectTimeout = 10.0f;
    public UInt64 _dwUserID;
    public uint _loginTempID;
    public ushort _port;

    public string ClientId {
        get {
            return mClientId;
        }
        set {
            mClientId = value;
        }
    }
    public string ClientUserName {
        get;
        set;
    }
    public bool Interrupting {
        get {
            if (mMainSocket != null) return mMainSocket.Interrupted;
            return false;
        }
    }
    public SocketBase MainSocket {
        get {
            return mMainSocket;
        }
    }

    public EServerIpList Server = EServerIpList.Local;
    public EPlatform Platform = EPlatform.Device;
    public EServer ServerID;

    public bool connecting {
        get {
            return mMainSocket != null && mMainSocket.TryConnecting;
        }
    }

    public float HeartBeatTime = 20f + 20f;

    float mServerTimeMark = 0;

    public void OnTimeSet() {
        //Debug.LogWarning(string.Format("OnTimeSet:{0}", Time.time));
        mServerTimeMark = Time.realtimeSinceStartup;
    }

    public uint serverTime {
        get {
            if (mMainSocket != null) {
                return (uint)(mMainSocket.lastServerTime + Time.realtimeSinceStartup - mServerTimeMark);
            }
            return 0;
        }
    }

    private static MemoryStream sSerializeBuffer = new MemoryStream(2 << 15);

    void InitSocket() {
        if (mMainSocket == null) {
            if (Application.isPlaying) {
                mMainSocket = new SocketBase();
                mMainSocket.messageHandler += DispathBytes;
                mMainSocket.errorHandler += OnNetEvent;
            }
        }
    }

    void OnNetEvent(int id) {
    }

    public void InterruptMessageLoop() {
        if (mMainSocket != null)
            mMainSocket.Interrupted = true;
    }
    public void ResumeMessageLoop() {
        if (mMainSocket != null)
            mMainSocket.Interrupted = false;
    }

    public void ConnectLoginServer(string user, string psd) {
#if !UNITY_EDITOR
        int serverid = (int)EServer.Server2 + 1;
#else
        int serverid = (int)ServerID + 1;
#endif
        if (mMainSocket != null)
            mMainSocket.connectLoginServer(ServerIp, ServerPort, user, psd, serverid.ToString());
    }

    public void ConnectServer(string host, int port, string user, string psd, int serverid) {
        mMainSocket.connectLoginServer(host, port, user, psd, serverid.ToString());
    }


    public void ConnectServerBySDK(string host, int port, string user, string psd, int serverid) {
        mMainSocket.connectLoginServerBySDK(host, port, user, serverid.ToString());
    }

    public void Disconnect() {
        if (mMainSocket != null)
            mMainSocket.Closed(NetEventID.ActiveDisconnect);
    }

    public static void SendBuffer(int msgid, byte[] data) {
        if (!isConnected)
            return;

        stClientUnityUserCmd sendcmd = new stClientUnityUserCmd();
        sendcmd.messageid = (uint)msgid;
        sendcmd.size = (uint)data.Length;
        sendcmd.data = data;
        SendCmd(sendcmd);
    }

    static void SendCmd<T>(T cmd) where T : ICmdBase {
        sSerializeBuffer.Position = 0;
        cmd.serialize(sSerializeBuffer);
        Instance.mMainSocket.send(sSerializeBuffer);
    }

    public static void SendID(int msgid) {
        if (!isConnected)
            return;

        if (!isConnected)
            return;
        stClientUnityUserCmd sendcmd = new stClientUnityUserCmd();
        sendcmd.messageid = (uint)msgid;
        SendCmd(sendcmd);
    }


    public static void SendByServerID(SERVER_MESSAGE msgid) {
        if (!isConnected)
            return;
        stClientUnityUserCmd sendcmd = new stClientUnityUserCmd();
        sendcmd.messageid = (uint)msgid;
        SendCmd(sendcmd);

        //LogClass.Instance.LogSend(sendcmd);
    }
    public static bool isConnected {
        get {
            if (Instance == null)
                return false;
            if (Instance.mMainSocket == null)
                return false;
            if (!Instance.mMainSocket.connected)
                return false;
            return true;
        }
    }
    public static void Send(CLIENT_MESSAGE msgid) {
        SendByServerID((SERVER_MESSAGE)msgid);
    }

    public static void Send(ICmdBase cmd) {
        if (!isConnected)
            return;
        sSerializeBuffer.Position = 0;
        cmd.serialize(sSerializeBuffer);
        Instance.mMainSocket.send(sSerializeBuffer);
    }

    public static void Send<T>(CLIENT_MESSAGE msgid, T protodata) where T : ICommand {
        if (!isConnected)
            return;
        MemoryStream stream = new MemoryStream();
        ProtoBuf.Serializer.Serialize<T>(stream, protodata);

        stClientUnityUserCmd sendcmd = new stClientUnityUserCmd();
        sendcmd.messageid = (uint)msgid;
        sendcmd.size = (uint)stream.ToArray().Length;
        sendcmd.data = new byte[sendcmd.size];
        Array.Copy(stream.GetBuffer(), sendcmd.data, sendcmd.size);

        SendCmd(sendcmd);
        //LogClass.Instance.LogSend(protodata);
    }
    public static T Parse<T>(byte[] msg) where T : ICommand {
        MemoryStream stream = new MemoryStream(msg);
        T protoBuffer = ProtoBuf.Serializer.Deserialize<T>(stream);
        //LogClass.Instance.LogReceive(protoBuffer);
        return protoBuffer;
    }
    public static object Parse(byte[] msg, Type tp) {
        MemoryStream stream = new MemoryStream(msg);
        object protoBuffer = ProtoBuf.Serializer.Deserialize(stream, tp);
        // LogClass.Instance.LogReceive(protoBuffer);
        return protoBuffer;
    }

    public static T ParseCmd<T>(byte[] msg) where T : ICmdBase {
        Type tp = typeof(T);
        T cmd = (T)tp.GetConstructor(Type.EmptyTypes).Invoke(null);
        cmd.unserialize(new MemoryStream(msg));
        return cmd;
    }

    public void OnMsg(ref byte[] msg, uint msgId) {
    }

    public void DispathBytes(byte[] byteArray) {
    }

    public override IEnumerator OnGameStageClose() {
        throw new NotImplementedException();
    }
}
