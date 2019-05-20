using AutoMapper;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.AddProfile(new BusinessToDtoProfile());
                //cfg.AddProfile(new DtoToBusinessProfile());
            });

            IMapper mapper = new Mapper(config);

            T_ACCOUNT tableRow = new T_ACCOUNT()
            {
                DELETED = 1,
                EMAIL = "asdf@asdf.cz",
                ID = 8,
                IS_EMAIL_CONFIRMED = 1,
                PROFILE_ID = 11,
                TIME = DateTime.Now
            };

            Account businessModel = mapper.Map<Account>(tableRow);
            T_ACCOUNT backToDto = mapper.Map<T_ACCOUNT>(businessModel);

            Console.ReadLine();
        }
    }
}
