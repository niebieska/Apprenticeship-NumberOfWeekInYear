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
            while (k!=0)
            {
                d.ChooseFirstDay();
                Console.WriteLine(" Wybierz rodzaj dzialania: \n 1 numer tygodnia dla aktualnej daty \n 2 numer tygodnia dla wybranej daty \n 3 wyjscie");
                
                type = int.Parse(Console.ReadLine());
                switch (type)
                {
                    case 1: p.NumberOfThisWeek(d.FirstDay()); break;
                    case 2: d.GetDate(); d.WriteDate(); d.IsCorrect(); p.NumberOfWeek(d.Day(), d.Month(), d.Year(), d.FirstDay()); break;
                    case 3: k = 0; break;
                    default: Console.WriteLine("Wybrano zly klawisz"); break;

                }
                if (k == 0) break;
                Console.WriteLine();
                //Console.ReadLine();
            }
        }

       
     
        public void Today(DateTime date) 
        {
            Console.WriteLine("Aktualna data:");
            Console.Write(date);
            Console.WriteLine();
        }
        public void NumberOfWeek(int d, int m, int y, string FirstDay)
        {
            //Date dt = new Date();
            DateTime date = new DateTime(y, m, d);
            int[] NumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int WeekNumber = 0;
            string ActualDay = date.DayOfWeek.ToString();
            int Substract = WeekDay(FirstDay, ActualDay);
            int SumofDays = d - Substract ;
            
            for (int i = 0; i < m-1; i++)
            {
                SumofDays += NumberOfDays[i];
                
            }
            WeekNumber = SumofDays / 7;
                      
            
            if (SumofDays % 7 > 3)
            {
                WeekNumber += 2;
            }
            else
            {
                WeekNumber++;
            }
            
            if (WeekNumber == 53)
            {
                if (LastThursdayInYear(y) < d && (LastThursdayInYear(y)+1)!=31) { WeekNumber--; }
                       
            }

            Console.WriteLine("Numer tygodnia:");
            Console.Write(WeekNumber); 
               
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
      
        public void NumberOfThisWeek(string f)
        {
            DateTime date = DateTime.Now;
            Today(date);
            NumberOfWeek(date.Day, date.Month, date.Year,f);
         
        }
        public int WeekDay(string f, string a)
        {    
            int substract = 0;

            string[] DaysNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] DaysNames2 = { "Sunday","Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            if (a == f) return 0;
            else
            {
                if (f == "Monday")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (a == DaysNames[i]) { substract = i; }

                    }
                }
                else {
                    for (int i = 0; i < 7; i++)
                    {
                        if (a == DaysNames2[i]) { substract = i+1; }

                    }
                                }

                return substract;
            }
        }
       
    }
    
    
    class Date
    {
        private int day;
        private int month;
        private int year;
        private string firstday;
            
        public void SetFirstDay(string s) 
                {
                    this.firstday = s;      
                }

        public void ChooseFirstDay()
        {   char s;
            Console.WriteLine("Wybierz pierwszy dzien tygodnia! \n p\t- poniedzialek\t n\t-niedziela");
            s = char.Parse(Console.ReadLine());
            switch (s)
            {
                case 'p': SetFirstDay("Monday"); break;
                case 'n':  SetFirstDay("Sunday"); break;

                default: Console.WriteLine("Wybrano zly klawisz"); break;
            }
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
        public string FirstDay() { return firstday; }

    }



}
