using People.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Core.Services.Interfaces
{
    public interface IPeopleService
    {
        List<string> Save(PersonModel person);
        IEnumerable<PersonModel> Get();
        PersonModel Get(Guid? personId);
        bool Delete(Guid? personId);
        List<PersonSearchResultsModel> Search(PersonSearchModel searchRequest);
    }
}
