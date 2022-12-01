using CustomerMicroService.Domain.Common;

namespace CustomerMicroService.Domain
{
    public class Customer : BaseDomainEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
    }
}
