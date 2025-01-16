

namespace timeCamp.CommonLogic.Modal
{
    public class EmployeeCredentials: BaseEntity
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Guid? EmployeeId { get; set; } = default!;
        public Employee Employee { get; set; } = default!;
    }
}
