using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class Print
    {
        public void ChooseFile() => Console.WriteLine("Plese choose the file 1,2 or 3");
        public void ChooseOrderingSort()=> Console.WriteLine("Please choose an ordering to sort: “Ascending” or “Descending");
        public void ChooseCriteria() => Console.WriteLine("“Please choose criteria: “Name”, “Surname” or “PhoneNumberCode”.");
        public void ErrorPhoneNumber(int lineNumber) => Console.Write($"line{lineNumber + 1}:phone number should be with 9 digits,");

        public void ErrorSeparator (int lineNumber) => Console.Write($"line{lineNumber + 1}:the separator should be `:` or `-`.");

        public void ErrorSeperatorWithoutLine() => Console.WriteLine("the separator should be `:` or `-`.");

        public void PrintLine(List<string> line)
        {
            for (int i = 0; i < line.Count; i++)
            {
                Console.WriteLine("\t" + line[i]);
            }
        }
    }
}
