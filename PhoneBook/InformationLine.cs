using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneBook.Program;

namespace PhoneBook
{
    public class InformationLine
    {
        public List<bool> _number { get; set; }
        public List<bool> _separator { get;set; }
        public InformationLine(List<bool> number, List<bool> separator) 
        { 
           _number = number;
           _separator = separator;
        }
        public void Information()
        {
            Print print = new Print();
            Message message;
            Error mes;
            for (int i = 0; i < _number.Count; i++)
            {
                if (_number[i] == false)
                {
                    mes = print.ErrorPhoneNumber;
                    mes(i);
                }
                if (_separator[i] == false)
                {
                    if (_number[i] == false)
                    {
                        message = print.ErrorSeperatorWithoutLine;
                        message();
                    }
                    else
                    {
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
