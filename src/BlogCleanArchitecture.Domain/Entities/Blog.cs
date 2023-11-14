namespace BlogCleanArchitecture.Domain.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreationDateTime { get; set; }
    }
}
