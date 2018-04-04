using Example.DataAccess;
using Example.DataAccess.Azure;
using Example.DTOs;
using System;

namespace Example.BusinessEntities
{
    public class PersonDto:IMapFrom<AzurePerson>,IMapFrom<Person>, IMapTo<AzurePerson>, IMapTo<Person>
    {
        public int Id

        {
            get; set;
        }

        public int RowKey

        {
            get; set;
        }

        public int PatitionKey

        {
            get; set;
        }

        public string FirstName

        {
            get; set;
        }

        public string LastName

        {
            get; set;
        }

        public string Address

        {
            get; set;
        }
    }
}