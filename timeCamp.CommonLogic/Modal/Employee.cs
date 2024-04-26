

namespace timeCamp.CommonLogic.Modal
{
    public class Employee: BaseEntity
    {
        public string Firstname { get; set; } = default!;
        public string Lastname { get; set;} = default!;
        public string Email { get; set; } = default!;
        public  Address Address { get; set; } = default!;
        public  Job? Job { get; set; } = default!;
        public  List<Ticket> Tickets { get; set; } = default!;
        public EmployeeCredentials EmployeeCredentials { get; set; }
        public string? ProfilePhotoPath { get; set; } = default!;
        public Boolean? isEmployeeActive { get; set; } = default!;
        public DateTime? isDeleted { get; set; } = default!;

    }
}
