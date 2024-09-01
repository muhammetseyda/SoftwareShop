namespace SoftwareShop.Comment.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string UserPhoto { get; set; }
    }
}
