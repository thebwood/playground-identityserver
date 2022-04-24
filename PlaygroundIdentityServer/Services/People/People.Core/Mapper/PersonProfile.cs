using AutoMapper;
using People.Core.Models;
using People.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Core.Mapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonModel>();
            CreateMap<PersonModel, Person>();
            CreateMap<PersonSearchModel, PersonSearch>();
            CreateMap<PersonSearchResults, PersonSearchResultsModel>();
        }
    }
}
