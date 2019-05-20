namespace test
{
    using AutoMapper;
    using AutoMapper.Mappers;
    using Humanizer;

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