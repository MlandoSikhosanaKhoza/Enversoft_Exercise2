using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft_Exercise2.Software
{
    public interface IPersonService
    {
        Dictionary<string, int> GetNameFrequencies();
        string[] GetOrderedAddresses();
    }
}
