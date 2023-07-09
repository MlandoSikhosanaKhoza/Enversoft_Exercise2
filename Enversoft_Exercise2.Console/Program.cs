// See https://aka.ms/new-console-template for more information
using Enversoft_Exercise2.Software;

string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

IReadCsvService readCsvService = new ReadCsvService();
IPersonService personService = new PersonService(readCsvService);

string[] nameFrequencyList = personService.GetNameFrequencies().Select(nf => $"{nf.Key}, {nf.Value}").ToArray();
string namefrequencyText = string.Join(Environment.NewLine,nameFrequencyList);
string addressText = string.Join(Environment.NewLine, personService.GetOrderedAddresses());

System.IO.File.WriteAllText(Path.Combine(path, "Ex2_Mlando_File_1_NameFrequency.txt"),namefrequencyText);
System.IO.File.WriteAllText(Path.Combine(path, "Ex2_Mlando_File_2_Address.txt"),addressText);

Console.WriteLine("/*------------------------------------READ THE TEXT BELOW------------------------------------------*/");
Console.WriteLine();
Console.WriteLine("Please check you desktop for Ex2_Mlando_File_1_NameFrequency.txt and Ex2_Mlando_File_2_Address.txt");
Console.WriteLine();
Console.WriteLine("/*------------------------------------READ THE TEXT ABOVE------------------------------------------*/");
Console.ReadKey();