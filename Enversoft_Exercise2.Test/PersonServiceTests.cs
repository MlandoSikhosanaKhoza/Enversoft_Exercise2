using Enversoft_Exercise2.Software;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft_Exercise2.Test
{
    public class PersonServiceTests
    {
        //System Under Test
        private readonly IPersonService _personService;
        private readonly IReadCsvService _readCsvService;
        public PersonServiceTests() {
            _readCsvService = FakeItEasy.A.Fake<IReadCsvService>();
            _personService =new PersonService(_readCsvService);
        }



        [Fact]
        public void PersonService_GetNameFrequencies_ReturnStrictValues()
        {
            //Arrange
            List<Person> personList = new List<Person>();
            Random random = new Random();
            #region Test Data
            personList.Add(new Person
            {
                FirstName = $"John",
                LastName = $"Smit",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new[] { "Rd", "St", "Ave" }[random.Next(0, 2)]}",
                PhoneNumber = random.Next(999999999).ToString("D10")
            });
            personList.Add(new Person
            {
                FirstName = $"Dewald",
                LastName = "Bekker",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new[] { "Rd", "St", "Ave" }[random.Next(0, 2)]}",
                PhoneNumber = random.Next(999999999).ToString("D10")
            });
            personList.Add(new Person
            {
                FirstName = $"Johan",
                LastName = "Smith",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new[] { "Rd", "St", "Ave" }[random.Next(0, 2)]}",
                PhoneNumber = random.Next(999999999).ToString("D10")
            });
            personList.Add(new Person
            {
                FirstName = $"Bradley",
                LastName = "Smith",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new[] { "Rd", "St", "Ave" }[random.Next(0, 2)]}",
                PhoneNumber = random.Next(999999999).ToString("D10")
            });
            personList.Add(new Person
            {
                FirstName = $"Koos",
                LastName = "Bekker",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new[] { "Rd", "St", "Ave" }[random.Next(0, 2)]}",
                PhoneNumber = random.Next(999999999).ToString("D10")
            });
            personList.Add(new Person
            {
                FirstName = $"Marietjie",
                LastName = "Bekker",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new[] { "Rd", "St", "Ave" }[random.Next(0, 2)]}",
                PhoneNumber = random.Next(999999999).ToString("D10")
            });
            personList.Add(new Person
            {
                FirstName = $"Khumbulani",
                LastName = "Mkhize",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new[] { "Rd", "St", "Ave" }[random.Next(0, 2)]}",
                PhoneNumber = random.Next(999999999).ToString("D10")
            });
            personList.Add(new Person
            {
                FirstName = $"Siyabonga",
                LastName = "Mkhize",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new[] { "Rd", "St", "Ave" }[random.Next(0, 2)]}",
                PhoneNumber = random.Next(999999999).ToString("D10")
            });
            #endregion Test Data

            FakeItEasy.A.CallTo(() => _readCsvService.GetPeople()).Returns(personList);

            //Act
            Dictionary<string, int> result = _personService.GetNameFrequencies();

            //Assert
            result.Should().HaveElementAt(0, new KeyValuePair<string, int>("Bekker", 3));
            result.Should().HaveElementAt(1, new KeyValuePair<string, int>("Mkhize", 2));
            result.Should().HaveElementAt(2, new KeyValuePair<string, int>("Smith", 2));
        }

        [Fact]
        public void PersonService_GetNameFrequencies_ReturnOrderedDescPersonList()
        {
            //Arrange
            List<Person> personList = FakeItEasy.A.CollectionOfFake<Person>(10).ToList();
            Random random=new Random();
            personList=personList.Select(pl => new Person
            {
                FirstName = $"{new[] { "John", "Njabulo", "Johan", "Marietjie","Dewald","Thabo","Koos" }[random.Next(0, 6)]}",
                LastName = $"{new[] { "Smit", "Smith", "Van de Merwe", "Mchunu", "Motsepe","Bekker" }[random.Next(0, 5)]}",
                Address = $"{(random.Next(1, 200))} {((char)random.Next(65, 90))}{((char)random.Next(65, 90))} {new []{ "Rd","St","Ave"}[random.Next(0,2)]}",
                PhoneNumber=random.Next(999999999).ToString("D10")
            }).ToList();
            FakeItEasy.A.CallTo(() => _readCsvService.GetPeople()).Returns(personList);

            //Act
            Dictionary<string, int> result = _personService.GetNameFrequencies();

            //Assert
            result.Should().BeInDescendingOrder(d => d.Value);
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public void PersonService_GetNameFrequencies_ReturnEmptyPersonList()
        {
            //Arrange
            IEnumerable<Person> personList = FakeItEasy.A.Fake<IEnumerable<Person>>();
            FakeItEasy.A.CallTo(() => _readCsvService.GetPeople()).Returns(personList.ToList());

            //Act
            Dictionary<string, int> result = _personService.GetNameFrequencies();

            //Assert
            result.Should().HaveCount(0);
        }
        /// <summary>
        /// This test is directly testing data from the CSV. 
        /// (Of Course) it is !problematic! because its dependant on if the ReadCsvService works or not 
        /// --> Its to prove that the unit tests work.
        /// </summary>
        [Fact]
        public void PersonService_GetNameFrequencies_ReturnPersonListFromCSV()
        {
            //Arrange
            ReadCsvService readCsvService = new ReadCsvService();
            PersonService personService = new PersonService(readCsvService);
            
            //Act
            Dictionary<string,int> result=personService.GetNameFrequencies();
            
            //Assert
            result.Should().HaveCountGreaterThan(0);
            result.Should().BeInDescendingOrder(d => d.Value);
            #region Uncomment for Original CSV
            //result.Should().HaveElementAt(0, new KeyValuePair<string, int>("Brown", 2));
            #endregion Uncomment for Original CSV
        }
    }
}
