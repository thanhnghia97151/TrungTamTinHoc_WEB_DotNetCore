namespace WebApi.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string MemberId { get; set; }
        public string Phone { get; set; }
        public string AddressName { get; set; }
        public int WardId { get; set; }
        public string FullName { get; set; }

        public string? ProvinceName { get; set; }
        public string? DistrictName { get; set; }
        public string? WardName { get; set; }
        public bool IsDefault { get; set; }
    }
}
