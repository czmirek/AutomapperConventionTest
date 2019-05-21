namespace test
{
    using AutoMapper;
    using System.Linq;
    using AutoMapper.Mappers;
    using Humanizer;
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    internal class BusinessToDtoProfile : Profile
    {
        public BusinessToDtoProfile()
        {
            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();

            CreateMap<bool, int>().ConvertUsing((boolValue, intValue) => boolValue ? 1 : 0);
            CreateMap<AccountId, int>().ConvertUsing(id => Int32.Parse(id.Value));
            CreateMap<ProfileId, int>().ConvertUsing(id => Int32.Parse(id.Value));
            CreateMap<ProfileId?, int?>().ConvertUsing(id => id.HasValue ? Int32.Parse(id.Value.Value) : (int?)null);

            IEnumerable<TypeInfo> allTypes= typeof(BusinessToDtoProfile).Assembly.DefinedTypes;
            IEnumerable<TypeInfo> dtoTypes = typeof(BusinessToDtoProfile).Assembly.DefinedTypes
                                                                         .Where(t => t.Name.StartsWith("T_"));

            foreach (TypeInfo dtoType in dtoTypes)
            {
                TypeInfo businessPocoType = allTypes.FirstOrDefault(t => dtoType.Name.Substring(2).ToLowerInvariant().Pascalize() == t.Name);
                if(businessPocoType != null)
                {
                    CreateMap(businessPocoType, dtoType);
                }
                
            }
        }
    }
}