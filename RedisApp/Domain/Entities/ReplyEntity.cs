namespace RedisApp.Domain.Entities
{
    public class ReplyEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
