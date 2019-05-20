namespace test
{
    using AutoMapper;
    using AutoMapper.Mappers;
    using Humanizer;

    internal class DtoToBusinessProfile : Profile
    {
        public DtoToBusinessProfile()
        {
         
            AddConditionalObjectMapper()
                .Where((s, d) =>
                {
                    return s.Name == d.Name.Substring(2).Pascalize();
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
            CreateMap<int, bool>().ConvertUsing(val => val == 0 ? false : true);
            CreateMap<int, AccountId>().ConvertUsing(id => (AccountId)(id.ToString()));
            CreateMap<int, ProfileId>().ConvertUsing(id => (ProfileId)(id.ToString()));
            CreateMap<int?, ProfileId?>().ConvertUsing(id => id.HasValue ? new ProfileId(id.Value.ToString()) : (ProfileId?)null);
            SourceMemberNamingConvention = new UppercaseUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            */
        }
    }
}