namespace timeCamp.CommonLogic.Modal
{
    public class Ticket: BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Location { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public string Updates { get; set; } = default!;
        public DateTime TimeOpened { get; set; } = default!;
        public DateTime TimeClosed { get; set; } = default!;
  

    }
}