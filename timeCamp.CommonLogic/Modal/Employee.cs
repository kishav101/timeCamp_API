

namespace timeCamp.CommonLogic.Modal
{
    public class Employee:  BaseEntity
    {
        public string Firstname { get; set; } = default!;
        public string Lastname { get; set;} = default!;
        public string Email { get; set; } = default!;
        public EmployeeCredentials EmployeeCredentials { get; set; }
        public string? ProfilePhotoPath { get; set; } = default!;
        public bool? IsEmployeeActive { get; set; } = default!;

    }
}
