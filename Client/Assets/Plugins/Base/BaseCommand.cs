using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;

public class ICmdBase {
    public byte byCmd;
    public byte byParam;
    public long dwTimestamp;
    public ICmdBase() {
        byCmd = 0;
        byParam = 0;
        dwTimestamp = 0;
    }

    static byte[] sHeaderLengthBuffer = new byte[4];

    void writeHeader(MemoryStream stream) {
        stream.WriteByte(byCmd);
        stream.WriteByte(byParam);
        sHeaderLengthBuffer = BitConverter.GetBytes(dwTimestamp);
        stream.Write(sHeaderLengthBuffer, 0, sHeaderLengthBuffer.Length);
        //Debug.Log("byCmd=" + byCmd + " byParam" + byParam + " dwTimestamp" + dwTimestamp + " length" + bpara.Length + " bpara" + bpara.ToString());
    }
    protected virtual ICmdBase write(MemoryStream stream) {
        return this;
    }
    public virtual void serialize(MemoryStream stream) {
        writeHeader(stream);
        write(stream);
    }

    static byte[] sPara = new byte[4];

    public virtual void unserialize(MemoryStream stream) {
        byCmd = Convert.ToByte(stream.ReadByte());
        byParam = Convert.ToByte(stream.ReadByte());
        stream.Read(sPara, 0, 4);
        dwTimestamp = BitConverter.ToUInt32(sPara, 0);
    }
}

public class stClientUnityUserCmd : ICmdBase {
    public stClientUnityUserCmd() {
        byParam = 0;
        messageid = 0;
        size = 0;
    }
    public override void serialize(MemoryStream stream) {
        base.serialize(stream);

        byte[] bmessageid = BitConverter.GetBytes(messageid);
        stream.Write(bmessageid, 0, bmessageid.Length);

        byte[] bsize = BitConverter.GetBytes(size);
        stream.Write(bsize, 0, bsize.Length);
        if (data != null)
            stream.Write(data, 0, (int)size);
    }

    public void unserialize(MemoryStream stream) {
        base.unserialize(stream);

        byte[] bmessageid = new byte[4];
        stream.Read(bmessageid, 0, 4);
        messageid = BitConverter.ToUInt32(bmessageid, 0);
        byte[] bsize = new byte[4];
        stream.Read(bsize, 0, 4);
        size = BitConverter.ToUInt32(bsize, 0);

        try {
            data = new byte[size];
            stream.Read(data, 0, (int)size);
        } catch (Exception ex) {
            Debug.LogError(ex.Message);
        }
    }
    public uint messageid;//ÏûÏ¢±àºÅ
    public uint size;
    public byte[] data;
}