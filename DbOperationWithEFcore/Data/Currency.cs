namespace DbOperationWithEFcore.Data
{
    public class Currency
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<BookPrice> BookPrices { get; set; }
    }
}
