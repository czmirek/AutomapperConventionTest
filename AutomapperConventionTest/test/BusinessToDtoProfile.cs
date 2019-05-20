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
            AddConditionalObjectMapper()
                .Where((s, d) =>
                {
                    return s.Name == "T_" + d.Name.Underscore().ToUpperInvariant();
                });

            ForAllPropertyMaps(pm =>
            {
                //breakpoint here
                return pm.SourceMember.Name == pm.DestinationMember.Name.Underscore().ToUpperInvariant();
            }, (pm, o) =>
            {
                //do nothing
            });
            /*
            CreateMap<bool, int>().ConvertUsing((bl, nt) => bl ? 1 : 0);
            CreateMap<AccountId, int>().ConvertUsing(id => Int32.Parse(id.Value));
            CreateMap<ProfileId, int>().ConvertUsing(id => Int32.Parse(id.Value));
            CreateMap<ProfileId?, int?>().ConvertUsing(id => id.HasValue ? Int32.Parse(id.Value.Value) : (int?)null);
            
            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new UppercaseUnderscoreNamingConvention();
            */
        }
    }
}