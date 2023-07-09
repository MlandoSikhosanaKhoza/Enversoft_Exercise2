using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft_Exercise2.Software.Services
{
    public class ReadCsvService : IReadCsvService
    {
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            StreamReader streamReader = new StreamReader("./DataCSV/Data.csv");
            using(var csv=new CsvReader(streamReader,CultureInfo.InvariantCulture))
            {
                people=csv.GetRecords<Person>().ToList();
            }
            
            return people;
        }
    }
}
