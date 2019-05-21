namespace test
{
    using AutoMapper;
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            IMapper oneMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BusinessToDtoProfile());
                cfg.AddProfile(new DtoToBusinessProfile());
                cfg.CreateMissingTypeMaps = true;
            }).CreateMapper();

            T_ACCOUNT tableRow = new T_ACCOUNT()
            {
                DELETED = 0,
                EMAIL = "asdf@asdf.cz",
                ID = 8,
                IS_EMAIL_CONFIRMED = 1,
                PROFILE_ID = 11,
                TIME = DateTime.Now
            };
            Account businessModel = oneMapper.Map<Account>(tableRow);
            T_ACCOUNT backToDto = oneMapper.Map<T_ACCOUNT>(businessModel);
            Console.ReadLine();
        }
    }
}
