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
            //Console.WriteLine("Plese choose the file 1,2 or 3");
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
                List<string> line=ChooseSortingType(peopleInformation);
                number = validator.CheckNumber(line);
                surname = validator.CheckSurname(line);
                separator = validator.CheckSeparator(line);
                MessageLine(number, separator);
            }
        }

        public static string[] GetLine(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }

        private static List<string> ChooseSortingType(string[] lines)
        {
            
            //Console.WriteLine("Please choose an ordering to sort: “Ascending” or “Descending");
            Print print  = new Print();
            PrintLineInformation printLine;
            Message mes = print.ChooseOrderingSort;
            mes();
            string sortingType = Console.ReadLine();
            //Console.WriteLine("“Please choose criteria: “Name”, “Surname” or “PhoneNumberCode”.");
            mes = print.ChooseCriteria;
            mes();
            string sortingCriteria = Console.ReadLine();
            Sort sort = new Sort(sortingType, sortingCriteria, lines);
            var resultLine = sort.StartSorting();
            printLine = print.PrintLine;
            printLine(resultLine);
            //for (int i = 0; i < resultLine.Count; i++)
            //{
            //    Console.WriteLine("\t" + resultLine[i]);
            //}
            return resultLine;
        }

        public static void MessageLine(List<bool> number, List<bool> separator)
        {
            Print print = new Print();
            Message message;
            Error mes;
            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] == false)
                {
                    //Console.Write($"line{i + 1}: phone number should be with 9 digits,");
                    mes = print.ErrorPhoneNumber;
                    mes(i);
                }
                if (separator[i] == false)
                {
                    if (number[i]==false)
                    {
                        //Console.Write("the separator should be `:` or `-`.");
                        message = print.ErrorSeperatorWithoutLine;
                        message();
                    }
                    else
                    {
                        //Console.Write($"line{i + 1}: the separator should be `:` or `-`.");
                        mes = print.ErrorSeparator;
                        mes(i);
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
