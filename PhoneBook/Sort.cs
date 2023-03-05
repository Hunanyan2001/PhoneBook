using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PhoneBook
{
    public class Sort
    {
        public string OrderWays { get; set; }
        public string Criteria { get; set; }

        public string[] Lines { get; set; }
        public Sort(string OrderWays, string Criteria, string[] Lines)
        {
            this.OrderWays = OrderWays;
            this.Criteria = Criteria;
            this.Lines = Lines;
        }
        public List<string> StartSorting()
        {
            List<string> list = new List<string>();
            if (Criteria == "Name")
            {
                list = OrderByName(Lines);
            }
            else if (Criteria == "Surname")
            {
                list = OrderBySurname(Lines);
            }
            else
            {
                list = OrderByPhoneNumber(Lines);
            }
            return list;
        }
        private List<string> OrderByName(string[] Lines)
        {
            List<string> list = new List<string>();
            if (OrderWays == "Ascending")
            {
                list = Lines.OrderBy(x => x.Split(' ')[0]).ToList();
            }
            else
            {
                list = Lines.OrderByDescending(x => x.Split(' ')[0]).ToList();
            }
            return list;
        }
        private List<string> OrderBySurname(string[] Lines)
        {
            List<string> list = new List<string>();
            if (OrderWays == "Ascending")
            {
                list = Lines.OrderByDescending(x => x.Split(' ').Count()).ThenBy(x => x.Split(' ').Skip(1).FirstOrDefault()).ToList();
            }
            else
            {
                list = Lines.OrderBy(string.IsNullOrWhiteSpace).ThenByDescending(x => x.Split(' ').Skip(1).FirstOrDefault()).ToList();
            }
            return list;

        }
        private List<string> OrderByPhoneNumber(string[] Lines)
        {
            List<string> list = new List<string>();
            List<string> count = new List<string>();
            if (OrderWays == "Ascending")
            {
                list = Lines.OrderBy(x => x.Split(' ').Last().ToString().Substring(0, 3)).ToList();
            }
            else
            {
                list = Lines.OrderByDescending(x => x.Split(' ').Last().ToString().Substring(0, 3)).ToList();
            }
            return list;
        }
    }
}
