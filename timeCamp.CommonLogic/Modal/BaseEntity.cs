

namespace timeCamp.CommonLogic.Modal
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string CreatedAt { get; set; } = default!;
        public string ModifiedAt { get; set; } = default!;
        public string RemovedAt { get; set; } = default!;
        
    }
}
