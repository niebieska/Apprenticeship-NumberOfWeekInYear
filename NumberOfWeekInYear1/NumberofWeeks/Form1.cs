using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace NumberofWeeks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {}

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime iDate;
            iDate = dateTimePicker1.Value;
            Count c = new Count();
            c.NumberOfWeek(iDate);
           
            textBox1.Text= "Numer tygodnia w roku:" +' ' + c.NumberOfWeek(iDate).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void oProgamieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";

        }
    }
            
            public class Count{
public int NumberOfWeek(DateTime date)
        {
            int WeekNumber = 0;
            int SumofDays = date.Day;
            int feb = 28;
            if (IsLeapYear(date.Year) == 1) { feb = 29; }
            int[] NumberOfDays = { 31, feb, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (FirstWeekOfYear(date.Year,date.Month,date.Day) != 1)
            {
                WeekNumber = -1;
            }

            for (int i = 0; i < date.Month - 1; i++)
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
                if (LastThursdayInYear(date.Year) < date.Day && (LastThursdayInYear(date.Year) + 1) != 31)
                {         
                    WeekNumber = 1;
                }

            }
            if (FirstWeekOfYear(date.Year,date.Month,date.Day) != 1 && date.Month == 1 && date.Day < 4)
            {
                WeekNumber = FirstWeekOfYear(date.Year,date.Month,date.Day);
            }
            return WeekNumber;
        }
        


        
        public int FirstWeekOfYear(int y , int m, int d)
        {          
            DateTime date = new DateTime(y, m, d);  
            DateTime dt= new DateTime(y-1,12,31);
            int number=0;
            if (date.DayOfWeek.ToString() == "Friday" || date.DayOfWeek.ToString() == "Saturday" || date.DayOfWeek.ToString() == "Sunday")
            {  
                number=NumberOfWeek(dt);
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

           
        }             }




