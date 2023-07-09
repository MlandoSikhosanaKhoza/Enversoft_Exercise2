using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft_Exercise2.Software
{
    public class PersonService:IPersonService
    {
        private readonly IReadCsvService _readCsvService;
        public PersonService(IReadCsvService readCsvService) {
            _readCsvService = readCsvService;
        }

        public Dictionary<string,int> GetNameFrequencies()
        {
            Dictionary<string,int> nameFrequencies = new Dictionary<string, int>();
            
            //Read CSV File
            List<Person> people = _readCsvService.GetPeople();
            
            //Add each unique name
            foreach (Person person in people)
            {
                if (!nameFrequencies.ContainsKey(person.FirstName))
                {
                    nameFrequencies.Add(person.FirstName, people.Count(p=>p.FirstName==person.FirstName || p.LastName==person.FirstName));
                }
                if (!nameFrequencies.ContainsKey(person.LastName))
                {
                    nameFrequencies.Add(person.LastName, people.Count(p => p.LastName == person.LastName || p.FirstName == person.LastName));
                }
            }
            
            //Order your dictionary
            nameFrequencies=nameFrequencies.OrderBy(nf=>nf.Key).OrderByDescending(nf=>nf.Value).ToDictionary(nf=>nf.Key,nf=>nf.Value);

            return nameFrequencies;
        }


    }
}
