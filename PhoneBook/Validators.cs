﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class Validators
    {
        public delegate void Message();
        public string filePath { get; set; }
        public string ChooseValidators(int selectValidator)
        {
            Print print = new Print();
            Message message;
            switch (selectValidator)
            {
                case 1:
                    message = print.FirstFile;
                    message();
                    filePath = @"C:\Users\Lenovo\source\repos\PhoneBook\text\file.txt";
                    break;
                case 2:
                    message = print.SecondFile;
                    message();
                    filePath = @"C:\Users\Lenovo\source\repos\PhoneBook\text\file1.txt";
                    break;
                case 3:
                    message = print.ThirdFile;
                    message();
                    filePath = @"C:\Users\Lenovo\source\repos\PhoneBook\text\file2.txt";
                    break;
                default:
                    message = print.FileNotFound;
                    message();
                    break;
            }
            return filePath;
        }
        public List<bool> CheckNumber(List<string> lines)
        {
            List<bool> result = new List<bool>();
            foreach (var line in lines)
            {
                char[] number = line.Where(c => char.IsDigit(c)).ToArray();
                if (number.Length != 9)
                {
                    result.Add(false);
                }
                else
                {
                    result.Add(true);
                }
            }
            return result;
        }
        public List<bool> CheckSurname(List<string> lines)
        {
            List<bool> surname = new List<bool>();
            foreach (var line in lines)
            {
                char[] fullName = line.Where(c => char.IsLetter(c)).ToArray();
                if (fullName.Where(c => char.IsUpper(c)).Count() == 2)
                {
                    surname.Add(true);
                }
                else
                {
                    surname.Add(false);
                }
            }
            return surname;
        }
        public List<bool> CheckSeparator(List<string> lines)
        {
            List<bool> result = new List<bool>();
            foreach (var line in lines)
            {
                string[] separator = line.Split('-', ':');
                if (separator.Count() == 2)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
            }
            return result;
        }
    }
}
