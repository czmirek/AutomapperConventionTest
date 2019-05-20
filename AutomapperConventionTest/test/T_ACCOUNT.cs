using System;

namespace test
{
    public class T_ACCOUNT
    {
        public int ID { get; set; }
        public int? PROFILE_ID { get; set; }
        public int DELETED { get; set; }
        public string EMAIL { get; set; }
        public int IS_EMAIL_CONFIRMED { get; set; }
        public DateTime TIME { get; set; }
    }
}
