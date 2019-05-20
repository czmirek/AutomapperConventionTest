namespace test
{
    using AutoMapper;
    using AutoMapper.Mappers;
    using Humanizer;
    using System;

    internal class BusinessToDtoProfile : Profile
    {
        public BusinessToDtoProfile()
        {
            CreateMap<bool, int>().ConvertUsing((bl, nt) => bl ? 1 : 0);
            
            CreateMap<AccountId, int>().ConvertUsing(id => Int32.Parse(id.Value));
            CreateMap<ProfileId, int>().ConvertUsing(id => Int32.Parse(id.Value));
            CreateMap<ProfileId?, int?>().ConvertUsing(id => id.HasValue ? Int32.Parse(id.Value.Value) : (int?)null);

            AddConditionalObjectMapper()
                .Where((s, d) =>
                {
                    return s.Name == "T_" + d.Name.Underscore().ToUpperInvariant();
                });


            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new UppercaseUnderscoreNamingConvention();
        }
    }

    internal class DtoToBusinessProfile : Profile
    {
        public DtoToBusinessProfile()
        {
            CreateMap<int, bool>().ConvertUsing(val => val == 0 ? false : true);
            CreateMap<int, AccountId>().ConvertUsing(id => (AccountId)(id.ToString()));
            CreateMap<int, ProfileId>().ConvertUsing(id => (ProfileId)(id.ToString()));
            CreateMap<int?, ProfileId?>().ConvertUsing(id => id.HasValue ? new ProfileId(id.Value.ToString()) : (ProfileId?)null);

            AddConditionalObjectMapper()
                .Where((s, d) =>
                {
                    return s.Name == d.Name.Substring(2).Pascalize();
                });

            SourceMemberNamingConvention = new UppercaseUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}