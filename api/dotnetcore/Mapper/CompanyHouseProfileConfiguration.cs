using AutoMapper;
using api.Models;
using System.Globalization;
using api.Extensions;

namespace api.Mapper
{
    public class CompanyHouseProfileConfiguration : Profile
    {
        public CompanyHouseProfileConfiguration():base("CompanyHouseProfile")
        {
            CreateMap<CompanySearch, Company>()
                .ForMember(c => c.Title, cs => cs.MapFrom(x => x.title))
                .ForMember(c => c.Number, cs => cs.MapFrom(x => x.company_number))
                .ForMember(c => c.Status, cs => cs.MapFrom(x => ConvertToTitleCase(x.company_status)))
                .ForMember(c => c.Type, cs => cs.MapFrom(x => ConvertToTitleCase(x.company_type)))
                .ForMember(c => c.RegisteredAddress, cs => cs.MapFrom(x => x.address_snippet))
                .ForMember(c => c.IncorporationDate, cs => cs.MapFrom(x => x.date_of_creation.ToLongDateFormat()));
        }

        private string ConvertToTitleCase(string data)
        {
            var s = data.Replace("-", " ");
            return s.ToTitleCase();
        }
    }
}
