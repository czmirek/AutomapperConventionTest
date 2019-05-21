namespace test
{
    using AutoMapper;
    using AutoMapper.Mappers;
    using Humanizer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal class DtoToBusinessProfile : Profile
    {
        public DtoToBusinessProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<int, bool>().ConvertUsing(val => val == 0 ? false : true);
            CreateMap<int, AccountId>().ConvertUsing(id => (AccountId)id.ToString());
            CreateMap<int, ProfileId>().ConvertUsing(id => (ProfileId)id.ToString());
            CreateMap<int?, ProfileId?>().ConvertUsing(id => id.HasValue ? new ProfileId(id.Value.ToString()) : (ProfileId?)null);

            IEnumerable<TypeInfo> allTypes = typeof(BusinessToDtoProfile).Assembly.DefinedTypes;
            IEnumerable<TypeInfo> dtoTypes = typeof(BusinessToDtoProfile).Assembly.DefinedTypes
                                                                         .Where(t => t.Name.StartsWith("T_"));

            foreach (TypeInfo dtoType in dtoTypes)
            {
                TypeInfo businessPocoType = allTypes.FirstOrDefault(t => dtoType.Name.Substring(2).ToLowerInvariant().Pascalize() == t.Name);
                if (businessPocoType != null)
                {
                    CreateMap(dtoType, businessPocoType);
                }
            }
        }
    }
}