

namespace timeCamp.CommonLogic.Modal
{
    public class Address : BaseEntity
    {
        public int Number { get; set; } = default!;

        public string Street { get; set; } = default!;

        public string Zip { get; set; } = default!;

        public string City { get; set; } = default!;

    }
}
