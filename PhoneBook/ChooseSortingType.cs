using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneBook.Program;

namespace PhoneBook
{
    public class ChooseSortingType
    {
        public string[] _lines { get; set; }   
        public ChooseSortingType(string[] lines) 
        {
             this._lines = lines;  
        }  
        public List<string> Choose()
        {
            Print print = new Print();
            PrintLineInformation printLine;
            Message mes = print.ChooseOrderingSort;
            mes();
            string sortingType = Console.ReadLine();
            mes = print.ChooseCriteria;
            mes();
            string sortingCriteria = Console.ReadLine();
            Sort sort = new Sort(sortingType, sortingCriteria, _lines);
            var resultLine = sort.StartSorting();
            printLine = print.PrintLine;
            printLine(resultLine);
            return resultLine;
        }
    }
}
