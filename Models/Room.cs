


namespace ChatApp.Data.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discreption { get; set; }
        public ICollection<UserSender> Users { get; set; }
    }
}