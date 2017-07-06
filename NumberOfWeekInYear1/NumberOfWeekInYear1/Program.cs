using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberOfWeekInYear
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    
    class Date
    {
        private int day;
        private int month;
        private int year;

        public void RepairDate()
        {
            if (month < 1)
                month = 1;
            else if (month > 12)
                month = 12;

            if (day < 1)
                day = 1;

            int DaysOfMonth;
            switch (month)
            {
                case 2:
                    if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                        DaysOfMonth = 29;
                    else
                        DaysOfMonth = 28;
                    break;
                case 1:case 3:case 5: case 7: case 8: case 10: case 12: DaysOfMonth = 31;
                    break;
                default:
                    DaysOfMonth = 30; break;
            }

            if (day > DaysOfMonth)
                day = DaysOfMonth;

        }
        public void SetDate(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;

        }
        public void WriteDate()
        {
            Console.WriteLine("Wprowadzona data:");
            Console.Write(day); Console.Write('-');
            Console.Write(month); Console.Write('-');
            Console.Write(year); Console.WriteLine();
        
        }
        
         public void GetDate()
        {
            Console.WriteLine("Podaj date:");
            Console.WriteLine("Dzien:");
            this.day = int.Parse(Console.ReadLine());
            Console.WriteLine("Miesiac:");
            this.month = int.Parse(Console.ReadLine());
            Console.WriteLine("Rok:");
            this.year= int.Parse(Console.ReadLine());
            
        }
        
        
        public int Day() { return day; }
        public int Month() { return month; }
        public int Year() { return year; }




    }



}
