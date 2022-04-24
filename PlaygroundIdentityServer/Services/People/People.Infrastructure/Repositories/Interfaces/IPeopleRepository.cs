using People.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Infrastructure.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> Get();
        Person Get(Guid? personId);
        Person Save(Person person);
        bool Delete(Guid? personId);
        List<PersonSearchResults> Search(PersonSearch personSearch);
    }
}
