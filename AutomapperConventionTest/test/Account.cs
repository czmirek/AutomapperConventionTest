using System;

namespace test
{
    public class Account
    {
        public AccountId Id { get; set; }
        public ProfileId? ProfileId { get; set; }
        public bool Deleted { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime Time { get; set; }
    }
}
