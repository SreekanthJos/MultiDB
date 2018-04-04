using AutoMapper;
using Example.BusinessEntities;
using Example.DataAccess;
using Example.DataAccess.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Business
{
    public class PersonRepository : IPersonRepository
    {
        public List<PersonDto> GetPersons()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<AzurePerson, PersonDto>();
            //    cfg.CreateMap<PersonDto, AzurePerson>();
            //    cfg.CreateMap<Person, PersonDto>();
            //    cfg.CreateMap<PersonDto, Person>();


            //});


            object obj =new TableFinder().GetPersonTable();
          
            PersonDto pd = (PersonDto)Mapper.Map(obj, obj.GetType(), typeof(PersonDto));
            return new List<PersonDto>();
        }
    }
}
