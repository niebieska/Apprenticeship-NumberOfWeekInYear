using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberOfWeekInYear
{
    class Program
    {
        public int p;
        static void Main(string[] args)
        {   
            Program p = new Program();
            Date d= new Date();
            int type;
            int k=1;

            while (k != 0)
            {
                Console.WriteLine(" Wybierz rodzaj dzialania: \n 1 numer tygodnia dla aktualnej daty \n 2 numer tygodnia dla wybranej daty \n 3 wyjscie");
                type = int.Parse(Console.ReadLine());

                switch (type)
                {
                    case 1: p.NumberOfThisWeek(); break;
                    case 2: d.GetDate(); d.WriteDate(); /*p.BreakWithStars();*/ d.IsCorrect(); p.NumberOfWeek(d.Day(), d.Month(), d.Year()); break;
                    case 3: k = 0; break;
                    default: Console.WriteLine("Wybrano zly klawisz"); break;
                }
                if (k == 0) break;
                Console.WriteLine();
            }
        }
    
        
        public void Today(DateTime date) 
        {
            Console.WriteLine("Aktualna data:");
            Console.Write(date);
            Console.WriteLine();
        }
        public void NumberOfWeek(int d, int m, int y)
        {
            Date dt = new Date();
            DateTime date = new DateTime(y, m, d);
            int WeekNumber = 0;
            int SumofDays = d;
            int feb=28;
            if (IsLeapYear(y) == 1) { feb = 29; }
            int[] NumberOfDays = { 31, feb, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            
            if (FirstWeekOfYear(y, m, d) != 1)
            {
                WeekNumber = -1;
            }
            
            for (int i = 0; i < m-1; i++)
            {
                SumofDays += NumberOfDays[i];           
            }
            
            WeekNumber += SumofDays / 7;
                                
            
            if (SumofDays % 7 >0)
            {
                WeekNumber ++;
            }
            else
            {
                WeekNumber++;
            }
            
            if (WeekNumber == 53)
            {
                if (LastThursdayInYear(y) < d && (LastThursdayInYear(y) + 1) != 31) 
                {
                    Console.WriteLine("\n Tydzien jest 1 w nowym roku "+(y+1));
                    Console.WriteLine("\n"); 
                    WeekNumber=1; 
                }
                       
            }
            if (FirstWeekOfYear(y, m, d) != 1 && m == 1 && d < 4)
            { 
                WeekNumber = FirstWeekOfYear(y, m, d);
                Console.WriteLine("\n Tydzien nalezy do poprzedniego roku: " + (y - 1)+ "\n");
            }
            //BreakWithStars();
            Console.WriteLine(" Numer tygodnia: "+ WeekNumber);
            Console.WriteLine();
        }
        /*public void BreakWithStars()
        { string s="**";
            for (int i = 1; i < 30; i++) 
            {
                s += "**";
            }
            Console.WriteLine("\n");
            Console.WriteLine(s);
            Console.WriteLine("\n");
        
        }*/
        public int NumberOfWeekInt(int d, int m, int y)
        {
            Date dt = new Date();
            DateTime date = new DateTime(y, m, d);
            int WeekNumber = 0;
            int SumofDays = d;
            int feb = 28;
            if (IsLeapYear(y) == 1) { feb = 29; }
            int[] NumberOfDays = { 31, feb, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (FirstWeekOfYear(y, m, d) != 1)
            {
                WeekNumber = -1;
            }

            for (int i = 0; i < m - 1; i++)
            {
                SumofDays += NumberOfDays[i];
            }

            WeekNumber += SumofDays / 7;


            if (SumofDays % 7 > 0)
            {
                WeekNumber++;
            }
            else
            {
                WeekNumber++;
            }

            if (WeekNumber == 53)
            {
                if (LastThursdayInYear(y) < d && (LastThursdayInYear(y) + 1) != 31)
                {         
                    WeekNumber = 1;
                }

            }
            if (FirstWeekOfYear(y, m, d) != 1 && m == 1 && d < 4)
            {
                WeekNumber = FirstWeekOfYear(y, m, d);
            }
            return WeekNumber;
        }
        


        
        public int FirstWeekOfYear(int y , int m, int d)
        {          
            DateTime date = new DateTime(y, m, d);            
            int number=0;
            if (date.DayOfWeek.ToString() == "Friday" || date.DayOfWeek.ToString() == "Saturday" || date.DayOfWeek.ToString() == "Sunday")
            {
                number=NumberOfWeekInt(31, 12, y - 1);
            }
            else
            { 
             number=1;
            }
            return number;
        }

        public int LastThursdayInYear(int y)
        {
            int LastThursdayNumber=0;
            int m = 12;
            for (int i = 1; i <= 31; i++)
            {
                if (ActualDayOfWeek(i, m, y) == "Thursday") 
                {
                    LastThursdayNumber = i;
                }                    
            }
            return LastThursdayNumber; 
        }

        public string ActualDayOfWeek(int d,int m, int y)
        {
            DateTime date = new DateTime(y, m, d);
            return date.DayOfWeek.ToString();

        }
        
        public int IsLeapYear(int y)
        {
            int i = 0;
            if (y % 4 == 0 && y % 100 != 0 || y % 400 == 0)
            {
                i = 1;
            }
            return i;
        }

        public void NumberOfThisWeek()
        {
            DateTime date = DateTime.Now;
            Today(date);
            NumberOfWeek(date.Day, date.Month, date.Year);         
        }

        /*public int WeekDay(string a)
        {
            int substract = 0;
            string[] DaysNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            if (a =="Monday") return 0;
            else
            {
                for (int i = 0; i < 7; i++)
                    {
                        if (a == DaysNames[i]) 
                        {
                        substract = i; 
                        }
                    }
             }
            return substract;
        }*/
        
    }
       
    
}
    class Date
    {
        private int day;
        private int month;
        private int year;
           
        public int IsLeapYear()
        {
            int i = 0;
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
            {
                i= 1;
            }
            return i;
        }
        
        public void IsCorrect() 
        {
            char sign;
            Console.WriteLine("Korygowac programowo date? \n t - tak \n n - nie");
            sign = char.Parse(Console.ReadLine());
            switch (sign)
            {
                case 't': RepairDate(); WriteDate(); break;
                case 'n': break;
                default: Console.WriteLine("Wybrano zly klawisz"); break;
            }
               
        }

        public void RepairDate()
        { 
            if (month < 1) month = 1;
            else if (month > 12)month = 12;
            if (day < 1)day = 1;
            
            int DaysOfMonth;
            
            switch (month)
            {
                case 2:
                    if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) DaysOfMonth = 29;
                    else DaysOfMonth = 28;
                    break;
                case 1:case 3:case 5: case 7: case 8: case 10: case 12: DaysOfMonth = 31;
                    break;
                default:
                    DaysOfMonth = 30; break;
            }
            
            if (day > DaysOfMonth)day = DaysOfMonth;
            Console.WriteLine("Skorygowana");
        }

        public void SetDate(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }
        
        public void WriteDate()
        {
            Console.WriteLine("Data:");
            Console.Write(day); Console.Write('-');
            Console.Write(month); Console.Write('-');
            Console.Write(year); Console.WriteLine();        
        }
                
         public void GetDate()
         {
             Console.WriteLine("Wpisz date");
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




