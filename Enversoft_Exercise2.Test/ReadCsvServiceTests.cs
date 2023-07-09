using Enversoft_Exercise2.Software;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft_Exercise2.Test
{
    public class ReadCsvServiceTests
    {
        private readonly IReadCsvService _readCsvService;
        public ReadCsvServiceTests() { 
            //SUT
            _readCsvService = new ReadCsvService();
        }

        [Fact]
        public void ReadCsvService_GetPeople_ReturnsPeopleObject()
        {
            //Arrange
            List<Person> result;
            //Act
            result = _readCsvService.GetPeople();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().HaveCountGreaterThan(1);
            /* I'm checking against the original csv*/
            result.Should().HaveCount(8);
        }
    }
}
