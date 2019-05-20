using AutoMapper;
using System;
using AutoMapper.QueryableExtensions;
using AutoMapper.Mappers;
using Humanizer;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            IMapper dtoToBusinessMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddConditionalObjectMapper()
                   .Where((s, d) => s.Name == d.Name.Substring(2).Pascalize());

                cfg.CreateMap<int, bool>().ConvertUsing(val => val == 0 ? false : true);
                cfg.CreateMap<int, AccountId>().ConvertUsing(id => (AccountId)id.ToString());
                cfg.CreateMap<int, ProfileId>().ConvertUsing(id => (ProfileId)id.ToString());
                cfg.CreateMap<int?, ProfileId?>().ConvertUsing(id => id.HasValue ? new ProfileId(id.Value.ToString()) : (ProfileId?)null);

                cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            }).CreateMapper();

            IMapper businessToDtoMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddConditionalObjectMapper()
                   .Where((s, d) => s.Name == "T_" + d.Name.Underscore().ToUpperInvariant());

                cfg.CreateMap<bool, int>().ConvertUsing((boolValue, intValue) => boolValue ? 1 : 0);
                cfg.CreateMap<AccountId, int>().ConvertUsing(id => Int32.Parse(id.Value));
                cfg.CreateMap<ProfileId, int>().ConvertUsing(id => Int32.Parse(id.Value));
                cfg.CreateMap<ProfileId?, int?>().ConvertUsing(id => id.HasValue ? Int32.Parse(id.Value.Value) : (int?)null);

                cfg.SourceMemberNamingConvention = new PascalCaseNamingConvention();
                cfg.DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention(); 
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
            Account businessModel = dtoToBusinessMapper.Map<Account>(tableRow);
            T_ACCOUNT backToDto = businessToDtoMapper.Map<T_ACCOUNT>(businessModel);

            Console.ReadLine();
        }
    }
}
