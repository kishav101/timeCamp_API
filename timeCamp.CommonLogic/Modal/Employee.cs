﻿

namespace timeCamp.CommonLogic.Modal
{
    public class Employee: BaseEntity
    {
        public string Firstname { get; set; } = default!;
        public string Lastname { get; set;} = default!;
        public  Address Address { get; set; } = default!;
        public  Job Job { get; set; } = default!;
        public  List<Ticket> Tickets { get; set; } = default!;
        public EmployeeCredentials EmployeeCredentials { get; set; }
        public string? ProfilePhotoPath { get; set; } = default!;

    }
}
