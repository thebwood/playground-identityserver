using AutoMapper;
using Microsoft.Extensions.Logging;
using People.Core.Models;
using People.Core.Services.Interfaces;
using People.Infrastructure.Entities;
using People.Infrastructure.Repositories.Interfaces;
using Playground.Core.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Core.Services
{
    public class PeopleService : PlaygroundService<PeopleService>, IPeopleService
    {
        private readonly IPeopleRepository _repository;
        private readonly IMapper _mapper;
        public PeopleService(ILogger<PeopleService> logger, IPeopleRepository respository, IMapper mapper) : base(logger)
        {
            _repository = respository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public bool Delete(Guid? personId)
        {
            try
            {
                _repository.Delete(personId);
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on Delete", ex);
                return false;
            }

            return true;
        }

        public IEnumerable<PersonModel> Get()
        {
            IEnumerable<PersonModel> results = new List<PersonModel>();
            try
            {
                var values = _repository.Get();
                _mapper.Map(values, results);
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on Get", ex);
            }
            return results;
        }

        public PersonModel Get(Guid? personId)
        {
            var game = _repository.Get(personId);
            var gameModel = new PersonModel();

            _mapper.Map(game, gameModel);

            return gameModel;
        }

        public List<string> Save(PersonModel person)
        {
            var errors = Validate(person);
            if (errors.Count() == 0)
            {
                var existingPerson = new Person();
                if (person.Id != null)
                    existingPerson = _repository.Get(person.Id);


                _mapper.Map<PersonModel, Person>(person, existingPerson);
                existingPerson = _repository.Save(existingPerson);
            }

            return errors;
        }

        private List<string> Validate(PersonModel person)
        {
            var errors = new List<string>();

            if (String.IsNullOrWhiteSpace(person.FirstName))
            {
                errors.Add("Title is required");
            }
            if (String.IsNullOrWhiteSpace(person.LastName))
            {
                errors.Add("Description is required");
            }
            return errors;
        }


        public List<PersonSearchResultsModel> Search(PersonSearchModel model)
        {
            var personSearch = new PersonSearch();
            _mapper.Map(model, personSearch);

            var personSearchResults = _repository.Search(personSearch);
            var personSearchResultsModel = new List<PersonSearchResultsModel>();

            _mapper.Map(personSearchResults, personSearchResultsModel);

            return personSearchResultsModel;
        }
    }
}
