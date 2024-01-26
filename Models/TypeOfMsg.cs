using System.Runtime.Serialization;

namespace ChatApp.Data.Models
{
    public enum TypeOfMsg
    {
        [EnumMember(Value = "send")]
        send,
        [EnumMember(Value = "coming")]
        coming
    }
}