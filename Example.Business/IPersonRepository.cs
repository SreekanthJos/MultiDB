using Example.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Business
{
    public interface IPersonRepository
    {
        List<PersonDto> GetPersons();
    }
}
