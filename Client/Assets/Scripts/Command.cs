//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Command.proto
namespace Cmd
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ReqAccountOperation")]
  public partial class ReqAccountOperation : global::ProtoBuf.IExtensible
  {
    public ReqAccountOperation() {}
    
    private Cmd.AccountAction _action;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"action", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Cmd.AccountAction action
    {
      get { return _action; }
      set { _action = value; }
    }
    private string _user;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"user", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string user
    {
      get { return _user; }
      set { _user = value; }
    }
    private string _password;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"password", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string password
    {
      get { return _password; }
      set { _password = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RetAccountOperation")]
  public partial class RetAccountOperation : global::ProtoBuf.IExtensible
  {
    public RetAccountOperation() {}
    
    private Cmd.AccountErrorCode _error;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"error", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Cmd.AccountErrorCode error
    {
      get { return _error; }
      set { _error = value; }
    }
    private string _password;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"password", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string password
    {
      get { return _password; }
      set { _password = value; }
    }
    private int _accountid;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"accountid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int accountid
    {
      get { return _accountid; }
      set { _accountid = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _late_serverids = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(4, Name=@"late_serverids", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> late_serverids
    {
      get { return _late_serverids; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ReqLoginGameServer")]
  public partial class ReqLoginGameServer : global::ProtoBuf.IExtensible
  {
    public ReqLoginGameServer() {}
    
    private int _accountid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"accountid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int accountid
    {
      get { return _accountid; }
      set { _accountid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"AccountAction")]
    public enum AccountAction
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountAction_None", Value=0)]
      AccountAction_None = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountAction_Create", Value=1)]
      AccountAction_Create = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountAction_Rename", Value=2)]
      AccountAction_Rename = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountAction_Delete", Value=3)]
      AccountAction_Delete = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountAction_Login", Value=4)]
      AccountAction_Login = 4
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"AccountErrorCode")]
    public enum AccountErrorCode
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountErrorCode_None", Value=0)]
      AccountErrorCode_None = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountErrorCode_CreateSucessed", Value=1)]
      AccountErrorCode_CreateSucessed = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountErrorCode_NameRepeated", Value=2)]
      AccountErrorCode_NameRepeated = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountErrorCode_UserCantFind", Value=3)]
      AccountErrorCode_UserCantFind = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountErrorCode_PasswordError", Value=4)]
      AccountErrorCode_PasswordError = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"AccountErrorCode_LoginSucessed", Value=5)]
      AccountErrorCode_LoginSucessed = 5
    }
  
}