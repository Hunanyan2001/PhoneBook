using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class Program
    {
        public delegate void Message();
        public delegate void Error(int line);
        public delegate void PrintLineInformation(List<string> line);
        static void Main(string[] args)
        {
            List<bool> number;
            List<bool> surname;
            List<bool> separator;
            Print print = new Print();
            Message mes = print.ChooseFile;
            mes();
            int selectValidator = int.Parse(Console.ReadLine());
            Validators validator = new Validators();
            validator.ChooseValidators(selectValidator);
            string path = validator.filePath;
            if (path != null)
            {
                string[] peopleInformation = GetLine(path);
                ChooseSortingType sorting = new ChooseSortingType(peopleInformation);
                List<string> line = sorting.Choose();
                number = validator.CheckNumber(line);
                surname = validator.CheckSurname(line);
                separator = validator.CheckSeparator(line);
                InformationLine info = new InformationLine(number, separator);
                info.Information();
            }
        }
        public static string[] GetLine(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
    }
}
