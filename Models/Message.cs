

namespace ChatApp.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string WriteMassge { get; set; }
        public int SenderId { get; set; }
        public UserSender Sender { get; set; }
        public DateTime DateOfMsg { get; set; }
        public TypeOfMsg TOfMsg { get; set; }

    }
}