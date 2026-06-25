namespace DbOperationWithEFcore.Data
{
    public class Language
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
