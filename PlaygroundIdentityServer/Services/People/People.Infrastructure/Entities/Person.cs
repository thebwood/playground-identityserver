using System;
using System.Collections.Generic;

namespace People.Infrastructure.Entities
{
    public partial class Person
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BirthCity { get; set; }
        public Guid? BirthStateId { get; set; }
        public string City { get; set; }
        public Guid? StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public Guid? CountryId { get; set; }
        public string CountryAbbreviation { get; set; }
        public string CountryName { get; set; }
    }
}
