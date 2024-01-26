

namespace ChatApp.Data.Models
{
    public class UserSender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}